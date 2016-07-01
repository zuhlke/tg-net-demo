using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PriceSnoop.Shared.Models;
using Microsoft.Extensions.Configuration;
using PriceSnoop.Services;

namespace PriceSnoop.Controllers
{
    public class HomeController : Controller
    {
        IProductSearch _productSearch;

        public HomeController(IProductSearch productSearch)
        {
            _productSearch = productSearch;
        }

        public IActionResult Index()
        {
            var searchResults = _productSearch.Search("Harry Potter");

            var vmProds = searchResults.Select(p => new Product(p.Title)).ToList();
            return View(vmProds);
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
