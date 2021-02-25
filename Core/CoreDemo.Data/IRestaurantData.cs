using CoreDemo.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreDemo.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantByName(string name);
        Restaurant GetRestaurantById(int Id);

        Restaurant UpdateRestaurant(Restaurant res);
        Restaurant AddRestaurant(Restaurant res);
        int Commit();
    }
}
