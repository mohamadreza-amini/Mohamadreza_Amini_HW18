namespace DataAccess;
using Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Dependency
{

    public static IServiceCollection AddDataAccessServices(this IServiceCollection services)
    {
        services.AddScoped<IDataAccess<Product>, DataAccess<Product>>();
        services.AddScoped<IDataAccess<Store>, DataAccess<Store>>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IStoreRepository, StoreRepository>();
    

        return services;
    }
}

