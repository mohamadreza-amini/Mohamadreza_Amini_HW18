
using Microsoft.AspNetCore.Mvc;
using Mohamadreza_Amini_HW18.Models;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Mohamadreza_Amini_HW18.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDbConnection _connection;
        public HomeController(ILogger<HomeController> logger,IConfiguration conf)
        {
            _logger = logger;
            //_connection =new SqlConnection(conf.GetConnectionString("DefaultConnection"));
        }

        public IActionResult Index()
        {
            using (IDbConnection conn = _connection)
            {
                conn.Open();
              //  IEnumerable<Store> a = conn.Query<Store>("select * from sales.stores s where s.zip_code = 95060");
              //  return Json(a);
            }
            
                return View();


        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
