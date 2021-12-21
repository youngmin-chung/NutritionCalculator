using Microsoft.AspNetCore.Mvc;
using NutritionCalculator.Models;
using NutritionCalculator.Utils;
using System;
using System.Collections.Generic;

namespace NutritionCalculator.Controllers
{
    public class CategoryController :Controller
    {
        AppDbContext _db;
        public CategoryController(AppDbContext context)
        {
            _db = context;
        }
        /* How the middleware injects a context instance into the controller via the controller's constructor.
         * The controller in turn passes the context instance to the model.
         * Loads the ViewModel's Categories property with the List of Category instances returned from the model's GetAll method
         * The controller returns the populated Viewmodel to the actual View. \
         * What all of this does is really make the database data available to view in ViewModel instance.
         *
         */
        // retrieve the menu items from the model so we can popluate teh new property we just added.
        public IActionResult Index(CategoryViewModel vm)
        {
            // only build the catalogue once
            if (HttpContext.Session.Get<List<Category>>("categories") == null)
            {
                // no session information so let's go to the database
                try
                {
                    CategoryModel catModel = new CategoryModel(_db);
                    // now load the categories
                    List<Category> categories = catModel.GetAll();
                    HttpContext.Session.Set<List<Category>>("categories", categories);
                    vm.SetCategories(categories);
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "Catalogue Problem - " + ex.Message;
                }
            }
            else
            {
                // no need to go back to the database as information is already in the session
                vm.SetCategories(HttpContext.Session.Get<List<Category>>("categories"));
            }
            return View(vm);
        }

        public IActionResult SelectCategory(CategoryViewModel vm)
        {
            CategoryModel catModel = new CategoryModel(_db);
            MenuItemModel menuModel = new MenuItemModel(_db);
            List<MenuItem> items = menuModel.GetAllByCategory(vm.CategoryId);
            List<MenuItemViewModel> vms = new List<MenuItemViewModel>();
            if (items.Count > 0)
            {
                foreach (MenuItem item in items)
                {
                    MenuItemViewModel mvm = new MenuItemViewModel();
                    mvm.Qty = 0;
                    mvm.CategoryId = item.CategoryId;
                    mvm.CategoryName = catModel.GetName(item.CategoryId);
                    mvm.Description = item.Description;
                    mvm.Id = item.Id;
                    mvm.Protein = item.Protein;
                    mvm.Sodium = item.Sodium;
                    mvm.Fat = Convert.ToDecimal(item.Fat);
                    mvm.Fibre = item.Fibre;
                    mvm.Cholesterol = item.Cholesterol;
                    mvm.Calories = item.Calories;
                    mvm.Carbohydrate = item.Carbohydrate;
                    vms.Add(mvm);
                }
                MenuItemViewModel[] myMenu = vms.ToArray();
                HttpContext.Session.Set<MenuItemViewModel[]>("menu", myMenu);
            }
            vm.SetCategories(HttpContext.Session.Get<List<Category>>("categories"));
            return View("Index", vm); // need the original Index View here
        }
    }
}
