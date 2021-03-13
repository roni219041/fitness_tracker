using FitnessTracker.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Controllers
{
    public class WorkoutController : Controller
    {
        private readonly FitnessTrackerContext _db;
        public WorkoutController(FitnessTrackerContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult CreateWorkout()
        //{

        //}
    }
}
