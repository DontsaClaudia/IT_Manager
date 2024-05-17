namespace GesPark.Services
{
    public class ServiceNetworks
    {
        private readonly HttpClient _httpClient;
        public ServiceNetworks(HttpClient httpClient)
        {

            _httpClient = httpClient;

        }
    }
    
}
