using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using STLFoodTruckFavorites2.Data;
using STLFoodTruckFavorites2.Models;
using STLFoodTruckFavorites2.ViewModels;

namespace STLFoodTruckFavorites2.Controllers
{
    //changed authorization to admin for all methods
    [Authorize(Roles = "Admin")]
    public class FoodTruckController : Controller
    {
        private ApplicationDbContext context;
        public List<FoodTruck> foodTrucks = new List<FoodTruck>();

        public FoodTruckController(ApplicationDbContext context)
        {
            this.context = context;
        }
        
        public IActionResult Index()
        {
            List<FoodTruckListViewModel> models = FoodTruckListViewModel.GetFoodTruckListViewModels(context);
            return View(models);
        }

        [HttpGet]
        
        public IActionResult Create()
        {
            FoodTruckCreateViewModel model = new FoodTruckCreateViewModel();
            return View(model);
        }
        
        [HttpPost]
        
        public IActionResult Create(FoodTruckCreateViewModel model)
        {
            model.Persist(context);
            return RedirectToAction(actionName: nameof(Index));
            //return View(model);
        }

        [HttpGet]
        
        public IActionResult Edit(int id)
        {
            return View(model:new FoodTruckEditViewModel(context,id));
        }

        [HttpPost]
        
        public IActionResult Edit(FoodTruckEditViewModel foodTruckEditViewModel, int id)
        {
            foodTruckEditViewModel.Persist(context, id);
            return RedirectToAction(actionName: nameof(Index));

        }
        
        public IActionResult Delete(int id)
        { 
            foodTrucks = context.FoodTrucks.ToList();
            FoodTruck foodTruck = foodTrucks.SingleOrDefault(f => f.ID == id);
            context.Remove(foodTruck);
            context.SaveChanges();
            return RedirectToAction(actionName: nameof(Index));
        }

    }
}