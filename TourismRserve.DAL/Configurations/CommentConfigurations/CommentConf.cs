using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismReserve.Core.Models.Commons;

namespace TourismRserve.DAL.Configurations.CommentConfigurations
{
    public class CommentConf : IEntityTypeConfiguration<PackageComment>
    {
        public void Configure(EntityTypeBuilder<PackageComment> builder)
        {
            builder
            .HasOne(r => r.Package)
            .WithMany(t => t.Comments)
            .HasForeignKey(r => r.PackageId);
        }
    }
}
