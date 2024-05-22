namespace GesPark.Services
{
    public class ServiceUsers
    {
        private readonly HttpClient _httpClient;
        public ServiceNetworks(HttpClient httpClient)
        {

            _httpClient = httpClient;

        }

    }
}
