using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess;

public class ProductRepository:IProductRepository
{

    public Product GetProductById(int productId)
    {
        throw new NotImplementedException();
    }

    public List<Product> GetProducts(string orderSort)
    {
        throw new NotImplementedException();
    }

    public bool EditProduct(Product product)
    {
        throw new NotImplementedException();
    }
}
