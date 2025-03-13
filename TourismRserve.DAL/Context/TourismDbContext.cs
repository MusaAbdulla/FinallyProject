using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TourismReserve.Core.Models.Commons;


namespace TourismRserve.DAL.Context
{
    public class TourismDbContext :IdentityDbContext<User>
    {
        public TourismDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<UserImage> Images { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<TourPackage> TourPackages { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CheckOut> CheckOuts { get; set; }
        public DbSet<PackageComment> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly( typeof(TourismDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
