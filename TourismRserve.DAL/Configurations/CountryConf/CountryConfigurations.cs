using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismReserve.Core.Models.Commons;

namespace TourismRserve.DAL.Configurations.CountryConf
{
    public class CountryConfigurations : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(128);
            builder.HasMany(x => x.TourPackages)
                .WithOne(x=> x.Country)
                .HasForeignKey(x=> x.CountryId);
        }
    }
}
