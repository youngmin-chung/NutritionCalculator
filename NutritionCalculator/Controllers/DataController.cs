using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NutritionCalculator.Controllers
{
    public class DataController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var json = await getMenuItemJsonFromWebAsync();
            return Content(json);
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
