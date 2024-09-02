using Core;
using Microsoft.AspNetCore.Mvc;

namespace Mohamadreza_Amini_HW18.Controllers
{
    public class StoreController : Controller
    {
        private readonly IStoreRepository storeRepository;

        public StoreController(IStoreRepository store)
        {
            storeRepository = store;
        }

        public async Task<IActionResult> GetStores(string storeName,string zipCode)
        {
            return View(await storeRepository.GetStores(storeName, zipCode));
        }
    }
}
