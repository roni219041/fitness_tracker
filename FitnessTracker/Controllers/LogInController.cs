using FitnessTracker.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessTracker.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace FitnessTracker.Controllers
{
    public class LogInController : Controller
    {
        private readonly FitnessTrackerContext _db;
        private readonly SignInManager<IdentityUser> signInManager;

        public LogInController(FitnessTrackerContext db, SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LogIn(string username)
        {

            return RedirectToAction("Index", "LogIn");
        }

        //[HttpPost]
        //public async Task<IActionResult> Login(LoginViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = await signInManager.PasswordSignInAsync(
        //            model.Email, model.Password, model.RememberMe, false);

        //        if (result.Succeeded)
        //        {
        //            return RedirectToAction("Index", "Home");
        //        }

        //        ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
        //    }

        //    return View(model);
        //}
    }
}
