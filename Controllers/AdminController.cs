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
    public class AdminController : Controller
    {
        private readonly LoginForm _loginInfo;
        private readonly string _connectionString;

        public AdminController(IOptions<LoginForm> loginInfo, IOptions<DbConnection> dbConnection)
        {
            _loginInfo = loginInfo.Value;
            _connectionString = dbConnection.Value.ConnectionString;
        }
        [Authorize(Roles = Role.Admin)]
        public IActionResult Index()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                ViewBag.sinavlar = sqlConnection.Query<Sinav>("select * from Sinavlar order by Id desc").ToList();
            }
            return View();
        }

        [Authorize(Roles = Role.Admin)]
        public IActionResult SinavSonuclari()
        {
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
                group by Sinavlar.SinavAdi,Sinavlar.Id,K.AdSoyad").ToList();
            }
            return View();
        }
        [Authorize(Roles = Role.Admin)]
        public IActionResult SinavSonucuSil(int Id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", Id);
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Query("delete from SinavSonuclari where SoruId in (select Id from Sorular where SinavId=@Id)", parameters);
            }
            return Redirect("/admin/SinavSonuclari");
        }
        [Authorize(Roles = Role.Admin)]
        public IActionResult SinavSil(int Id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", Id);
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Query("delete from SinavSonuclari where SoruId in (select Id from Sorular where SinavId=@Id);delete from Sorular where SinavId=@Id;delete from Sinavlar where Id=@Id", parameters);
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return Redirect("/admin/");
        }
        [Authorize(Roles = Role.Admin)]
        public IActionResult SinavEkle()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public IActionResult SinavEkle(Sinav entity)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@SinavAdi", entity.SinavAdi);
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Query("insert into Sinavlar (SinavAdi) values (@SinavAdi)", parameters);
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return Redirect("/admin/");
        }
        [Authorize(Roles = Role.Admin)]
        public IActionResult SinavDuzenle(int Id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", Id);
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                ViewBag.sinav = sqlConnection.QueryFirst<Sinav>("select * from Sinavlar where Id=@Id", parameters);
            }
            return View();
        }
        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public IActionResult SinavDuzenle(Sinav entity)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", entity.Id);
                parameters.Add("@SinavAdi", entity.SinavAdi);
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Query("update Sinavlar set SinavAdi=@SinavAdi where Id=@Id", parameters);
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return Redirect("/admin/");
        }
        [Authorize(Roles = Role.Admin)]
        public IActionResult Sorular(int SinavId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@SinavId", SinavId);
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                if (SinavId == 0)
                {
                    ViewBag.sorular = sqlConnection.Query<Soru>("select * from Sorular order by Id desc").ToList();
                }
                else
                {
                    ViewBag.sorular = sqlConnection.Query<Soru>("select * from Sorular where SinavId=@SinavId order by Id desc", parameters).ToList();
                }
            }
            return View();
        }
        [Authorize(Roles = Role.Admin)]
        public IActionResult SoruSil(int SinavId, int Id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", Id);
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Query("delete from SinavSonuclari where SoruId=@Id;delete from Sorular where Id=@Id", parameters);
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return Redirect("/admin/sorular?SinavId=" + SinavId);
        }
        [Authorize(Roles = Role.Admin)]
        public IActionResult SoruEkle(int SinavId)
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public IActionResult SoruEkle(Soru entity, int SinavId)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@SinavId", SinavId);
                parameters.Add("@Sual", entity.Sual);
                parameters.Add("@A", entity.A);
                parameters.Add("@B", entity.B);
                parameters.Add("@C", entity.C);
                parameters.Add("@D", entity.D);
                parameters.Add("@E", entity.E);
                parameters.Add("@Cevap", entity.Cevap);
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Query("insert into Sorular (SinavId,Sual,A,B,C,D,E,Cevap) values (@SinavId,@Sual,@A,@B,@C,@D,@E,@Cevap)", parameters);
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return Redirect("/admin/sorular?SinavId=" + SinavId);
        }
        [Authorize(Roles = Role.Admin)]
        public IActionResult SoruDuzenle(int Id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", Id);
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                ViewBag.soru = sqlConnection.QueryFirst<Soru>("select * from Sorular where Id=@Id", parameters);
            }
            return View();
        }
        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public IActionResult SoruDuzenle(Soru entity, int SinavId)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", entity.Id);
                parameters.Add("@SinavId", SinavId);
                parameters.Add("@Sual", entity.Sual);
                parameters.Add("@A", entity.A);
                parameters.Add("@B", entity.B);
                parameters.Add("@C", entity.C);
                parameters.Add("@D", entity.D);
                parameters.Add("@E", entity.E);
                parameters.Add("@Cevap", entity.Cevap);
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Query("update Sorular set SinavId=@SinavId,Sual=@Sual,A=@A,B=@B,C=@C,D=@D,E=@E,Cevap=@Cevap where Id=@Id", parameters);
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return Redirect("/admin/sorular?SinavId=" + SinavId);
        }


        [Authorize(Roles = Role.Admin)]
        public IActionResult Kullanicilar()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                ViewBag.kullanicilar = sqlConnection.Query<Kullanici>("select * from Kullanicilar order by Id desc").ToList();
            }

            return View();
        }
        [Authorize(Roles = Role.Admin)]
        public IActionResult KullaniciSil(int Id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", Id);
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Query("delete from SinavSonuclari where KullaniciId=@Id;delete from Kullanicilar where Id=@Id", parameters);
                }

            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return Redirect("/Admin/Kullanicilar");
        }
        public IActionResult Login()
        {
            if (HttpContext.Request.Query["ReturnUrl"].ToString().ToLower().StartsWith("/kullanici"))
            {
                return Redirect("/Kullanici/Login");
            }
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return Redirect("/Admin/Login");
        }
        [HttpPost]
        public IActionResult Login(LoginForm loginForm)
        {
            if (loginForm.Username == _loginInfo.Username && loginForm.Password == _loginInfo.Password)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,loginForm.Username),
                    new Claim(ClaimTypes.Role,Role.Admin)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties();
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                return Redirect(string.IsNullOrEmpty(HttpContext.Request.Query["ReturnUrl"]) ? "/Admin" : HttpContext.Request.Query["ReturnUrl"].ToString());
            }

            TempData["error"] = $"Kullanıcı adı veya parola yanlış.";
            return View();
        }
    }
}
