using InAndOut.Data;
using InAndOut.Models;
using InAndOut.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class ExpenceController : Controller
    {
        private ApplicationDbContext _db;

        public ExpenceController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Expence> expencesList = _db.Expences;
            foreach (var exp in expencesList)
            {
                exp.ExpenseType = _db.ExpenseTypes.FirstOrDefault(u => u.Id == exp.ExpenseTypeId);
            }
            return View(expencesList);
        }



        public IActionResult Create()
        {
            //IEnumerable<SelectListItem> TypeDropDown = _db.ExpenseTypes.Select(i => new SelectListItem
            //{
            //    Text = i.Name,
            //    Value = i.Id.ToString()
            //});
            //ViewBag.TypeDropDown = TypeDropDown;

            ExpenseVM expenseVM = new ExpenseVM()
            {
                Expense = new Expence(),
                TypeDropDown = _db.ExpenseTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };
            return View(expenseVM);
        }

        [HttpPost]
        public IActionResult Create(ExpenseVM expVM)
        {
            if (ModelState.IsValid)  // controle op juiste ingave > voorwaarden worden meegegeven in Models klasse / enkel nodig bij client side validation?
            {
                _db.Expences.Add(expVM.Expense);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(expVM);
            }
        }



        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var exp = _db.Expences.Find(id);
            if (exp == null)
            {
                return NotFound();
            }
            exp.ExpenseType = _db.ExpenseTypes.FirstOrDefault(i => i.Id == exp.ExpenseTypeId);
            return View(exp);
        }

        [HttpPost]
        public IActionResult DeletePost(int? id)
        {
            var exp = _db.Expences.Find(id);
            if (exp == null)
            {
                return NotFound();
            }
            else
            {
                _db.Expences.Remove(exp);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
        }




        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            ExpenseVM expVM = new ExpenseVM()
            {
                Expense = _db.Expences.Find(id),
                TypeDropDown = _db.ExpenseTypes.Select(i => new SelectListItem()
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };

            if (expVM.Expense == null)
            {
                return NotFound();
            }
            return View(expVM);
        }

        [HttpPost]
        public IActionResult UpdatePost(ExpenseVM expVM)
        {

            if (ModelState.IsValid)
            {
                _db.Expences.Update(expVM.Expense);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expVM);
            
        }
    }
}
