using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using STLFoodTruckFavorites2.Models;

namespace STLFoodTruckFavorites2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<FoodTruck> FoodTrucks { get; set; }
        public DbSet<Location> Locations { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
