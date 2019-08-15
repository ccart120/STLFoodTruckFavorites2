using STLFoodTruckFavorites2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STLFoodTruckFavorites2.ViewModels.Location
{
    public class LocationCreateViewModel
    {


        private ApplicationDbContext context;

        public LocationCreateViewModel() { }

        public void Persist(ApplicationDbContext context)
        {
            Models.Location location = new Models.Location()
            {
                Name = this.Name
            };
            context.Locations.Add(location);
            context.SaveChanges();
        }

        public string Name { get; set; }
    }
}
