using FinalCapstoneGCCD.Presentation.Clients;
using FinalCapstoneGCCD.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FinalCapstoneGCCD.Presentation.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarClient _carClient;
        public CarsController()
        {
            _carClient = new CarClient();
        }
        // GET: Cars
        public ActionResult SearchCars()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> SearchCars(string make = null, string model = null, int? year = null, string color = null)
        {
            var cars = await _carClient.GetCar(make, model, year, color);
            var mappedCars = cars.Select(t => new CarViewModel {
                Make = t.Make,
                Model = t.Model,
                Year = t.Year,
                Color = t.Color
            }).ToList();
            return View("Results", mappedCars);
        }
    }
}