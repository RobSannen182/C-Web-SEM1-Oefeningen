using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCVoertuig.Data;
using MVCVoertuig.Models;

namespace MVCVoertuig.Controllers
{
    public class VoertuigenController : Controller
    {
        private readonly VoertuigDbContext _context;

        public VoertuigenController(VoertuigDbContext context)
        {
            _context = context;
        }

        // GET: Voertuigen
        public async Task<IActionResult> Index()
        {
            return View(await _context.Voertuigen.ToListAsync());
        }

        public IActionResult Merk(string merk)
        {
            ViewBag.Merk = merk;
            return View(_context.Voertuigen.Where(x => x.Merk == merk));
        }

        // GET: Voertuigen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voertuig = await _context.Voertuigen
                .FirstOrDefaultAsync(m => m.VoertuigId == id);
            if (voertuig == null)
            {
                return NotFound();
            }

            return View(voertuig);
        }

        // GET: Voertuigen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Voertuigen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VoertuigId,Merk,MerkType,Bouwjaar,Km,VerkoopPrijs,AanwezigInShowroom")] Voertuig voertuig)
        {
            if (ModelState.IsValid)
            {
                _context.Add(voertuig);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(voertuig);
        }

        // GET: Voertuigen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voertuig = await _context.Voertuigen.FindAsync(id);
            if (voertuig == null)
            {
                return NotFound();
            }
            return View(voertuig);
        }

        // POST: Voertuigen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VoertuigId,Merk,MerkType,Bouwjaar,Km,VerkoopPrijs,AanwezigInShowroom")] Voertuig voertuig)
        {
            if (id != voertuig.VoertuigId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(voertuig);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoertuigExists(voertuig.VoertuigId))
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
            return View(voertuig);
        }

        // GET: Voertuigen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voertuig = await _context.Voertuigen
                .FirstOrDefaultAsync(m => m.VoertuigId == id);
            if (voertuig == null)
            {
                return NotFound();
            }

            return View(voertuig);
        }

        // POST: Voertuigen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var voertuig = await _context.Voertuigen.FindAsync(id);
            _context.Voertuigen.Remove(voertuig);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VoertuigExists(int id)
        {
            return _context.Voertuigen.Any(e => e.VoertuigId == id);
        }
    }
}
