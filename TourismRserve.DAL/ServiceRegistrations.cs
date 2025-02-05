using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourismRserve.DAL
{
    public static class ServiceRegistrations
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
          
            return services;
        }
    }
}
