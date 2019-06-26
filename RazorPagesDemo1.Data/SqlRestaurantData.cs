using RazorPagesDemo1.Core;
using System.Collections.Generic;
using System.Linq;

namespace RazorPagesDemo1.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly DemoDbContext db;

        public SqlRestaurantData(DemoDbContext db )
        {
            this.db = db;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            db.Add(newRestaurant);
            return newRestaurant;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetById(id);
            if (restaurant != null)
            {
                db.Restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public Restaurant GetById(int id)
        {
            return db.Restaurants.Find(id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            var query = from r in db.Restaurants
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Name            
                        select r;

            return query;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var entity = db.Restaurants.Attach(updatedRestaurant);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return updatedRestaurant;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            var query = from r in db.Restaurants
                        orderby r.Name
                        select r;

            return query;
        }

        public int GetCountOfRestaurants()
        {
            return db.Restaurants.Count();
        }
    }
}
