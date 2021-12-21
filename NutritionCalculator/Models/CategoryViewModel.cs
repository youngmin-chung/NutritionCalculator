using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace NutritionCalculator.Models
{
    public class CategoryViewModel
    {
        private List<Category> _categories;
        public CategoryViewModel() { }
        public string CategoryName { get; set; }
        public int Id { get; set; }
        // to contain the child MenuItems directly in the parent
        public IEnumerable<MenuItem> MenuItems { get; set; }
        public int CategoryId { get; set; }
        public int Qty { get; set; }
        public IEnumerable<SelectListItem> GetCategories()
        {
            return _categories.Select(category => new SelectListItem
            {
                Text = category.Name, Value = category.Id.ToString()
            });
        }

        public void SetCategories(List<Category> cats)
        {
            _categories = cats;
        }
    }
}
