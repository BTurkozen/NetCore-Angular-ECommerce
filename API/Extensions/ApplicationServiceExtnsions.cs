using API.Core.Interfaces;
using API.Infrastructure.Implements;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Extensions
{
    public static class ApplicationServiceExtnsions
    {
        public static IServiceCollection ApplicationServices(this IServiceCollection services)
        {
            //Dependincy Injection
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));

            return services;
        }
    }
}
