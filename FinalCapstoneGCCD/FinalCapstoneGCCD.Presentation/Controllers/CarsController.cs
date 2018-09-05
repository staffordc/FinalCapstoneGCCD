using FinalCapstoneGCCD.Presentation.Clients;
using FinalCapstoneGCCD.Presentation.Data.Models;
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
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> GetCar(CarViewModel car)
        {
            var car1 = await _carClient.GetCar(car.Make, car.Model, car.Year, car.Color);
            return View(car1);
        }
    }
}