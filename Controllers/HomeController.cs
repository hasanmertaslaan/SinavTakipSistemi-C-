using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SinavTakipSistemi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SinavTakipSistemi.Controllers
{
    public class HomeController : Controller
    {

        private readonly string _connectionString;

        public HomeController(IOptions<DbConnection> dbConnection)
        {
            _connectionString = dbConnection.Value.ConnectionString;
        }

        public IActionResult Index()
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@KullaniciId", HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault()?.Value);
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                ViewBag.sinavlar = sqlConnection.Query<Sinav>(@"
                select 
                	Si.Id,Si.SinavAdi,COUNT(Si.Id) as SoruAdeti
                from Sinavlar Si
                inner join Sorular So on Si.Id=So.SinavId
                where So.Id not in (select SoruId from SinavSonuclari where KullaniciId=@KullaniciId)
                group by Si.Id,Si.SinavAdi", parameters).ToList();
            }

            return View();
        }

    }
}
