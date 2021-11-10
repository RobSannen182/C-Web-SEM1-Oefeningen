using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCSportStore.Data;
using MVCSportStore.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSportStore.Controllers
{
    public class HomeController : Controller
    {
        private ProductRepository _repo;
        private StoreDbContext _context;
        public HomeController(StoreDbContext context)
        {
            _context = context;
            _repo = new ProductRepository(_context);
        }

        // private readonly ILogger<HomeController> _logger;

        //Omdat ik een constructor toevoeg voor dbcontext moet de ctor voor de ILogger weg
        //Er kan maar 1 ctor zijn met 1 argument
        //Ik had ook StoreDbContext context hierin kunnen toevoegen

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index(int id, string category)
        {
            var productList = _repo.GetProductsList(id, category);
            return View(productList) ;
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
