using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TourismReserve.Core.Models.Commons;

namespace TourismRserve.DAL.Configurations.ReservationConf
{
    public class ReservationConfigurations : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder
             .HasOne(r => r.TourPackage)
             .WithMany(t => t.Reservations)
             .HasForeignKey(r => r.TourPackageId);

        }
    }
}
