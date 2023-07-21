using ParkEFI.Application.Contracts;
using ParkEFI.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ParkEFI.Application.Ioc
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<IProvinceService, ProvinceService>();
            services.AddTransient<IGarageOwnerService, GarageOwnerService>();
            services.AddTransient<IParkingOwnerService, ParkingOwnerService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IParkingService, ParkingService>();

            return services;
        }
    }
}
