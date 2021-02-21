using CoreDemo.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreDemo.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }
}
