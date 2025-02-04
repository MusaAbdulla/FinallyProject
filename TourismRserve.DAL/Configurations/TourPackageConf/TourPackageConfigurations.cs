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
        }
    }
}
