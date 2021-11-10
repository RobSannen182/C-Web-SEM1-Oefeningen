using Microsoft.AspNetCore.Mvc;
using MVCOefening07.Data;
using MVCOefening07.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCOefening07.Controllers
{
    public class MedewerkersController : Controller
    {
        private ApplicationDbContext _db;

        public MedewerkersController(ApplicationDbContext db)
        {
            _db = db;
        }

        #region Index

        public IActionResult Index()
        {
            var lstMedewerkers = _db.medewerkers;
            return View(lstMedewerkers);
        }

        #endregion

        #region Create

        [HttpGet]
        public IActionResult Create()
        {
            var medewerker = new Medewerker();
            return View(medewerker);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Medewerker medewerker)
        {
            if (ModelState.IsValid)
            {
                AddMedewerker(medewerker);
                return RedirectToAction("Index");
            }
            return View(medewerker);
        }
        private void AddMedewerker(Medewerker medewerker)
        {
            _db.medewerkers.Add(medewerker);
            _db.SaveChanges();
        }
        #endregion

        #region Details

        public IActionResult Details(int id)
        {
            var med = _db.medewerkers.Find(id);
            return View(med);
        }

        #endregion

        #region Edit

        public IActionResult Edit(int id)
        {
            var med = _db.medewerkers.Find(id);
            return View(med);
        }
        [HttpPost]
        public IActionResult Edit(Medewerker med)
        {
            if (ModelState.IsValid)
            {
                _db.medewerkers.Update(med);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(med);
        }

        #endregion

        #region Delete

        public IActionResult Delete(int id)
        {
            var med = _db.medewerkers.Find(id);
            return View(med);
        }

        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            var med = _db.medewerkers.Find(id);
            _db.medewerkers.Remove(med);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion


    }
}
