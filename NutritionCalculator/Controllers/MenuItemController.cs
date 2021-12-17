using Microsoft.AspNetCore.Mvc;
using NutritionCalculator.Models;

namespace NutritionCalculator.Controllers
{
    public class MenuItemController : Controller
    {
        AppDbContext _db;
        public MenuItemController(AppDbContext context)
        {
            _db = context;
        }
        public IActionResult Index(CategoryViewModel category)
        {
            MenuItemModel model = new MenuItemModel(_db);
            MenuItemViewModel viewModel = new MenuItemViewModel();
            viewModel.MenuItems = model.GetAllByCategory(category.Id);
            viewModel.CategoryName = model.GetCategory(category.Id).Name;
            return View(viewModel);
        }
    }
}
