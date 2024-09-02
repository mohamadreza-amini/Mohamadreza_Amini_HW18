using Core;
using Microsoft.AspNetCore.Mvc;

namespace Mohamadreza_Amini_HW18.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository product)
        {
   
            productRepository = product;
        }

        public async Task<IActionResult> GetProducts(int storeId, string? sortOrder)
        {
            ViewBag.StoreId = storeId;
            return View(await productRepository.GetProducts(storeId, sortOrder));
        }

        public async Task<IActionResult> GetproductById(int productId)
        {
            return View("EditProduct",await productRepository.GetProductById(productId));
        }

        public async Task<IActionResult> EditProduct(Product product)
        {
            await productRepository.EditProduct(product);
            return RedirectToAction("GetproductById", new { productId = product.product_id});
        }
    }

}
