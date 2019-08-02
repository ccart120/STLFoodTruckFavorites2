using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using STLFoodTruckFavorites2.Data;
using STLFoodTruckFavorites2.ViewModels;

namespace STLFoodTruckFavorites2.Controllers
{
    public class FoodTruckController : Controller
    {
        private ApplicationDbContext context;

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
            return View(model);
        }
    }
}