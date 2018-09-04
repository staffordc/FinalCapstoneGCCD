using FinalCapstoneGCCD.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalCapstoneGCCD.Data.Maps
{
    class CarMap : EntityTypeConfiguration<Car>
    {
        internal CarMap()
        {
            HasKey(x => x.CarId);
            Property(x => x.CarId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
