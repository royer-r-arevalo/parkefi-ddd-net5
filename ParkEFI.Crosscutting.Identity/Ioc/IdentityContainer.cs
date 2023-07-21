using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ParkEFI.Crosscutting.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkEFI.Crosscutting.Identity.Contracts;
using ParkEFI.Crosscutting.Identity.Services;
using ParkEFI.Crosscutting.Identity.Mappings;

namespace ParkEFI.Crosscutting.Identity.Ioc
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddParkEFIIdentityContext(this IServiceCollection services, string connectionString, string schema)
        {
            services.AddDbContext<IdentityContext>(options =>
            {
                options.UseSqlServer(connectionString, builder => builder.MigrationsHistoryTable(Microsoft.EntityFrameworkCore.Migrations.HistoryRepository.DefaultTableName, schema));
            });
            services.AddIdentity<ApplicationUser, ApplicationRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();

            return services;
        }

        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {
            services.AddTransient<IApplicationUserService, ApplicationUserService>();
            
            return services;
        }
    }
}
