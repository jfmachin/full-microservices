using Blue.WebApp.APIServices.APIRequests;
using Blue.WebApp.APIServices.Base;
using Blue.WebApp.Models;

namespace Blue.WebApp.APIServices {
    public class ProductAPIService : BaseService, IProductAPIService {
        public ProductAPIService(IHttpClientFactory clientFactory) : base(clientFactory) { }

        public async Task<T> createProductAsync<T>(ProductDTO product) {
            return await SendAync<T>(new ProductAPIRequest() {
                Method = HttpMethod.Post, 
                Data = product,
                Url = "/api/products",
            });
        }

        public async Task<T> deleteProductAsync<T>(int id) {
            return await SendAync<T>(new ProductAPIRequest() {
                Method = HttpMethod.Delete, 
                Url = $"/api/products/{id}",
            });
        }

        public async Task<T> getAllProductsAsync<T>() {
            return await SendAync<T>(new ProductAPIRequest() {
                Url = "/api/products",
            });
        }

        public async Task<T> getProductByIdAsync<T>(int id) {
            return await SendAync<T>(new ProductAPIRequest() {
                Url = $"/api/products/{id}",
            });
        }

        public async Task<T> updateProductAsync<T>(ProductDTO product) {
            return await SendAync<T>(new ProductAPIRequest() {
                Method = HttpMethod.Put, 
                Data = product,
                Url = "/api/products",
            });
        }
    }
}