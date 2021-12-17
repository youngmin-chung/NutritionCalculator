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
        public IActionResult Index()
        {
            CategoryModel model = new CategoryModel(_db);
            CategoryViewModel viewModel = new CategoryViewModel();
            viewModel.Categories = model.GetAll();
            return View(viewModel);
        }
    }
}
