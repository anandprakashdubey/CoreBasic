using System.Collections.Generic;
using System.Linq;
using CoreDemo.Core;

namespace CoreDemo.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurtants;
        public InMemoryRestaurantData()
        {
            restaurtants = new List<Restaurant>()
            {
                new Restaurant  { Id = 1, Name = "Idli Sambhar", Cusine = CusineType.Indian, Location = "Tamil Nadu" },
                new Restaurant  { Id = 2, Name = "Sphagetti", Cusine = CusineType.Italian , Location = "Athlone"},
                new Restaurant  { Id = 3, Name = "Tacos", Cusine = CusineType.Mexican , Location = "New Mexico"}
            };
        }
        public IEnumerable<Restaurant> GetRestaurantByName(string name)
        {
            return from r in restaurtants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name                  
                   select r;
        }
    }
}
