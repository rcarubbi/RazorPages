using RazorPagesDemo1.Core;
using System.Collections.Generic;

namespace RazorPagesDemo1.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        IEnumerable<Restaurant> GetRestaurantsByName(string name);

        Restaurant GetById(int id);

        Restaurant Update(Restaurant updatedRestaurant);

        Restaurant Add(Restaurant newRestaurant);

        Restaurant Delete(int id);

        int Commit();

        int GetCountOfRestaurants();
    }
}
