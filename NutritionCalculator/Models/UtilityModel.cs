using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionCalculator.Models
{
    public class UtilityModel
    {
        private AppDbContext _db;
        public UtilityModel(AppDbContext context)
        {
            _db = context;
        }

        public bool loadNutritionTables(string stringJson)
        {
            bool categoriesLoaded = false;
            bool menuItemsLoaded = false;
            try
            {
                dynamic objectJson = Newtonsoft.Json.JsonConvert.DeserializeObject(stringJson);
                categoriesLoaded = loadCategories(objectJson);
                menuItemsLoaded = loadMenuItems(objectJson);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return categoriesLoaded && menuItemsLoaded;
        }

        private bool loadCategories(dynamic objectJson)
        {
            bool loadedCategories = false;
            try
            {
                // clear out the old rows
                _db.Categories.RemoveRange(_db.Categories);
                _db.SaveChanges();
                List<String> menu = new List<String>();
                foreach (var node in objectJson)
                {
                    menu.Add(Convert.ToString(node["category"]));
                }
                // distinct will remove duplicates before we insert them into the db
                IEnumerable<String> categories = menu.Distinct<String>();
                foreach (string category in categories)
                {
                    Category newCategory = new Category();
                    newCategory.Name = category;
                    _db.Categories.Add(newCategory);
                    _db.SaveChanges();
                }
                loadedCategories = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error - " + ex.Message);
            }
            return loadedCategories;

        }
        private bool loadMenuItems(dynamic objectJson)
        {
            bool loadedItems = false;
            try
            {
                List<Category> categories = _db.Categories.ToList();
                // clear out the old
                _db.MenuItems.RemoveRange(_db.MenuItems);
                // save and changes
                _db.SaveChanges();
                foreach (var node in objectJson)
                {
                    MenuItem item = new MenuItem();
                    item.Calories = Convert.ToInt32(node["calories"].Value);
                    item.Carbohydrate = Convert.ToInt32(node["carbohydrate"].Value);
                    item.Cholesterol = Convert.ToInt32(node["cholesterol"].Value);
                    item.Fat = Convert.ToSingle(node["fat"].Value);
                    item.Fibre = Convert.ToInt32(node["fibre"].Value);
                    item.Protein = Convert.ToInt32(node["protein"].Value);
                    item.Sodium = Convert.ToInt32(node["sodium"].Value);
                    item.Description = Convert.ToString(node["item"]);
                    string cat = Convert.ToString(node["category"].Value);
                    // add the FK here
                    foreach (Category category in categories)
                    {
                        if (category.Name == cat)
                            item.Category = category;
                    }
                    // add new value
                    _db.MenuItems.Add(item);

                    _db.SaveChanges();
                }
                loadedItems = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error - " + ex.Message);
            }
            return loadedItems;
        }

    }
}
