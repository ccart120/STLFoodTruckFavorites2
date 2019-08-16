using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STLFoodTruckFavorites2.Models
{
    public class Location
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public List<LocationFoodTruck> LocationFoodTrucks { get; set; }

    }
}