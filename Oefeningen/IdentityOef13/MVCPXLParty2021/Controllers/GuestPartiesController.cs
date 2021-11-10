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
    public class GuestPartiesController : Controller
    {
        private readonly PartyDbContext _context;

        public GuestPartiesController(PartyDbContext context)
        {
            _context = context;
        }

        // GET: GuestParties
        public async Task<IActionResult> Index()
        {
            var partyDbContext = _context.GuestParties.Include(g => g.Guest).Include(g => g.Party);
            return View(await partyDbContext.ToListAsync());
        }

        // GET: GuestParties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guestParty = await _context.GuestParties
                .Include(g => g.Guest)
                .Include(g => g.Party)
                .FirstOrDefaultAsync(m => m.GuestPartyId == id);
            if (guestParty == null)
            {
                return NotFound();
            }

            return View(guestParty);
        }

        // GET: GuestParties/Create
        public IActionResult Create()
        {
            ViewData["GuestId"] = new SelectList(_context.Guests, "GuestId", "GuestName");
            ViewData["PartyId"] = new SelectList(_context.Parties, "PartyId", "PartyName");
            return View();
        }

        // POST: GuestParties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GuestPartyId,GuestId,PartyId")] GuestParty guestParty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guestParty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GuestId"] = new SelectList(_context.Guests, "GuestId", "GuestName", guestParty.GuestId);
            ViewData["PartyId"] = new SelectList(_context.Parties, "PartyId", "PartyName", guestParty.PartyId);
            return View(guestParty);
        }

        // GET: GuestParties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guestParty = await _context.GuestParties.FindAsync(id);
            if (guestParty == null)
            {
                return NotFound();
            }
            ViewData["GuestId"] = new SelectList(_context.Guests, "GuestId", "GuestName", guestParty.GuestId);
            ViewData["PartyId"] = new SelectList(_context.Parties, "PartyId", "PartyName", guestParty.PartyId);
            return View(guestParty);
        }

        // POST: GuestParties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GuestPartyId,GuestId,PartyId")] GuestParty guestParty)
        {
            if (id != guestParty.GuestPartyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guestParty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuestPartyExists(guestParty.GuestPartyId))
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
            ViewData["GuestId"] = new SelectList(_context.Guests, "GuestId", "GuestName", guestParty.GuestId);
            ViewData["PartyId"] = new SelectList(_context.Parties, "PartyId", "PartyName", guestParty.PartyId);
            return View(guestParty);
        }

        // GET: GuestParties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guestParty = await _context.GuestParties
                .Include(g => g.Guest)
                .Include(g => g.Party)
                .FirstOrDefaultAsync(m => m.GuestPartyId == id);
            if (guestParty == null)
            {
                return NotFound();
            }

            return View(guestParty);
        }

        // POST: GuestParties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var guestParty = await _context.GuestParties.FindAsync(id);
            _context.GuestParties.Remove(guestParty);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuestPartyExists(int id)
        {
            return _context.GuestParties.Any(e => e.GuestPartyId == id);
        }
    }
}
