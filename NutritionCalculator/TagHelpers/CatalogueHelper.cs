using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Http;
using System.Text;
using NutritionCalculator.Models;
using Newtonsoft.Json;
using NutritionCalculator.Utils;
using System;

namespace NutritionCalculator.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("catalogue", Attributes = CategoryIdAttribute)]
    public class CatalogueHelper : TagHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        // need and instance of the Session to get at the menu items array, so add this immediately before the constructor
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        public CatalogueHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        private const string CategoryIdAttribute = "category";
        [HtmlAttributeName(CategoryIdAttribute)]
        public string CategoryId { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (_session.Get<MenuItemViewModel[]>("menu") != null && Convert.ToInt32(CategoryId) > 0)
            {
                // concatenating strings numerous times and traditional concatenation is quite resource intensive
                var innerHtml = new StringBuilder();
                MenuItemViewModel[] menu = _session.Get<MenuItemViewModel[]>("menu");
                // Appends the string representation of a specified object to this instance.
                innerHtml.Append("<h5>Items</h5>");
                innerHtml.Append("<div class=\"row w-100 m-1\" style=\"overflow-y:scroll;height:60vh;\">");
                foreach (MenuItemViewModel item in menu)
                {
                    if (item.CategoryId == Convert.ToInt32(CategoryId))
                    {
                        // remove apostrophe from JSON
                        item.Description = item.Description.Contains("'") ? item.Description.Replace("'", "") : item.Description;
                        var itemJson = JsonConvert.SerializeObject(item);
                        var btn = "catbtn" + item.Id;
                        innerHtml.Append("<div class=\"col-sm-3 col-xs-12 text-center\" style =\"border:solid;\">");
                        innerHtml.Append("<img style =\"width:100px; height:100px\" src =\"https://github.com/youngmin-chung/capture/blob/master/hamburger.png?raw=true\" /><br />");
                        if (item.Description.Length > 25)
                        {
                            innerHtml.Append("<span class=\"m-0\" style=\"font-size:large;font-weight:bold;\">" + item.Description.Substring(0, 25) + "...</span>");
                        }
                        else
                        {
                            innerHtml.Append("<span class=\"m-0\" style=\"font-size:large;font-weight:bold;\">" + item.Description + "...</span>");
                        }
                        innerHtml.Append("<p><span style=\"font-size:medium\">Nutrition info. in details</span >");
                        innerHtml.Append("<p><a id=\"" + btn + "\" href=\"#details_popup\" data-toggle=\"modal\"");
                        innerHtml.Append(" class=\"btn btn-outline-dark pt-2 pb-2\" data-id=" + item.Id);
                        innerHtml.Append(" data-details='" + itemJson + "'>Details</a></div>");
                    }
                }
                output.Content.SetHtmlContent(innerHtml.ToString());
            }
        }
    }
}
