namespace Dumb.Domain.Entities
{
    public class ApiHelper
    {
        public HttpClient ApiClient { get; set; }

        public ApiHelper(HttpClient apiClient)
        {
            ApiClient = apiClient;
        }
    }
}
