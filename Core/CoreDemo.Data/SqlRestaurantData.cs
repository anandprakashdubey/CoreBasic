using System;
using System.Collections.Generic;
using System.Text;
using CoreDemo.Core;
using System.Linq;
namespace CoreDemo.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        public RestaurantDBContext db { get; }
        public SqlRestaurantData(RestaurantDBContext db)
        {
            this.db = db;
        }

        public Restaurant AddRestaurant(Restaurant res)
        {
            db.Restaurants.Add(res);
            return res;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Restaurant DeleteRestaurant(int Id)
        {
            var _res = GetRestaurantById(Id);
            if (_res != null)
                db.Restaurants.Remove(_res);
            return _res;

        }

        public Restaurant GetRestaurantById(int Id)
        {
            return db.Restaurants.Find(Id);
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name)
        {
            var query = from r in db.Restaurants
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;
            return query;
        }

        public Restaurant UpdateRestaurant(Restaurant res)
        {
            var entity = db.Restaurants.Attach(res);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return res;
        }
    }
}
