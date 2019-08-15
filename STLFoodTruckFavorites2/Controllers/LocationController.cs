using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using STLFoodTruckFavorites2.Data;
using STLFoodTruckFavorites2.Models;
using STLFoodTruckFavorites2.ViewModels.Location;

namespace STLFoodTruckFavorites2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LocationController : Controller
    {
        private ApplicationDbContext context;
        public List<Location> Locations = new List<Location>();

        public LocationController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult Create()
        {
            LocationCreateViewModel model = new LocationCreateViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(LocationCreateViewModel model)
        {
            model.Persist(context);
            return RedirectToAction(actionName: nameof(Index)); ;
            
        }

        public IActionResult Index()
        {
            List<LocationListViewModel> models = LocationListViewModel.GetLocationListViewModels(context);
            return View(models);
        }


        [HttpGet]

        public IActionResult Edit(int id)
        {
            return View(model: new LocationEditViewModel(context, id));
        }

        [HttpPost]

        public IActionResult Edit(LocationEditViewModel locationEditViewModel, int id)
        {
            locationEditViewModel.Persist(context, id);
            return RedirectToAction(actionName: nameof(Index));

        }

        //public IActionResult Delete(int id)
        //{
        //    locations = context.Locations.ToList();
        //    Location location = locations.SingleOrDefault(l => l.ID == id);
        //    context.Remove(location);
        //    context.SaveChanges();
        //    return RedirectToAction(actionName: nameof(Index));
        //}


    }
}