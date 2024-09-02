using Core;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess;

public class StoreRepository : IStoreRepository
{
    private IDataAccess<Store> DataAccess;

    public StoreRepository(IDataAccess<Store> dataAccess)
    {
        DataAccess = dataAccess;
    }

    //in ham bayad task bashe ya async nemikhad ghabli dare
    public async Task<List<Store>> GetStores(string storeName, string zipCode)
    {
        string query = "select * from sales.stores s ";

        var whereFlag = false;
        DynamicParameters dynamicParameters = new DynamicParameters();

        // اگه پارامتر خالی باشه مشکلی پیش نمیاد

        if (!string.IsNullOrWhiteSpace(storeName))
        {
            storeName =  storeName.Trim();
            query += " where ";
            whereFlag = true;

            query += " s.store_name = @store_name ";

            dynamicParameters.Add("@store_name", storeName);
        }

        if (!string.IsNullOrWhiteSpace(zipCode))
        {
            zipCode = zipCode.Trim();
            if (!whereFlag)
            {
                query += " where ";

            }
            else
            {
                query += " and ";
            }

            query += " s.zip_code = @zip_code ";

            dynamicParameters.Add("@zip_code", zipCode);
        }

        return await DataAccess.GetEntities(query, dynamicParameters) ;

    }
}
