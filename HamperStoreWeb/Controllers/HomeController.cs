using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HamperStoreWeb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using HamperStoreWeb.DataAcess.Models;

namespace HamperStoreWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly HamperStoreEntities _context;

        public HomeController(HamperStoreEntities context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var hamperCategoryList = _context.HamperCategories.ToList();
            return View(hamperCategoryList);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
