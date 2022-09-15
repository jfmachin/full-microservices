namespace Blue.WebApp.APIServices.APIRequests {
    public abstract class APIRequest {
        public abstract string HttpClient { get; }
        public HttpMethod Method { get; set; } = HttpMethod.Get;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}
