using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCHogeschoolPXL.Data;
using MVCHogeschoolPXL.Models;
using MVCHogeschoolPXL.ViewModels;

namespace MVCHogeschoolPXL.Controllers
{
    public class VakLectorController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly GebruikersRepo _repo;

        public VakLectorController(ApplicationDbContext context)
        {
            _context = context;
            _repo = new GebruikersRepo(_context);
        }

        // GET: VakLector
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.VakLectoren
                .Include(v => v.Lector)
                .ThenInclude(v => v.Gebruiker)
                .Include(v => v.Vak)
                .OrderBy(v => v.Vak.VakNaam);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: VakLector/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vakLector = await _context.VakLectoren
                .Include(v => v.Lector)
                .ThenInclude(v => v.Gebruiker)
                .Include(v => v.Vak)
                .FirstOrDefaultAsync(m => m.VaklectorId == id);
            if (vakLector == null)
            {
                return NotFound();
            }

            return View(vakLector);
        }

        // GET: VakLector/Create
        public IActionResult Create()
        {
            var lectorList = _repo.GetLectorNaamIdList();
            ViewData["LectorId"] = new SelectList(lectorList, "LectorId", "FullName");
            ViewData["VakId"] = new SelectList(_context.Vakken, "VakId", "VakNaam");
            
            return View();
        }

        // POST: VakLector/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VaklectorId,VakId,LectorId")] VakLector vakLector)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vakLector);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var lectorList = _repo.GetLectorNaamIdList();
            ViewData["LectorId"] = new SelectList(lectorList, "LectorId", "FullName");
            ViewData["VakId"] = new SelectList(_context.Vakken, "VakId", "VakNaam");
            return View(vakLector);
        }

        // GET: VakLector/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vakLector = await _context.VakLectoren.FindAsync(id);
            if (vakLector == null)
            {
                return NotFound();
            }
            var lectorList = _repo.GetLectorNaamIdList();
            ViewData["LectorId"] = new SelectList(lectorList, "LectorId", "FullName");
            ViewData["VakId"] = new SelectList(_context.Vakken, "VakId", "VakNaam");
            return View(vakLector);
        }

        // POST: VakLector/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VaklectorId,VakId,LectorId")] VakLector vakLector)
        {
            if (id != vakLector.VaklectorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vakLector);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VakLectorExists(vakLector.VaklectorId))
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
            var lectorList = _repo.GetLectorNaamIdList();
            ViewData["LectorId"] = new SelectList(lectorList, "LectorId", "FullName");
            ViewData["VakId"] = new SelectList(_context.Vakken, "VakId", "VakNaam");
            return View(vakLector);
        }

        // GET: VakLector/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vakLector = await _context.VakLectoren
                .Include(v => v.Lector)
                .ThenInclude(v => v.Gebruiker)
                .Include(v => v.Vak)
                .FirstOrDefaultAsync(m => m.VaklectorId == id);
            if (vakLector == null)
            {
                return NotFound();
            }

            return View(vakLector);
        }

        // POST: VakLector/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vakLector = await _context.VakLectoren.FindAsync(id);
            _context.VakLectoren.Remove(vakLector);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VakLectorExists(int id)
        {
            return _context.VakLectoren.Any(e => e.VaklectorId == id);
        }
    }
}
