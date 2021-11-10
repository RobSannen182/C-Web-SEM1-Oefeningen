using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCVoertuig.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCVoertuig.Controllers
{
    public class AccountController : Controller
    {
        UserManager<IdentityUser> _userManager;
        SignInManager<IdentityUser> _signInManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        #region login

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var identityUser = await _userManager.FindByEmailAsync(user.Email);
                    if (identityUser != null)
                    {
                        return View("LoginCompleted", identityUser);
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid login attempt.");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attempt.");
                }
            }
            return View();
        }
        #endregion

        #region register
        public IActionResult Register()
        {
            return View();
        }

        // PRIVATE METHOD => GEEN ACTION!!!!
        private async Task<RegisterResult> RegisterUserAsync(RegisterViewModel user)
        {
            var registerResult = new RegisterResult();
            var identityUser = new IdentityUser { UserName = user.Email, Email = user.Email };
            var result = await _userManager.CreateAsync(identityUser, user.Password);
            if (result.Succeeded)
            {
                var createdUser = new CreatedUser { CreationDate = DateTime.Now, IdentityUser = identityUser };
                registerResult.Succeeded = true;
                registerResult.CreatedUser = createdUser;
            }
            else
            {
                if (result.Errors.Count() > 0)
                {
                    foreach (var error in result.Errors)
                    {
                        registerResult.Errors.Add(error.Description);
                    }
                }
                else
                {
                    registerResult.Errors.Add("Er is een probleem om de gebruiker te registreren");
                }
            }
            return registerResult;
        }

        // METHOD => GEEN ACTION

        private async Task<bool> UserExistAsync(RegisterViewModel user)
        {
            bool userExist = false;
            var result = await _userManager.FindByEmailAsync(user.Email);
            if (result != null)
                userExist = true;
            return userExist;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterViewModel user)
        {
            if (ModelState.IsValid) 
            {
                //ONDERSTAANDE CODE IS VERVANGEN DOOR DATA ANNOTATION MODEL VALIDATION IN MODEL(viewmodels.RegisterViewModel)
                //if (!user.Password.Equals(user.ConfirmPasword))
                //{
                //    ModelState.AddModelError("", "Wachtwoord moet identiek zijn");
                //    return View(user);
                //}
                //else
                //{
                if (await UserExistAsync(user))
                {
                    ModelState.AddModelError("Email", "Email adres is al geregistreerd!");
                    return View(user);
                }
                var result = await RegisterUserAsync(user);
                if (result.Succeeded)
                {
                    return View("RegistrationCompleted", result.CreatedUser);
                }
                else
                {
                    foreach (string error in result.Errors)
                        ModelState.AddModelError("", error);
                    return View(user);
                }
                //}
            }
            return View(user);
        }
        #endregion

        #region Logout

        public async Task<IActionResult> LogoutAsync()
        {
            await _signInManager.SignOutAsync();
            return View("LogoutCompleted");
        }
        #endregion

    }
}
