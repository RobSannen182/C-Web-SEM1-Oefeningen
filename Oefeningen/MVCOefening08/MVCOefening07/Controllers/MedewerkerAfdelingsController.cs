using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCOefening07.Data;
using MVCOefening07.Models;

namespace MVCOefening07.Controllers
{
    public class MedewerkerAfdelingsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public MedewerkerAfdelingsController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: MedewerkerAfdelings
        public async Task<IActionResult> Index()
        {
            return View(await _db.MedewerkerAfdeling.ToListAsync());
        }

        // GET: MedewerkerAfdelings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medewerkerAfdeling = await _db.MedewerkerAfdeling
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medewerkerAfdeling == null)
            {
                return NotFound();
            }

            return View(medewerkerAfdeling);
        }

        // GET: MedewerkerAfdelings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MedewerkerAfdelings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MedewerkerId,AfdelingId,StartDatum,EindDatum")] MedewerkerAfdeling medewerkerAfdeling)
        {
            //List<MedewerkerAfdeling> afdJ = _db.MedewerkerAfdeling.Where(afdM => afdM.MedewerkerId == medewerkerAfdeling.MedewerkerId).OrderBy(afdm => afdm.StartDatum).ToList();
            ////int i = 1;
            //bool faut = false;
            //bool startdatum = false;
            //int listLenght = afdJ.Count() - 1;
            //foreach (MedewerkerAfdeling med in afdJ)
            //{
            //    //if (med.EindDatum >= medewerkerAfdeling.StartDatum)
            //    //{
            //    //    // start datum niet goed
            //    // startdatum = true;
            //    //}
            //    //if (med.StartDatum <= medewerkerAfdeling.EindDatum)
            //    //{
            //    //    //eind datum niet juist 
            //    //}
            //    if (med.EindDatum >= medewerkerAfdeling.StartDatum && med.StartDatum <= medewerkerAfdeling.EindDatum)
            //    {
            //        faut = true;
            //    }

            //}
            //if (faut)
            //{
            //    ModelState.AddModelError("", "overlaping");
            //}




            List<MedewerkerAfdeling> afdJ = _db.MedewerkerAfdeling.Where(afdM => afdM.MedewerkerId == medewerkerAfdeling.MedewerkerId).OrderBy(afdm => afdm.StartDatum).ToList();
            //int i = 0;
            foreach (MedewerkerAfdeling med in afdJ)
            {
                if (med.EindDatum >= medewerkerAfdeling.StartDatum && med.StartDatum <= medewerkerAfdeling.EindDatum)
                {
                    ModelState.AddModelError("", "Medewerker was tijdens deze periode tewerkgesteld in een andere afdeling!");
                    break;
                }
                //i++;
            }



            //foreach (var record in _db.MedewerkerAfdeling)
            //{
            //    if (medewerkerAfdeling.StartDatum > record.StartDatum && medewerkerAfdeling.StartDatum < record.EindDatum)
            //    {
            //        ModelState.AddModelError(nameof(medewerkerAfdeling.StartDatum), "Medewerker was tijdens deze periode tewerkgesteld in een andere afdeling!");
            //        break;
            //    }
            //}
            //foreach (var record in _db.MedewerkerAfdeling)
            //{
            //    if (medewerkerAfdeling.EindDatum < record.EindDatum && medewerkerAfdeling.EindDatum > record.StartDatum)
            //    {
            //        ModelState.AddModelError(nameof(medewerkerAfdeling.EindDatum), "Medewerker was tijdens deze periode tewerkgesteld in een andere afdeling!");
            //        break;
            //    }
            //}




            //if (_db.MedewerkerAfdeling.Any(c => c.StartDatum < medewerkerAfdeling.StartDatum && c.EindDatum < medewerkerAfdeling.StartDatum))
            //{
            //    ModelState.AddModelError(nameof(medewerkerAfdeling.StartDatum), "Medewerker was tijdens deze periode tewerkgesteld in een andere afdeling!");
            //}
            //if (_db.MedewerkerAfdeling.Any(c => c.StartDatum > medewerkerAfdeling.EindDatum && c.EindDatum > medewerkerAfdeling.StartDatum))
            //{
            //    ModelState.AddModelError(nameof(medewerkerAfdeling.EindDatum), "Medewerker was tijdens deze periode tewerkgesteld in een andere afdeling!");
            //}

            if (ModelState.IsValid)
            {

                _db.Add(medewerkerAfdeling);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(medewerkerAfdeling);
            }
        }

        // GET: MedewerkerAfdelings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medewerkerAfdeling = await _db.MedewerkerAfdeling.FindAsync(id);
            if (medewerkerAfdeling == null)
            {
                return NotFound();
            }
            return View(medewerkerAfdeling);
        }

        // POST: MedewerkerAfdelings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MedewerkerId,AfdelingId,StartDatum,EindDatum")] MedewerkerAfdeling medewerkerAfdeling)
        {
            if (id != medewerkerAfdeling.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(medewerkerAfdeling);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedewerkerAfdelingExists(medewerkerAfdeling.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(medewerkerAfdeling);
        }

        // GET: MedewerkerAfdelings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medewerkerAfdeling = await _db.MedewerkerAfdeling
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medewerkerAfdeling == null)
            {
                return NotFound();
            }

            return View(medewerkerAfdeling);
        }

        // POST: MedewerkerAfdelings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medewerkerAfdeling = await _db.MedewerkerAfdeling.FindAsync(id);
            _db.MedewerkerAfdeling.Remove(medewerkerAfdeling);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedewerkerAfdelingExists(int id)
        {
            return _db.MedewerkerAfdeling.Any(e => e.Id == id);
        }
    }
}
