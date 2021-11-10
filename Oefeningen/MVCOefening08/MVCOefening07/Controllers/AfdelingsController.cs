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
    public class AfdelingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AfdelingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Afdelings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Afdelingen.ToListAsync());
        }

        // GET: Afdelings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var afdeling = await _context.Afdelingen
                .FirstOrDefaultAsync(m => m.AfdelingId == id);
            if (afdeling == null)
            {
                return NotFound();
            }

            return View(afdeling);
        }

        // GET: Afdelings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Afdelings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AfdelingId,AfdelingNaam")] Afdeling afdeling)
        {
            if (ModelState.IsValid)
            {
                _context.Add(afdeling);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(afdeling);
        }

        // GET: Afdelings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var afdeling = await _context.Afdelingen.FindAsync(id);
            if (afdeling == null)
            {
                return NotFound();
            }
            return View(afdeling);
        }

        // POST: Afdelings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AfdelingId,AfdelingNaam")] Afdeling afdeling)
        {
            if (id != afdeling.AfdelingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(afdeling);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AfdelingExists(afdeling.AfdelingId))
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
            return View(afdeling);
        }

        // GET: Afdelings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var afdeling = await _context.Afdelingen
                .FirstOrDefaultAsync(m => m.AfdelingId == id);
            if (afdeling == null)
            {
                return NotFound();
            }

            return View(afdeling);
        }

        // POST: Afdelings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var afdeling = await _context.Afdelingen.FindAsync(id);
            _context.Afdelingen.Remove(afdeling);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AfdelingExists(int id)
        {
            return _context.Afdelingen.Any(e => e.AfdelingId == id);
        }
    }
}
