using FitnessTracker.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessTracker.Controllers
{
    public class MakingExerController : Controller
    {
        private readonly FitnessTrackerContext _db;
        public MakingExerController(FitnessTrackerContext db)
        {
            _db = db;
        }
       
        public IActionResult Index()
        { 
            var bodyparts = _db.BodyParts.ToList();
            var categories = _db.Categories.ToList();
            ViewBag.BodyParts = bodyparts;
            ViewBag.Categories = categories;         
            return View();
        }
              
        public IActionResult CreateExercise(Models.Excercise excercise) 
        {            
            _db.Excercises.Add(excercise);
            _db.SaveChanges();            
            return RedirectToAction("Index", "MakingExer");
        }
    }
}
