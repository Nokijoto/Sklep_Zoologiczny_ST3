using PetStore.Interfaces;
using PetStore.Resolver;
using PetStore.Services;
using System.Net.Http.Headers;

namespace PetStore.Extensions
{
    public static class ServiceStoreCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {

            services.AddHttpClient();
           
            services.AddScoped<IAnimalsService, AnimalsService>();
            services.AddScoped<IWarehouseService, WarehouseService>();


            services.AddScoped<WarehouseIntegrationDataResolver>();
            services.AddScoped<SpecieIntegrationDataResolver>();
            services.AddScoped<AnimalIntegrationDataResolver>();
            services.AddScoped<SuppliersDataResolver>();
            return services;
        }
    }
}
