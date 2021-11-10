using Microsoft.AspNetCore.Mvc;
using MVCOefening07.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCOefening07.Controllers
{
    public class AfdelingenController : Controller
    { 
        private ApplicationDbContext _db;

        public AfdelingenController(ApplicationDbContext db)
        {
            _db = db;
        }

    
        public IActionResult Index()
        {
            return View();
        }
    }
}
