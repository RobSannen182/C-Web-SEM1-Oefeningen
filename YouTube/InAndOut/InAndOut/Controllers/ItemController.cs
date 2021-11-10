using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class ItemController : Controller
    {
        //=====================================================================
        // ApplicationDbContext (klasse in datafolder) bevat alle DbSets (tabellen in databank)
        // Door deze klasse mee te geven aan de ctor van deze controller, wordt de databank beschikbaatr binnen deze controller.

        private ApplicationDbContext _db;

        public ItemController(ApplicationDbContext db)
        {
            _db = db;
        }
        //=====================================================================


        public IActionResult Index()
        {

            IEnumerable<Item> objList = _db.Items; // _db.Items is de tabel Items uit de databank opgevuld met klasses Item
            return View(objList);
        }




        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            _db.Items.Add(item); // Het Item doorgegeven aan deze actie wordt toegevoegd aan de databank
            _db.SaveChanges(); // De changes in de db worden opgeslaan
            return RedirectToAction("Index"); // actie "Index" wordt uitgevoerd
        }
    }
}
