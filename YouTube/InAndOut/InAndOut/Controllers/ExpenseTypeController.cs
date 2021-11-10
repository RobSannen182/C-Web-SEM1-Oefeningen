using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class ExpenseTypeController : Controller
    {
        private ApplicationDbContext _db;

        public ExpenseTypeController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            IEnumerable<ExpenseType> expenseTypeList = _db.ExpenseTypes;
            return View(expenseTypeList);
        }

        #region Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ExpenseType expType)
        {
            if (ModelState.IsValid)  // controle op juiste ingave > voorwaarden worden meegegeven in Models klasse / enkel nodig bij client side validation?
            {
                _db.ExpenseTypes.Add(expType);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(expType);
            }
        }
        #endregion

        #region Delete

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var expType = _db.ExpenseTypes.Find(id);
            if (expType == null)
            {
                return NotFound();
            }
            return View(expType);
        }

        [HttpPost]
        public IActionResult DeletePost(int? id)
        {
            var expType = _db.ExpenseTypes.Find(id);
            if (expType == null)
            {
                return NotFound();
            }
            else
            {
                _db.ExpenseTypes.Remove(expType);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        #endregion

        #region Update

        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var expType = _db.ExpenseTypes.Find(id);
            if (expType == null)
            {
                return NotFound();
            }
            return View(expType);
        }

        [HttpPost]
        public IActionResult UpdatePost(ExpenseType expType)
        {

            if (ModelState.IsValid)
            {
                _db.ExpenseTypes.Update(expType);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expType);

        }
        #endregion
    }
}
