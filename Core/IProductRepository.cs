namespace Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IProductRepository
{
    Task<List<Product>> GetProducts(int storeId , string sortOrder);

    Task<Product> GetProductById(int productId);

    Task<bool> EditProduct(Product product);

}
