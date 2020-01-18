using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Pluralsight_OdeToFood.Core;
using Pluralsight_OdeToFood.Data;

namespace Pluralsight_OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public string MessageFromSettings { get; set; }
        public string MessageFromCodeBehind { get; set; }
        public string configCodeBehind { get; }

        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration configSettings, IRestaurantData restaurantData )
        {
            this.configCodeBehind = configSettings["MessageInSettings"];
            this.restaurantData = restaurantData;
        }

        public void OnGet() //if searchterm is not provided, null is taken tobe default value
        {
            MessageFromSettings = this.configCodeBehind;
            MessageFromCodeBehind = "Hello from CodeBehind";

            //Restaurants = restaurantData.GetAllRestaurants();
            Restaurants = restaurantData.GetRestaurantByName(SearchTerm);
        }
    }
}