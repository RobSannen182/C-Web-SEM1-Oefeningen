using Microsoft.AspNetCore.Mvc;
using MVCPartyInvites.Data;
using MVCPartyInvites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPartyInvites.Controllers
{
    public class GastController : Controller
    {
        public IActionResult Index()
        {
            Gast g = new Gast();
            return View(g);
        }
        [HttpPost]
        public IActionResult Reservatie(Gast g)
        {
            LocalData.GastList.Add(g);
            return RedirectToAction("Index", "Home");
        }
    }
}
