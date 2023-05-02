using Mango.Services.ProductAPI.Models.Dto;
using Mango.Services.ProductAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.ProductAPI.Controllers
{
    [Route("api/products")]
    public class ProructController : ControllerBase
    {
        protected ResponseDto _response;
        private IProductRepository _productReponsitory;

        public ProructController(IProductRepository productRepostiory)
        {
            _productReponsitory = productRepostiory;
            this._response = new ResponseDto();

        }

        [HttpGet]
        public async Task<ResponseDto> Get()
        {
            try
            {
                IEnumerable<ProductDto> productDto = await _productReponsitory.GetProducts();
                _response.Result = productDto;
            }
            catch (Exception ex) {

                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }
            return _response;

        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ResponseDto> Get(int id)
        {
            try
            {
                ProductDto productDto = await _productReponsitory.GetProductById(id);
                _response.Result = productDto;
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }
            return _response;

        }

        [HttpDelete]
        public async Task<ResponseDto> Delete(int id)
        {
            try
            {
                bool isSucess = await _productReponsitory.DeleteProduct(id);
                _response.Result = true;
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpPost]
       
        public async Task<ResponseDto> Post([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto model = await _productReponsitory.CreateUpdateProduct(productDto);
                _response.Result = model;
                _response.IsSuccess = true;
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }
            return _response;

        }
        [HttpPut]
        public async Task<ResponseDto> Put([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto model = await _productReponsitory.CreateUpdateProduct(productDto);
                _response.Result = model;
                _response.IsSuccess = true;
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> {ex.ToString()};
            }
            return _response;

        }
    }
}
