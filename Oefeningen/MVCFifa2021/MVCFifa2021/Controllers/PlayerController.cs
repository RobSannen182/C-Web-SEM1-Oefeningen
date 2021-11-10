using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCFifa2021.Data;
using MVCFifa2021.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFifa2021.Controllers
{
    public class PlayerController : Controller
    {
        private IWebHostEnvironment _environment;
        private ApplicationDbContext _context;

        public PlayerController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _environment = environment;
            _context = context;
        }
        
        public IActionResult Index()
        {
            var players = _context.Players;
            return View(players);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var player = new NewPlayer();
            ViewData["TeamId"] = new SelectList(_context.Teams, "TeamId", "TeamName");
            return View(player);
        }

        [HttpPost]
        public IActionResult Create(NewPlayer player)
        {
            if (ModelState.IsValid)
            {
                AddPlayer((NewPlayer)player);
                return RedirectToAction("Index");
            }
            return View(player);
        }

        private void AddPlayer(NewPlayer player)
        {
            Player p = (Player)player;
            _context.Players.Add(p);
            _context.SaveChanges();
            var tp = new TeamPlayer();
            tp.PlayerId = p.PlayerId;
            tp.TeamId = player.TeamId;
            tp.StartDate = DateTime.Now;
            _context.TeamPlayer.Add(tp);
            _context.SaveChanges();
        }
         
        public IActionResult Details(int id)
        {
            var player = _context.Players.Where(x => x.PlayerId == id).FirstOrDefault();
            var path = _environment.WebRootPath;
            var file = Path.Combine($"{path}\\images", player.ImageLink);
            var fileExist = System.IO.File.Exists(file);
            ViewBag.FileExist = fileExist;
            return View(player);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var player = _context.Players.Where(x => x.PlayerId == id).FirstOrDefault();
            return View(player);
        }
        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            var player = _context.Players.Where(x => x.PlayerId == id).FirstOrDefault();
            _context.Players.Remove(player);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var player = _context.Players.Where(x => x.PlayerId == id).FirstOrDefault();
            return View(player);
        }
        [HttpPost]
        public IActionResult Edit(Player player)
        {
            if (ModelState.IsValid)
            {
                UpdatePlayer(player);
                return RedirectToAction("Index");
            }
            return View(player);
        }
        private void UpdatePlayer(Player player)
        {
            _context.Players.Update(player);
            _context.SaveChanges();
        }
    }
}
