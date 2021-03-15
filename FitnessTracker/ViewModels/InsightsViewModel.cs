using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FitnessTracker.ViewModels
{
    public class InsightsViewModel
    {
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [Required] public string Gender { get; set; }
        [Required] public List<SelectListItem> PersonalFoods { get; set; }

        //[Required] public double BMR = 
    }
}
