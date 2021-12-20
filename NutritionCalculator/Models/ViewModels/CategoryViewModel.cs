using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace NutritionCalculator.Models
{
    public class CategoryViewModel
    {
        public CategoryViewModel() { }
        public string CategoryName { get; set; }
        public int Id { get; set; }
        public List<Category> Categories { get; set; }
        public IEnumerable<SelectListItem> GetCategories()
        {
            return Categories.Select(category => new SelectListItem
            {
                Text = category.Name, Value = category.Id.ToString()
            });
        }
        // to contain the child MenuItems directly in the parent
        public IEnumerable<MenuItem> MenuItems { get; set; }
    }
}
