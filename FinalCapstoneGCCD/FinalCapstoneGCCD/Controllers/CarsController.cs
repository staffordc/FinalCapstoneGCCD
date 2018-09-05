using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using FinalCapstoneGCCD.Data;
using FinalCapstoneGCCD.Domain.Models;
using FinalCapstoneGCCD.Models;

namespace FinalCapstoneGCCD.Controllers
{
    public class CarsController : ApiController
    {
        private FinalCapstoneGCCDContext db = new FinalCapstoneGCCDContext();

        // GET: api/Cars
        public IQueryable<Car> GetCars()
        {
            return db.Cars;
        }

        // GET: api/Cars/5
        [ResponseType(typeof(Car))]
        public IHttpActionResult GetCar(int id)
        {
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        // PUT: api/Cars/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCar(int id, Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != car.CarId)
            {
                return BadRequest();
            }

            db.Entry(car).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Cars
        [ResponseType(typeof(Car))]
        public IHttpActionResult PostCar(Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cars.Add(car);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = car.CarId }, car);
        }

        // DELETE: api/Cars/5
        [ResponseType(typeof(Car))]
        public IHttpActionResult DeleteCar(int id)
        {
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return NotFound();
            }

            db.Cars.Remove(car);
            db.SaveChanges();

            return Ok(car);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CarExists(int id)
        {
            return db.Cars.Count(e => e.CarId == id) > 0;
        }
        
        public List<Car> GetCarsApi(int? id = null, string make = null, string model = null, int? year = 0, string color = null)
        {
            var cars = db.Cars.AsQueryable();
            if (id.HasValue)
            {
                cars = cars.Where(x => x.CarId == id.Value);
            }
            if (string.IsNullOrWhiteSpace(make))
            {
                cars = cars.Where(x => x.Make.Contains(make));
            }
            if (string.IsNullOrWhiteSpace(model))
            {
                cars = cars.Where(x => x.Model.Contains(model));
            }
            if (year.HasValue)
            {
                cars = cars.Where(x => x.Year == year.Value);
            }
            if (string.IsNullOrWhiteSpace(color))
            {
                cars = cars.Where(x => x.Color.Contains(color));
            }
            

            return cars.ToList();
        }
    }
}