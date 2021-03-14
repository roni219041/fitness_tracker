using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessTracker.Data;
using FitnessTracker.Migrations;
using FitnessTracker.Models;
using FitnessTracker.ViewModels;

namespace FitnessTracker.Controllers
{
    public class FoodController : Controller
    {
        protected FitnessTrackerDBContext _db;
        public FoodController(FitnessTrackerDBContext context)
        {
            _db = context;
        }
        public IActionResult FoodHistory()
        {
            FoodHistoryViewModel foodData = new FoodHistoryViewModel()
            {
                foods = GetAllUserFoods()
            };
            return View(foodData);
        }

        public List<FoodDataViewModel> GetAllUserFoods()
        {
            var user = _db.Users.FirstOrDefault(u => User.Identity.Name == u.UserName);
            List<Food> userFoods = _db.Foods.Where(f => f.UserId == user.Id).ToList();
            userFoods = userFoods.OrderByDescending(f => f.DateAdded).ToList();
            var foodData = new List<FoodDataViewModel>();
            foreach (var userFood in userFoods)
            {
                foodData.Add(new FoodDataViewModel()
                {
                    Name = userFood.Name,
                    DateAdded = userFood.DateAdded,
                    Calories = userFood.Calories,
                    Carbohydrates = userFood.Carbohydrates,
                    Fat = userFood.Fat,
                    Id = userFood.Id,
                    Protein = userFood.Protein,
                    User = userFood.User,
                    UserId = userFood.UserId
                });
            }
            return foodData;
        }
    }
}
