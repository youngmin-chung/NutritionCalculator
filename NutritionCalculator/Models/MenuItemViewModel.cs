using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionCalculator.Models
{
    public class MenuItemViewModel
    {
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<MenuItem> MenuItems { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
        public int Qty { get; set; }
        public int Calories { get; set; }
        public int Carbohydrate { get; set; }
        public string Category { get; set; }
        public int Cholesterol { get; set; }
        public decimal Fat { get; set; }
        public int Fibre { get; set; }
        public int Item { get; set; }
        public int Protein { get; set; }
        public int Sodium { get; set; }
        public decimal SFAT { get; set; }
        public int SGR { get; set; }
        public decimal TFAT { get; set; }
    }
}
