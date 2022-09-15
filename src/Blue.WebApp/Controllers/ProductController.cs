using Blue.WebApp.APIServices;
using Blue.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blue.WebApp.Controllers {
    public class ProductController : Controller {
        private readonly IProductAPIService productAPIService;

        public ProductController(IProductAPIService productAPIService) {
            this.productAPIService = productAPIService;
        }
        public async Task<IActionResult> list() {
            List<ProductDTO> list = new();
            var response = await productAPIService.getAllProductsAsync<List<ProductDTO>>();
            if (response != null)
                list = response;

            return View(list);
        }
        public async Task<IActionResult> create() {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> create(ProductDTO productDTO) {
            ProductDTO product = null;
            var response = await productAPIService.createProductAsync<ProductDTO>(productDTO);
            if(response != null)
                return RedirectToAction(nameof(list));
            return View(productDTO);
        }

        public async Task<IActionResult> update(int id) {
            var response = await productAPIService.getProductByIdAsync<ProductDTO>(id);
            if (response != null)
                return View(response);
            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> update(ProductDTO productDTO) {
            ProductDTO product = null;
            var response = await productAPIService.updateProductAsync<ProductDTO>(productDTO);
            if(response != null)
                return RedirectToAction(nameof(list));
            return View(productDTO);
        }

        public async Task<IActionResult> delete(int id) {
            var response = await productAPIService.getProductByIdAsync<ProductDTO>(id);
            if (response != null)
                return View(response);
            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> delete(ProductDTO productDTO) {
            ProductDTO product = null;
            var response = await productAPIService.deleteProductAsync<ProductDTO>(productDTO.ProductId);
            if(response != null)
                return RedirectToAction(nameof(list));
            return View(productDTO);
        }
    }
}
