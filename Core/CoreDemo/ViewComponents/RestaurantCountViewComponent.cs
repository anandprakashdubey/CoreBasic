using CoreDemo.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents
{
    public class RestaurantCountViewComponent
        : ViewComponent
    {
        private IRestaurantData restaurantData; 
        public RestaurantCountViewComponent(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public IViewComponentResult Invoke()
        {
            var count = restaurantData.GetRestaurantByName(null).Count();
            return View(count);
        }
    }
}
