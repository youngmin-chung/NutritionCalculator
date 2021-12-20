using Microsoft.AspNetCore.Mvc;
using NutritionCalculator.Models;

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
        // retrieve the menu items from the model so swe can popluate teh new property we just added.
        public IActionResult Index(CategoryViewModel vm)
        {
            CategoryViewModel viewModel;
            if (vm.Id == 0) // 1st time
            {
                viewModel = new CategoryViewModel();
            }
            else
            {
                viewModel = vm;
                MenuItemModel itemModel = new MenuItemModel(_db);
                viewModel.MenuItems = itemModel.GetAllByCategory(vm.Id);
            }
            CategoryModel catModel = new CategoryModel(_db);
            viewModel.Categories = catModel.GetAll();
            return View(viewModel);
        }
    }
}
