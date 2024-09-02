using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace DataAccess;

internal class DataAccess<T>:IDataAccess<T>
{
    private readonly IDbConnection connection;
   
    public DataAccess(IConfiguration config)
    {
        connection = new SqlConnection(config.GetConnectionString("DefaultConnection"));
    }

    public async Task<T> GetEntity(string query, DynamicParameters? parameters)
    {
        using (var conn = connection)
        {
            conn.Open();
            T? entity = await conn.QueryFirstOrDefaultAsync<T>(query, parameters ?? new DynamicParameters() );

            conn.Close();
            return entity;
        }

    }

    public async Task<List<T>> GetEntities(string query, DynamicParameters? parameters)
    {
        using (var conn = connection)
        {
            conn.Open();
            List<T> entities = (await conn.QueryAsync<T>(query, parameters ?? new DynamicParameters())).ToList();

            conn.Close();
            return entities;
        }

    }


    public async Task<bool> EditEntity(string query, DynamicParameters? parameters)
    {
        using (var conn = connection)
        {
            conn.Open();
            var result = await conn.ExecuteAsync(query, parameters ?? new DynamicParameters());
            conn.Close();
            return result == 1;
        }
    }


}
