using ParkEFI.Domain.Contracts;
using ParkEFI.Infrastructure.Repositories;
using ParkEFI.Infrastructure;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace ParkEFI.Infrastructure.Ioc
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddParkEFIDbContext(this IServiceCollection services, string connectionString, string schema)
        {
            services.AddDbContext<ParkEFIDbContext>(options =>
            {
                options.UseSqlServer(connectionString, x => x.MigrationsHistoryTable(Microsoft.EntityFrameworkCore.Migrations.HistoryRepository.DefaultTableName, schema));
            });
            services.AddScoped<IParkEFIDbContext, ParkEFIDbContext>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<IProvinceRepository, ProvinceRepository>();
            services.AddTransient<IGarageOwnerRepository, GarageOwnerRepository>();
            services.AddTransient<IParkingOwnerRepository, ParkingOwnerRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IParkingRepository, ParkingRepository>();

            return services;
        }
    }
}
