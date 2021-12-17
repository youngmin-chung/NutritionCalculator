using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionCalculator.Models
{
    public class MenuItemModel
    {
        private AppDbContext _db;
        public MenuItemModel(AppDbContext context)
        {
            _db = context;
        }
        public List<MenuItem> GetAll()
        {
            return _db.MenuItems.ToList();
        }
        public List<MenuItem> GetAllByCategory(int id)
        {
            return _db.MenuItems.Where(item => item.Category.Id == id).ToList();
        }
        public Category GetCategory(int id)
        {
            return _db.Categories.FirstOrDefault(category => category.Id == id);
        }
    }
}
