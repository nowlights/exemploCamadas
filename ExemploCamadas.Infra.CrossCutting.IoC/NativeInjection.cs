﻿using ExemploCamadas.Infra.Data.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace ExemploCamadas.Infra.CrossCutting.IoC;

public static class NativeInjection
{
    public static IServiceCollection InjectServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("PrpConnection");
        var versionServer = new MySqlServerVersion(new Version(8, 0, 21));
        services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseMySql(connectionString, versionServer);
        });
        
        
        
        return services;
    }
}