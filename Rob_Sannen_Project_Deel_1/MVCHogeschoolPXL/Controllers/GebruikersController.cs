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
    public class GebruikersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private GebruikersRepo _repo;

        public GebruikersController(ApplicationDbContext context)
        {
            _context = context;
            _repo = new GebruikersRepo(_context);
        }

        // GET: Gebruikers
        public IActionResult Index(string functie)
        {
            var gebruikersList =  _repo.GetGebruikersInfoList(functie).OrderBy(x => x.Naam);
            string f = functie == null ? "Gebruikers" : $"{functie}en";
            ViewData["Titel"] = f;
            return View(gebruikersList);
        }

        
        // GET: Gebruikers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gebruiker = await _context.Gebruikers
                .FirstOrDefaultAsync(m => m.GebruikerId == id);
            if (gebruiker == null)
            {
                return NotFound();
            }
            GebruikerInfo gi = new GebruikerInfo(_context, gebruiker);
            return View(gi);
        }

        // GET: Gebruikers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gebruikers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GebruikerId,Naam,Voornaam,Email,Functie")] GebruikerInfo gebruikerInfo)
        {
            Gebruiker g = new Gebruiker { Naam = gebruikerInfo.Naam, Voornaam = gebruikerInfo.Voornaam, Email = gebruikerInfo.Email };
            if (ModelState.IsValid)
            {
                _context.Gebruikers.Add(g);
                await _context.SaveChangesAsync();
                if (gebruikerInfo.Functie == "Lector")
                {
                    var gebruikerId = await _context.Gebruikers.Where(x => x.Naam == gebruikerInfo.Naam).Select(x => x.GebruikerId).FirstOrDefaultAsync();
                    var lector = new Lector { GebruikerId = gebruikerId };
                    _context.Lectoren.Add(lector);
                    await _context.SaveChangesAsync();
                }
                if (gebruikerInfo.Functie == "Student")
                {
                    var gebruikerId = await _context.Gebruikers.Where(x => x.Naam == gebruikerInfo.Naam).Select(x => x.GebruikerId).FirstOrDefaultAsync();
                    var student = new Student { GebruikerId = gebruikerId };
                    _context.Studenten.Add(student);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(gebruikerInfo);
        }

        // GET: Gebruikers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gebruiker = await _context.Gebruikers.FindAsync(id);
            if (gebruiker == null)
            {
                return NotFound();
            }
            return View(gebruiker);
        }

        // POST: Gebruikers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GebruikerId,Naam,Voornaam,Email")] Gebruiker gebruiker)
        {
            if (id != gebruiker.GebruikerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gebruiker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GebruikerExists(gebruiker.GebruikerId))
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
            return View(gebruiker);
        }

        // GET: Gebruikers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gebruiker = await _context.Gebruikers
                .FirstOrDefaultAsync(m => m.GebruikerId == id);
            if (gebruiker == null)
            {
                return NotFound();
            }

            return View(gebruiker);
        }

        // POST: Gebruikers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gebruiker = await _context.Gebruikers.FindAsync(id);
            _context.Gebruikers.Remove(gebruiker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GebruikerExists(int id)
        {
            return _context.Gebruikers.Any(e => e.GebruikerId == id);
        }
    }
}
