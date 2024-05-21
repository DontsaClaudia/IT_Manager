namespace GesParck.Services
{
    public class ServiceParks
    {
        private readonly HttpClient _httpClient;
        public ServiceNetworks(HttpClient httpClient)
        {

            _httpClient = httpClient;

        }
    }
}
