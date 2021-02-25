using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDemo.Core;
using CoreDemo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoreDemo.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        private IRestaurantData restaurantdata;
        public Restaurant restaurant;

        [TempData]
        public string Message { get; set; }

        public DetailModel(IRestaurantData restaurantdata)
        {
            this.restaurantdata = restaurantdata;
        }
        public IActionResult OnGet(int restaurantId)
        {
            restaurant = restaurantdata.GetRestaurantById(restaurantId);
            if (restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();

        }
    }
}
