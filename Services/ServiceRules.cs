namespace GesPark.Services
{
    public class ServiceRules
    {
        private readonly HttpClient _httpClient;
        public ServiceNetworks(HttpClient httpClient)
        {

            _httpClient = httpClient;

        }
    }
}
