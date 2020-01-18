using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pluralsight_OdeToFood.Core;
using Pluralsight_OdeToFood.Data;

namespace Pluralsight_OdeToFood.Pages.Restaurants
{
    public class DetailModel : PageModel
    {        
        public Restaurant Restaurant { get; set; }
        private readonly IRestaurantData restaurantData;

        public DetailModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public IActionResult OnGet(int restaurantId)
        {
            //Restaurant = new Restaurant();
            //Restaurant.Id = restaurantId;

            Restaurant = restaurantData.GetRestaurantById(restaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}