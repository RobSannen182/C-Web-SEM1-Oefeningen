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
    public class InschrijvingController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly GebruikersRepo _repo;

        public InschrijvingController(ApplicationDbContext context)
        {
            _context = context;
            _repo = new GebruikersRepo(_context);
        }

        // GET: Inschrijving
        public async Task<IActionResult> Index(string vakNaam, string student)
        {
            var applicationDbContext = _context.Inschrijvingen
                .Include(a => a.AcademieJaar)
                .Include(s => s.Student)
                .ThenInclude(s => s.Gebruiker)
                .Include(vl => vl.VakLector)
                .ThenInclude(l => l.Lector)
                .ThenInclude(l => l.Gebruiker)
                .Include(v => v.VakLector)
                .ThenInclude(v => v.Vak)
                .OrderBy(v => v.Student.Gebruiker.Naam);
                
            if (vakNaam == null)
            {
                if (student != null)
                {
                    ViewData["Cursus"] = "Per Student";
                    return View(await applicationDbContext
                        .Where(x => x.Student.Gebruiker.Naam.ToLower().Contains(student.ToLower()) || x.Student.Gebruiker.Voornaam.ToLower().Contains(student.ToLower()))
                        .OrderBy(x => x.Student.Gebruiker.Naam)
                        .ToListAsync());
                }
                ViewData["Cursus"] = "Inschrijvingen";
                return View(await applicationDbContext
                    .OrderBy(x => x.VakLector.Vak.VakNaam)
                    .ToListAsync());
            }
            else
            {
                ViewData["Cursus"] = vakNaam;
                return View(await applicationDbContext
                    .Where(x => x.VakLector.Vak.VakNaam == vakNaam)
                    .ToListAsync());
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(string naam)
        {
            return RedirectToAction(nameof(Index), new { student = naam });
        }

        // GET: Inschrijving/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inschrijving = await _context.Inschrijvingen
                .Include(i => i.AcademieJaar)
                .Include(i => i.Student)
                .ThenInclude(i => i.Gebruiker)
                .Include(i => i.VakLector)
                .ThenInclude(i => i.Lector)
                .ThenInclude(i => i.Gebruiker)
                .Include(i => i.VakLector)
                .ThenInclude(i => i.Vak)
                .FirstOrDefaultAsync(m => m.InschrijvingId == id);
            if (inschrijving == null)
            {
                return NotFound();
            }

            return View(inschrijving);
        }

        
        public IActionResult Create(InschrijvingInfo inschrijvingInfo, int vakId)
        {
            int count = _context.Vakken.Count() < 1 ? 1 : 0;
            count = _context.Studenten.Count() < 1 ? 2 : count ;
            count = _context.Studenten.Count() < 1 && _context.Vakken.Count() < 1 ? 3 : count ;
            ViewBag.Count = count;
            ViewData["VakId"] = new SelectList(_context.Vakken, "VakId", "VakNaam");
            ViewData["StudentFullName"] = new SelectList(_repo.GetStudentNaamIdList(), "StudentId", "FullName");
            if (vakId > 0)
            {
                ViewData["VakNaam"] = _context.Vakken.Where(x => x.VakId == vakId).Select(x => x.VakNaam).FirstOrDefault();
                ViewData["VakId"] = vakId;
                ViewData["StudNaam"] = _repo.GetStudentNaamIdList().Where(x => x.StudentId == inschrijvingInfo.StudentId).Select(x => x.FullName).FirstOrDefault();
                ViewData["StudId"] = inschrijvingInfo.StudentId;
                ViewData["LectorId"] = new SelectList(_repo.GetLectorNaamIdListByVak(vakId), "LectorId", "FullName");
                ViewData["AcademieJaarId"] = new SelectList(_context.AcademieJaren, "AcademieJaarId", "StartDatum");
                return View(inschrijvingInfo);
            }
            
            return View();
        }

        // POST: Inschrijving/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateKeuze([Bind("VakId, StudentId")] InschrijvingInfo inschrijvingInfo)
        {
            return RedirectToAction(nameof(Create), new {vakId = inschrijvingInfo.VakId, studentId = inschrijvingInfo.StudentId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VakId,StudentId,LectorId,AcademieJaarId")] InschrijvingInfo inschrijvingInfo)
        {
            if (ModelState.IsValid)
            {
                Inschrijving i = new Inschrijving();
                i.StudentId = inschrijvingInfo.StudentId;
                i.AcademieJaarId = inschrijvingInfo.AcademieJaarId;
                i.VakLectorId = _context.VakLectoren
                    .Where(x => x.LectorId == inschrijvingInfo.LectorId && x.VakId == inschrijvingInfo.VakId)
                    .Select(x => x.VaklectorId).FirstOrDefault();
                _context.Add(i);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["AcademieJaarId"] = new SelectList(_context.AcademieJaren, "AcademieJaarId", "AcademieJaarId", inschrijving.AcademieJaarId);
            //ViewData["StudentId"] = new SelectList(_context.Studenten, "StudentId", "StudentId", inschrijving.StudentId);
            //ViewData["VakLectorId"] = new SelectList(_context.VakLectoren, "VaklectorId", "VaklectorId", inschrijving.VakLectorId);
            return View(inschrijvingInfo);
        }

        // GET: Inschrijving/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inschrijving = await _context.Inschrijvingen
                .Include(x => x.Student)
                .ThenInclude(x => x.Gebruiker)
                .Include(x => x.VakLector)
                .ThenInclude(x => x.Lector)
                .ThenInclude(x => x.Gebruiker)
                .Include(x => x.VakLector)
                .ThenInclude(x => x.Vak)
                .Include(x => x.AcademieJaar)
                .Where(x => x.InschrijvingId == id).FirstOrDefaultAsync();
            if (inschrijving == null)
            {
                return NotFound();
            }
            var inschrijvingInfo = new InschrijvingInfo(inschrijving);
            ViewData["LectorId"] = new SelectList(_repo.GetVakLectorNaamListByVak(inschrijving.VakLector.VakId), "VakLectorId", "VLectorFullName");
            ViewData["AcademieJaarId"] = inschrijving.AcademieJaarId;
            ViewData["StudId"] = inschrijving.StudentId;
            ViewData["InschrijvingId"] = inschrijving.InschrijvingId;
            return View(inschrijvingInfo);
        }

        // POST: Inschrijving/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InschrijvingId,StudentId,VakLectorId,AcademieJaarId")] InschrijvingInfo inschrijvingInfo)
        {
            if (id != inschrijvingInfo.InschrijvingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Inschrijving i = new Inschrijving();
                    i.InschrijvingId = inschrijvingInfo.InschrijvingId;
                    i.StudentId = inschrijvingInfo.StudentId;
                    i.AcademieJaarId = inschrijvingInfo.AcademieJaarId;
                    i.VakLectorId = inschrijvingInfo.VakLectorId;
                    _context.Update(i);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InschrijvingExists(inschrijvingInfo.InschrijvingId))
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
            ViewData["AcademieJaarId"] = new SelectList(_context.AcademieJaren, "AcademieJaarId", "AcademieJaarId", inschrijvingInfo.AcademieJaarId);
            ViewData["StudentId"] = new SelectList(_context.Studenten, "StudentId", "StudentId", inschrijvingInfo.StudentId);
            ViewData["VakLectorId"] = new SelectList(_context.VakLectoren, "VaklectorId", "VaklectorId", inschrijvingInfo.VakLectorId);
            return View(inschrijvingInfo);
        }

        // GET: Inschrijving/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inschrijving = await _context.Inschrijvingen
                .Include(i => i.AcademieJaar)
                .Include(i => i.Student)
                .ThenInclude(i => i.Gebruiker)
                .Include(i => i.VakLector)
                .ThenInclude(i => i.Lector)
                .ThenInclude(i => i.Gebruiker)
                .Include(i => i.VakLector)
                .ThenInclude(i => i.Vak)
                .FirstOrDefaultAsync(m => m.InschrijvingId == id);
            if (inschrijving == null)
            {
                return NotFound();
            }

            return View(inschrijving);
        }

        // POST: Inschrijving/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inschrijving = await _context.Inschrijvingen.FindAsync(id);
            _context.Inschrijvingen.Remove(inschrijving);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InschrijvingExists(int id)
        {
            return _context.Inschrijvingen.Any(e => e.InschrijvingId == id);
        }
    }
}
