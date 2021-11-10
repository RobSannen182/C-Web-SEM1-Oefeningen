using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCPXLParty2021.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPXLParty2021.Controllers
{
    public class AccountController : Controller
    {
        UserManager<IdentityUser> _userManager;

        public AccountController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }


        #region Register

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterViewModel user)
        {
            if (ModelState.IsValid)
            {
                var identityUser = new IdentityUser { UserName = user.UserName, Email = user.Email };
                await _userManager.CreateAsync(identityUser, user.Password);
                return View("Login");
            }
            return View();
        }
        #endregion

        # region login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel user)
        {
            return View();
        }
        #endregion
    }
}
