using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using FinalCapstoneGCCD.Domain.Models;

namespace FinalCapstoneGCCD.Data
{
    public class FinalCapstoneGCCDInitializer : DropCreateDatabaseIfModelChanges<FinalCapstoneGCCDContext>
    {
        protected override void Seed(FinalCapstoneGCCDContext context)
        {
            context.Cars.Add(new Car()
            {
                CarId = 01,
                Make = "Nordic Motors",
                Model = "Sleipnir",
                Year = 445,
                Color = "Equine Red"
            });
            context.Cars.Add(new Car()
            {
                CarId = 02,
                Make = "Gladitoria",
                Model = "Chariot ",
                Year = 476,
                Color = "Gold"
            });
            context.Cars.Add(new Car()
            {
                CarId = 03,
                Make = "Marolet",
                Model = "Whalemor",
                Year = -745,
                Color = "Deep Sea Blue"
            });
            context.Cars.Add(new Car()
            {
                CarId = 04,
                Make = "Star Stuff",
                Model = "Polarius",
                Year = 1985,
                Color = "Nebular"
            });
            base.Seed(context);
            context.SaveChanges();
        }
    }
}
