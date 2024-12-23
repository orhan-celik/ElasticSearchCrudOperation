using ElasticSearchCrudOperation.API.DTOs;
using ElasticSearchCrudOperation.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElasticSearchCrudOperation.API.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductCreateDto request)
        {
            var result = await _productService.SaveAsync(request);
            return CreateActionResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productService.GetAllAsync();
            return CreateActionResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var response = await _productService.GetByIdAsync(id);
            return CreateActionResult(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto request)
        {
            var response = await _productService.UpdateAsync(request);
            return CreateActionResult(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _productService.DeleteAsync(id);
            return CreateActionResult(response);
        }
    }
}
