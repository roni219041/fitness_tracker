using DocuSign.eSign.Model;
using FitnessTracker.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Controllers
{
    public class RegisterController : Controller
    {
        private readonly FitnessTrackerContext _db;
        public RegisterController(FitnessTrackerContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateUser(Models.User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();

            return RedirectToAction("Index", "Register");
        }
    }
}
