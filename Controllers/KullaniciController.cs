using Dapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SinavTakipSistemi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SinavTakipSistemi.Controllers
{
    public class KullaniciController : Controller
    {
        private readonly string _connectionString;
        public KullaniciController(IOptions<DbConnection> dbConnection)
        {
            _connectionString = dbConnection.Value.ConnectionString;
        }

        public IActionResult Kayit()
        {
            return View();
        }

        [Authorize(Roles = Role.User)]
        public IActionResult SinavaGir(int Id)
        {
            bool sinavaGirmisMi = false;
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", Id);
            parameters.Add("@KullaniciId", HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault()?.Value);
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sinavaGirmisMi = sqlConnection.Query<Soru>("select * from SinavSonuclari Si inner join Sorular So on Si.SoruId=So.Id where Si.KullaniciId=@KullaniciId and SinavId=@Id", parameters).ToList().Count!=0;
                ViewBag.sorular = sqlConnection.Query<Soru>("select * from Sorular where SinavId=@Id order by Id desc", parameters).ToList();
            }
            if (sinavaGirmisMi)
            {
                TempData["error"] = "Aynı sınava tekrar giremezsiniz!";
                return Redirect("/");
            }
            return  View();
        }

        [Authorize(Roles = Role.User)]
        public IActionResult SinavSonuclarim()
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@KullaniciId", HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault()?.Value);
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                ViewBag.sinavsonuclari = sqlConnection.Query<SinavSonucu>(@"
                select 
	                Sinavlar.Id,
	                SinavAdi,
	                K.AdSoyad,
	                count(SinavAdi) as SoruSayisi,
	                sum(case when Si.Cevap=So.Cevap then 1 else 0 end) as DogruSayisi,
	                sum(case when Si.Cevap=So.Cevap then 0 else 1 end) as YanlisSayisi
                from SinavSonuclari Si
                inner join Sorular So on Si.SoruId=So.Id
                inner join Sinavlar on So.SinavId=Sinavlar.Id
                inner join Kullanicilar K on Si.KullaniciId=K.Id
                where KullaniciId=@KullaniciId
                group by Sinavlar.SinavAdi,Sinavlar.Id,K.AdSoyad", parameters).ToList();
            }
            return View();
        }
        [HttpPost]
        [Authorize(Roles = Role.User)]
        public IActionResult SinavaGir()
        {
            var ids = Request.Form["Id"].ToString().Split(',');

            foreach (var id in ids)
            {
                try
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@KullaniciId", HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value);
                    parameters.Add("@SoruId", id);
                    parameters.Add("@Cevap", Request.Form[$"Cevap[{id}]"]);
                    using (var sqlConnection = new SqlConnection(_connectionString))
                    {
                        sqlConnection.Query("insert into SinavSonuclari (KullaniciId,SoruId,Cevap) values (@KullaniciId,@SoruId,@Cevap)", parameters);
                    }

                }
                catch (Exception ex)
                {
                    TempData["error"] = ex.Message;
                }

            }
            return Redirect("/Kullanici/SinavSonuclarim");
        }
        [HttpPost]
        public IActionResult Kayit(Kullanici kullanici)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@AdSoyad", kullanici.AdSoyad);
                parameters.Add("@Mail", kullanici.Mail);
                parameters.Add("@Telefon", kullanici.Telefon);
                parameters.Add("@Sifre", kullanici.Sifre);
                parameters.Add("@Tc", kullanici.Tc);
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Query("insert into Kullanicilar (AdSoyad,Mail,Telefon,Sifre,Tc) values (@AdSoyad,@Mail,@Telefon,@Sifre,@Tc)", parameters);
                }

                return Login(new LoginForm { Username = kullanici.Mail, Password = kullanici.Sifre });
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return Redirect("/");
        }
        [HttpPost]
        public IActionResult Login(LoginForm loginForm)
        {
            try
            {
                Kullanici kullanici = null;
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Mail", loginForm.Username);
                parameters.Add("@Sifre", loginForm.Password);
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    kullanici = sqlConnection.QueryFirst<Kullanici>("select * from Kullanicilar where Mail=@Mail and Sifre=@Sifre", parameters);

                }


                if (kullanici != null)
                {
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,kullanici.AdSoyad),
                    new Claim(ClaimTypes.NameIdentifier,kullanici.Id.ToString()),
                    new Claim(ClaimTypes.Role,Role.User)
                };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties();
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                    return Redirect(string.IsNullOrEmpty(HttpContext.Request.Query["ReturnUrl"]) ? "/" : HttpContext.Request.Query["ReturnUrl"].ToString());
                }
            }
            catch (Exception)
            {
                TempData["error"] = $"Kullanıcı adı veya parola yanlış.";
            }
            return View();
        }
    }
}