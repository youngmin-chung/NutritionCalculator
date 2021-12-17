using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionCalculator.Models
{
    public class MenuItemViewModel
    {
        public string CategoryName { get; set; }
        public IEnumerable<MenuItem> MenuItems { get; set; }
    }
}
