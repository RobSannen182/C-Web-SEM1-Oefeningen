using Microsoft.AspNetCore.Mvc;
using MVCFifa2021.Data;
using MVCFifa2021.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFifa2021.Controllers
{
    public class TeamController : Controller
    {
        ApplicationDbContext _context;
        public TeamController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var teams = _context.Teams;
            return View(teams);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var team = new Team();
            return View(team);
        }
        [HttpPost]
        public IActionResult Create(Team team)
        {
            if (ModelState.IsValid)
            {
                _context.Teams.Add(team);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(team);
        }
    }
}
