using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismReserve.Core.Repositories;
using TourismRserve.DAL.Repositories;

namespace TourismRserve.DAL
{
    public static class ServiceRegistrations
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ITourPackageRepository, TourPackageRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<ISlideRepository, SlideRepository>();
            return services;
        }
    }
}
