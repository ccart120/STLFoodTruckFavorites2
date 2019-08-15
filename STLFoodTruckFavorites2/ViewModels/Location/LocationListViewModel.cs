using STLFoodTruckFavorites2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STLFoodTruckFavorites2.ViewModels.Location
{
    public class LocationListViewModel
    {
        public static List<LocationListViewModel> GetLocationListViewModels(ApplicationDbContext context)
        {
            List<Models.Location> locations = context.Locations.ToList();

            List<LocationListViewModel> locationListViewModels = new List<LocationListViewModel> ();
            foreach (Models.Location location in locations)
            {
                LocationListViewModel viewModel = new LocationListViewModel();
                viewModel.ID = location.ID;
                viewModel.Name = location.Name;
                locationListViewModels.Add(viewModel);
            }
            return locationListViewModels;

        }


        public int ID { get; set; }
        public string Name { get; set; }
    }
}
