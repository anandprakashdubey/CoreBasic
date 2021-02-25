using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDemo.Core;
using CoreDemo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreDemo.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private IHtmlHelper htmlhelper;
        private IRestaurantData restaurantData;
        public IEnumerable<SelectListItem> cusines { get; set; }

        [BindProperty(SupportsGet = true)]
        public Restaurant restaurant { get; set; }
        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlhelper)
        {
            this.restaurantData = restaurantData;
            this.htmlhelper = htmlhelper;
        }
        public IActionResult OnGet(int? restaurantId)
        {
            cusines = htmlhelper.GetEnumSelectList<CusineType>();
            if (restaurantId.HasValue)
            {
                restaurant = restaurantData.GetRestaurantById(restaurantId.Value);
            }
            else
            {
                restaurant = new Restaurant();
            }

            //if (restaurant == null)
            //{
            //    return RedirectToPage("./NotFound");
            //}

            return Page();
        }

        public IActionResult OnPost()
        {

            cusines = htmlhelper.GetEnumSelectList<CusineType>();
            if (ModelState.IsValid)
            {
                if (restaurant.Id > 0)
                {
                    TempData["Message"] = "Updated Successfully";
                    restaurantData.UpdateRestaurant(restaurant);
                }
                else {
                    TempData["Message"] = "Created Successfully";
                    restaurantData.AddRestaurant(restaurant);
                }
               
                restaurantData.Commit();
                return RedirectToPage("./Detail", new { restaurantId = restaurant.Id });
            }

            return Page();
        }
    }
}