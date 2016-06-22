using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PriceSnoop.Shared.Models;
using Microsoft.Extensions.Configuration;

namespace PriceSnoop.Controllers
{
    public class HomeController : Controller
    {
        private readonly string _ebayAppId;

        public HomeController(IConfiguration config)
        {
            _ebayAppId = "<Not Set>";
            if (config != null)
            {
                _ebayAppId = config["EbaySettings:AppId"] ?? _ebayAppId;
            }
        }

        public IActionResult Index()
        {
            ViewBag.EbayAppId = _ebayAppId;
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
