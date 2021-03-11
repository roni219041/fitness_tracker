using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessTracker.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Controllers
{
    public class DashboardController : Controller
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        protected FitnessTrackerDBContext _db;
        public DashboardController(FitnessTrackerDBContext context, SignInManager<IdentityUser> _signInManager, UserManager<IdentityUser> _userManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            _db = context;
        }
        public IActionResult RenderMain()
        {
            return View("GeneralPage");
        }

        public double? GetMaintainCalories()
        {
            string username = User.Identity.Name;
            var user = _db.Users.FirstOrDefault(x => x.UserName == username);
            //calculate BMR
            double defaultActivityLevel = 1.4;
            double? BMR = null;
            if (user.Gender == "Male")
            {
                BMR = (10 * user.Weight / 1 + 6.25 * user.Height / 1 - 5 * user.Age / 1 + 5);
            }
            else
            {
                BMR = (10 * user.Weight / 1 + 6.25 * user.Height / 1 - 5 * user.Age / 1 - 161);
            }

            BMR *= defaultActivityLevel;

            return BMR;
        }
    }
}
