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
        public async Task<ActionResult> Results(string make = null, string model = null, int year = 0, string color = null)
        {
            var cars = await _carClient.GetCar(make, model, year, color);
            return View();
        }
    }
}