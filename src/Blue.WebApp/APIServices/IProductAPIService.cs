using Blue.WebApp.APIServices.Base;
using Blue.WebApp.Models;

namespace Blue.WebApp.APIServices {
    public interface IProductAPIService : IBaseService {
        Task<T> getAllProductsAsync<T>();
        Task<T> getProductByIdAsync<T>(int id);
        Task<T> createProductAsync<T>(ProductDTO product);
        Task<T> updateProductAsync<T>(ProductDTO product);
        Task<T> deleteProductAsync<T>(int id);
    }
}
