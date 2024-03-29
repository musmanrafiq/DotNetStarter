﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TM.Business.DataServices;
using TM.Business.Interfaces;
using TM.Data;
using TM.Data.Interfaces;
using TM.DependencyInjection.OptionModels;

namespace TM.DependencyInjection
{
    public static class AppInfrastructure
    {
        public static void AppDISetup(this IServiceCollection services, IConfiguration configuration)
        {
            // configure entity framework
            services.AddDbContext<StoreManagementDbContext>(
                options => options.
                UseSqlServer(configuration.GetConnectionString("DbConnection")));

            // repositories configuration
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // setting configuration for authentication
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie((cookieOptions) =>
                {
                    cookieOptions.LoginPath = "/Authentication/login";
                    cookieOptions.Cookie = new CookieBuilder
                    { Name = "StoreManagementCookie"};
                });

            // all of the custom configurations
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IStoreService, StoreService>();

            // automapper configuration
            services.AddAutoMapper(typeof(BusinessEntityMappings));

            // setting up all the option models
            services.Configure<AccountOption>((option) =>
            {
                // configure admin account for login into the system
                configuration.GetSection("Account").Bind(option);
            });

            // memory cache setup
            services.AddMemoryCache();
        }
    }
}