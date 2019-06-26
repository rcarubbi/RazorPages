using RazorPagesDemo1.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RazorPagesDemo1.Data
{
    public class InMemoryRestaurantData :  IRestaurantData
    {
        readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>() {
                new Restaurant { Id = 1, Name = "Carubbi's Pizza", Location = "São Paulo", Cousine = CousineType.Italian },
                new Restaurant { Id = 2, Name = "Cinnamon Club", Location = "Londres", Cousine = CousineType.Indian },
                new Restaurant { Id = 3, Name = "La costa", Location = "California", Cousine = CousineType.Mexican},
            };
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(x => x.Id) + 1;
            return newRestaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(x => x.Id == id);
        }

        public int GetCountOfRestaurants()
        {
            return restaurants.Count;
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   orderby r.Name
                   where string.IsNullOrWhiteSpace(name) || r.Name.StartsWith(name, StringComparison.OrdinalIgnoreCase) 
                   select r;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(x => x.Id == updatedRestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cousine = updatedRestaurant.Cousine;

            }

            return restaurant;
        }
    }
}
