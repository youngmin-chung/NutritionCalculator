using System.Collections.Generic;
using System.Linq;

namespace NutritionCalculator.Models
{
    public class CategoryModel
    {
        private AppDbContext _db;
        public CategoryModel(AppDbContext ctx)
        {
            _db = ctx;
        }
        //receive an instance of the Context class and use it to return the data for all of the Category rows in the database in a method
        public List<Category> GetAll()
        {
            return _db.Categories.ToList<Category>();
        }
    }
}
