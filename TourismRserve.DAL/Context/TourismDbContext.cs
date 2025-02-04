using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TourismReserve.Core.Models.Commons;
using TourismReserve.Core.Models.Country;
using TourismReserve.Core.Models.TourPackage;

namespace TourismRserve.DAL.Context
{
    public class TourismDbContext : DbContext
    {
        public TourismDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<TourPackage> TourPackages { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Country> Countries { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly( typeof(TourismDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
