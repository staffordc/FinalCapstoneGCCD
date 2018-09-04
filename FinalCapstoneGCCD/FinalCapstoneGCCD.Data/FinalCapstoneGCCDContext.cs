using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalCapstoneGCCD.Data.Maps;
using FinalCapstoneGCCD.Domain.Models;
using System.Data.Entity;

namespace FinalCapstoneGCCD.Data
{
    public class FinalCapstoneGCCDContext : DbContext
    {
        public FinalCapstoneGCCDContext() : base("CarDealership")
        {
            Database.SetInitializer(new FinalCapstoneGCCDInitializer());
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Car> Cars {get; set;}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CarMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
