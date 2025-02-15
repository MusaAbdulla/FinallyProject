using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismReserve.Core.Models.Commons;

namespace TourismRserve.DAL.Configurations.TourPackageConf
{
    public class TourPackageConfigurations : IEntityTypeConfiguration<TourPackage>
    {
        public void Configure(EntityTypeBuilder<TourPackage> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(64);
            builder.Property(x=> x.Description)
                .IsRequired()
                .HasMaxLength(256);
            builder.HasMany(X => X.Reservations)
                .WithOne(X=> X.Package)
                .HasForeignKey(X=> X.TourPackageId);
            builder.HasMany(x => x.Images)
                .WithOne(x => x.TourPackage)
                .HasForeignKey(x => x.TourPackageId);
        }
    }
}
