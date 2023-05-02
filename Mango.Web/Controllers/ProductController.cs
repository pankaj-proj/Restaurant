using Microsoft.AspNetCore.Mvc;
using Mango.Web.Services.IServices;
using Mango.Web.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Mango.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productservice)
        {
            _productService = productservice;
        }
        public async Task<IActionResult> ProductIndex()
        {
            List<ProductDto> list = new();

            var response = await _productService.GetAllProductAsync<ResponseDto>();
            if(response!=null &&  response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
            }
            return View(list);
        }

        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }

      [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductCreate(ProductDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.CreateProductAsync<ResponseDto>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction("ProductIndex");
                }
            }
            return View(model);
        }
    }
}
