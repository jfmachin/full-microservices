using Blue.WebApp.APIServices.APIRequests;

namespace Blue.WebApp.APIServices.Base {
    public interface IBaseService : IDisposable {
        Task<T> SendAync<T>(APIRequest request);
    }
}
