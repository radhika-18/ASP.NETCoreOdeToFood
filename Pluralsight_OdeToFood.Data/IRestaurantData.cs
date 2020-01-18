using Pluralsight_OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Pluralsight_OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAllRestaurants();

        IEnumerable<Restaurant> GetRestaurantByName(string name);

        Restaurant GetRestaurantById(int id);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{Id=1, Name = "Restaurant1", Location = "Restaurant 1 Location", Cuisine = CuisineType.Chinese},
                new Restaurant{Id=2, Name = "Restaurant2", Location = "Restaurant 2 Location", Cuisine = CuisineType.Indian},
                new Restaurant{Id=3, Name = "Restaurant3", Location = "Restaurant 3 Location", Cuisine = CuisineType.Italian},
                new Restaurant{Id=4, Name = "Restaurant4", Location = "Restaurant 4 Location", Cuisine = CuisineType.Mexican},
                new Restaurant{Id=5, Name = "Restaurant5", Location = "Restaurant 5 Location", Cuisine = CuisineType.Indian},
                new Restaurant{Id=6, Name = "Restaurant6", Location = "Restaurant 6 Location", Cuisine = CuisineType.Chinese},
                new Restaurant{Id=7, Name = "Restaurant7", Location = "Restaurant 7 Location", Cuisine = CuisineType.None},
            };
        } 

        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }

        public Restaurant GetRestaurantById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name= null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.Contains(name)
                   orderby r.Name
                   select r;
        }
    }
}
