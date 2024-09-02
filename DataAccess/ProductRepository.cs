using Core;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataAccess;

public class ProductRepository : IProductRepository
{
    private IDataAccess<Product> DataAccess;

    public ProductRepository(IDataAccess<Product> dataAccess)
    {
        DataAccess = dataAccess;
    }

    public async Task<Product> GetProductById(int productId)
    {
        string query = "select pr.product_id,pr.product_name,pr.model_year,pr.list_price,c.category_name,b.brand_name" +
            " from production.products pr inner join production.categories c on c.category_id=pr.category_id inner join" +
            " production.brands b on pr.brand_id= b.brand_id where pr.product_id = @product_id";

        DynamicParameters dynamicParameters = new DynamicParameters();
        dynamicParameters.Add("@product_id", productId);

        return await DataAccess.GetEntity(query, dynamicParameters);
    }



    public async Task<List<Product>> GetProducts(int storeId, string? sortOrder)
    {
        string query = "select pr.product_id,pr.product_name,pr.model_year,pr.list_price,c.category_name,b.brand_name from" +
            " production.products pr inner join production.stocks s on pr.product_id=s.product_id inner join production.categories" +
            " c on c.category_id=pr.category_id inner join production.brands b on pr.brand_id= b.brand_id where s.store_id = @store_id";

        DynamicParameters dynamicParameters = new DynamicParameters();
        dynamicParameters.Add("@store_id", storeId);

        if (!string.IsNullOrEmpty(sortOrder))
        {
            if (sortOrder == "priceAsc")
            {
                query += " order by pr.list_price asc ";
            }
            else if (sortOrder == "priceDesc")
            {
                query += " order by pr.list_price desc ";
            }
        }
        return await DataAccess.GetEntities(query, dynamicParameters);
    }

    public async Task<bool> EditProduct(Product product)
    {

        if (product.product_id > 0 && Regex.IsMatch(product.product_name, "^[A-Za-z]+$") && product.model_year > 1900 && product.model_year < 2025 && product.list_price > 0)
        {
            string query = "update production.products set product_name = '@product_name' , model_year = @model_year, list_price = @list_price where product_id = @product_id";

            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@product_name", product.product_name);
            dynamicParameters.Add("@model_year", product.model_year);
            dynamicParameters.Add("@list_price", product.list_price);
            dynamicParameters.Add("@product_id", product.product_id);

            return await DataAccess.EditEntity(query, dynamicParameters);
        }
        return false;
    }
}
