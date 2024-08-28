namespace Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IProductRepository
{
    List<Product> GetProducts(string orderSort);

    Product GetProductById(int productId);

    bool EditProduct(Product product);

}
