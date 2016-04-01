using Microsoft.AspNet.Mvc;
using PriceSnoop.ViewModels;

namespace PriceSnoop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(Products.GetProducts());
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

        public IActionResult Error()
        {
            return View();
        }
    }
}