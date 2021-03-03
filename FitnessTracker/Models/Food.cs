using System;
using System.Collections.Generic;

#nullable disable

namespace FitnessTracker.Models
{
    public partial class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Calories { get; set; }
        public int Fat { get; set; }
        public int Protein { get; set; }
        public int Carbohydrates { get; set; }
        public int? UserId { get; set; }

        public virtual User User { get; set; }
    }
}
