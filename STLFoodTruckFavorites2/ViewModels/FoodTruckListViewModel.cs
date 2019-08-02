using STLFoodTruckFavorites2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STLFoodTruckFavorites2.ViewModels
{
    public class FoodTruckListViewModel
    {
        public static List<FoodTruckListViewModel> GetFoodTruckListViewModels(ApplicationDbContext context)
        {
            List<Models.FoodTruck> foodTrucks = context.FoodTrucks.ToList();

            List<FoodTruckListViewModel> foodTruckListViewModels = new List<FoodTruckListViewModel>();
            foreach (Models.FoodTruck foodTruck in foodTrucks)
            {
                FoodTruckListViewModel viewModel = new FoodTruckListViewModel();
                viewModel.ID = foodTruck.ID;
                viewModel.Name = foodTruck.Name;
                viewModel.Description = foodTruck.Description;

                foodTruckListViewModels.Add(viewModel);
            }
            return foodTruckListViewModels;
            
        }
        
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
