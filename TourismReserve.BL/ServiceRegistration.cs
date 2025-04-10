﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismReserve.BL.External_Service;
using TourismReserve.BL.Services.Implements;
using TourismReserve.BL.Services.Interfaces;

namespace TourismReserve.BL
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
         
            services.AddScoped<ISlideServices, SlideServices>();
            services.AddScoped<ITourPackageService, TourPacakgeService>();
            services.AddScoped<IUserImageService, UserImageService>();
            services.AddScoped<IReservationServcie, ReservationService>();
            services.AddScoped<IStripeService, StripeService>();
            services.AddScoped<IChechOutService, CheckOutService>();
            return services;
        }
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ServiceRegistration));
            return services;
        }
    }
}
