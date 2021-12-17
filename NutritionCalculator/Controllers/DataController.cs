using Microsoft.AspNetCore.Mvc;
using NutritionCalculator.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NutritionCalculator.Controllers
{
    public class DataController : Controller
    {
        AppDbContext _ctx;
        // an instance of the context is passed in via the controller’s constructor
        public DataController(AppDbContext context)
        {
            _ctx = context;
        }

        public async Task<IActionResult> Index()
        {
            UtilityModel util = new UtilityModel(_ctx);
            string msg = "";
            var json = await getMenuItemJsonFromWebAsync();
            try
            {
                msg = (util.loadNutritionTables(json)) ? "tables loaded" : "problem loading tables";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            ViewBag.LoadedMsg = msg;
            return View();
        }

        private async Task<String> getMenuItemJsonFromWebAsync()
        {
            string url = "https://raw.githubusercontent.com/youngmin-chung/json/master/mcdonalds.json";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}
