using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DigiShop.CoreBussiness.EfCoreDomains.SiteSettings;
using DigiShop.CoreBussiness.RepsPattern;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DigiShop.Models;
using Microsoft.EntityFrameworkCore;

namespace DigiShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
       
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
         
        }

        public IActionResult Index()
        {
            
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception e)
            {
                _logger.LogError(e,e.Message);
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
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}