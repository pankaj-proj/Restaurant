using Mango.Web.Models;
using Mango.Web.Services.IServices;

namespace Mango.Web.Services
{
    public class ProductService:BaseService,IProductService
    {
        private readonly IHttpClientFactory _clientFactory;

        public ProductService(IHttpClientFactory clientFactory):base(clientFactory) 
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> CreateProductAsync<T>(ProductDto productDto)
        {
           return await this.SendAsync<T>(new ApiRequest()
            {
                apiType = SD.APIType.POST,
                Data= productDto,
                Url=SD.ProductAPIBase + "/api/products",
                AccessToken=""
            }); 
        }

        public async Task<T> DeleteProductAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                apiType = SD.APIType.DELETE,
                Url = SD.ProductAPIBase + "/api/products"+id,
                AccessToken = ""
            });
        }

        public async Task<T> GetAllProductAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                apiType = SD.APIType.GET,
                Url = SD.ProductAPIBase + "/api/products",
                AccessToken = ""
            });
        }

        public async Task<T> GetProductByIdAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                apiType = SD.APIType.GET,
                Url = SD.ProductAPIBase + "/api/products" +id,
                AccessToken = ""
            });
        }

        public async Task<T> UpdateProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                apiType = SD.APIType.PUT,
                Data = productDto,
                Url = SD.ProductAPIBase + "/api/products",
                AccessToken = ""
            });
        }


    }
}
