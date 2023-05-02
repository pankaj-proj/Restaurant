using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Mango.Web.Models;

namespace Mango.Web.Services.IServices
{
    public interface IProductService
    {
        Task<T> GetAllProductAsync<T>();
        Task<T> GetProductByIdAsync<T>(int id);
        Task<T> CreateProductAsync<T>(ProductDto productDto);
        Task<T> DeleteProductAsync<T>(int id);
        Task<T> UpdateProductAsync<T>(ProductDto productDto);

    }
}
