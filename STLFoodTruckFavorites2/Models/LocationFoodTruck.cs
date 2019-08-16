using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STLFoodTruckFavorites2.Models
{
    public class LocationFoodTruck
    {
        public int ID { get; set; }

        public int LocationID { get; set; }
        public virtual Location Location { get; set; }

        public int FoodTruckID { get; set; }
        public virtual FoodTruck FoodTruck { get; set; }

      }  
}
