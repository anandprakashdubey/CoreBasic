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

        public ListModel(IConfiguration config,
            IRestaurantData restaurantData)
        {
            this.config = config;
            this.restaurantData = restaurantData;
        }
        public void OnGet()
        {
            restaurantList = this.restaurantData.GetAll();
            Message = config["Message"];
        }
    }
}
