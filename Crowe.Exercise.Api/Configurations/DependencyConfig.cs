﻿using Crowe.Exercise.Common;
using Crowe.Exercise.Data;
using Crowe.Exercise.Data.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace Crowe.Exercise.Api.Configurations
{
    /// <summary>
    /// DependencyConfig Class.
    /// </summary>
    public static class DependencyConfig
    {
        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            var business = Assembly.Load(Constants.CROWE_EXERCISE_BUSINESS_ASSEMBLY);
            var data = Assembly.Load(Constants.CROWE_EXERCISE_DATA_ASSEMBLY);

            services.Scan(x =>
                x.FromAssemblies(business)
                .AddClasses(y => y.Where(type => type.Name.EndsWith("Manager", StringComparison.OrdinalIgnoreCase)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());

            services.Scan(x =>
                x.FromAssemblies(data)
                .AddClasses(y => y.Where(type => type.Name.EndsWith("Repository", StringComparison.OrdinalIgnoreCase)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());

            services.AddScoped<IDbContext>(provider => provider.GetService<CroweExerciseDbContext>());
            services.AddScoped(_ => new CroweExerciseDbContext(configuration.GetConnectionString(Constants.CONNECTION_STRING)));

            services.AddSingleton(configuration);
        }
    }
}