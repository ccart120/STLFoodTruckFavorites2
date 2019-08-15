using STLFoodTruckFavorites2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STLFoodTruckFavorites2.ViewModels.Location
{
    public class LocationEditViewModel
    {
        public LocationEditViewModel() { }

        public LocationEditViewModel(ApplicationDbContext context, int id)
        {
            Models.Location location = context.Locations
                .Single(l => l.ID == id);
            Name = location.Name;
            
        }

        public void Persist(ApplicationDbContext context, int id)
        {
            Models.Location location = new Models.Location()
            {
                ID = id,
                Name = this.Name,
                
            };
            context.Update(location);
            context.SaveChanges();

        }
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
