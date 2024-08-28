namespace DataAccess;
using Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class FileName
{

    public static IServiceCollection AddDataAccessServices(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IStoreRepository, StoreRepository>();
        services.AddScoped<IDataAccess<Product>,DataAccess<Product>>();
        services.AddScoped<IDataAccess<Store>, DataAccess<Store>>();

        return services;
    }
}

