using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDemo.Core;
using CoreDemo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace CoreDemo.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;
        public string Message { get; set; }
        public IEnumerable<Restaurant> restaurantList;


        // BindProperty takes value from HTTPREQUEST WHEN PAGE LOADS BUT BY DEFAULT IT WORKS WITH HTTPPOST
        // TO MAKE THIS WORK WITH HTTPGET, NEED TO ADD SUPPORTGET TAG ALSO
        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config,
            IRestaurantData restaurantData)
        {
            this.config = config;
            this.restaurantData = restaurantData;
        }
        public void OnGet()
        {
            //One way to get value from query string
            //string input = HttpContext.Request.Query["searchinput"];

            restaurantList = this.restaurantData.GetRestaurantByName(SearchTerm);
            Message = config["Message"];
        }
    }
}
