
using Core;
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

        private readonly IStoreRepository storeRepository;
        private readonly IProductRepository productRepository;
        public HomeController(ILogger<HomeController> logger, IStoreRepository store, IProductRepository product)
        {
            _logger = logger;
            storeRepository = store;
            productRepository = product;
        }

        public IActionResult Index()
        {
           
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
