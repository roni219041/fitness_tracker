using System;
using System.Collections.Generic;

#nullable disable

namespace FitnessTracker.Models
{
    public partial class User
    {
        public User()
        {
            Excercises = new HashSet<Excercise>();
            Foods = new HashSet<Food>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }

        public virtual ICollection<Excercise> Excercises { get; set; }
        public virtual ICollection<Food> Foods { get; set; }
    }
}
