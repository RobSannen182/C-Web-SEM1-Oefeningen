using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCPXLParty2021.Data;
using MVCPXLParty2021.Models;

namespace MVCPXLParty2021.Controllers
{
    public class PartiesController : Controller
    {
        private readonly PartyDbContext _context;

        public PartiesController(PartyDbContext context)
        {
            _context = context;
        }

        // GET: Parties
        public async Task<IActionResult> Index()
        {
            var partyDbContext = _context.Parties.Include(p => p.Location).OrderBy(p => p.PartyDate);
            return View(await partyDbContext.ToListAsync());
        }

        // GET: PartiesPerLocatie
        public IActionResult PerLocatie(string locatie)
        {
            return View(_context.Parties.Where(x => x.Location.City == locatie).Include(x => x.Location).OrderBy(x => x.PartyDate));
        }

        // GET: Parties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var party = await _context.Parties
                .Include(p => p.Location)
                .FirstOrDefaultAsync(m => m.PartyId == id);
            if (party == null)
            {
                return NotFound();
            }

            return View(party);
        }

        // GET: Parties/Create
        public IActionResult Create()
        {
            ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "City");
            return View();
        }

        // POST: Parties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PartyId,PartyName,PartyDate,LocationId")] Party party)
        {
            if (ModelState.IsValid)
            {
                if (_context.Parties.Any(x => x.LocationId == party.LocationId && x.PartyDate.DayOfYear == party.PartyDate.DayOfYear))
                {
                    ModelState.AddModelError(nameof(party.PartyDate), "Er vindt op deze dag al een feest plaats op deze locatie. Kies een andere dag.");
                    ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "City", party.LocationId);
                    return View(party);
                }
                //foreach (var row in _context.Parties)
                //{
                //    if (row.LocationId == party.LocationId && row.PartyDate == party.PartyDate)
                //    {
                //        ModelState.AddModelError(nameof(party.PartyDate), "Er vindt op deze dag al een feest plaats op deze locatie. Kies een andere dag.");
                //        ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "City", party.LocationId);
                //        return View(party);
                //    }
                //}

                _context.Add(party);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "City", party.LocationId);
            return View(party);
        }

        // GET: Parties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var party = await _context.Parties.FindAsync(id);
            if (party == null)
            {
                return NotFound();
            }
            ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "City", party.LocationId);
            return View(party);
        }

        // POST: Parties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PartyId,PartyName,PartyDate,LocationId")] Party party)
        {
            if (id != party.PartyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(party);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartyExists(party.PartyId))
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
            ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "City", party.LocationId);
            return View(party);
        }

        // GET: Parties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var party = await _context.Parties
                .Include(p => p.Location)
                .FirstOrDefaultAsync(m => m.PartyId == id);
            if (party == null)
            {
                return NotFound();
            }

            return View(party);
        }

        // POST: Parties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var party = await _context.Parties.FindAsync(id);
            _context.Parties.Remove(party);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartyExists(int id)
        {
            return _context.Parties.Any(e => e.PartyId == id);
        }
    }
}
