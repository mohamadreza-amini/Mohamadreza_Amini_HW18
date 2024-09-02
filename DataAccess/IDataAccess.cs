using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess;

public interface IDataAccess<T>
{
    public Task<T> GetEntity(string query, DynamicParameters? parameters);
    public Task<List<T>> GetEntities(string query, DynamicParameters? parameters);
    public Task<bool> EditEntity(string query, DynamicParameters? parameters);
}
