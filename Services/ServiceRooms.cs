namespace GesPark.Services
{
    public class ServiceRooms
    {
        private readonly HttpClient _httpClient;
        public ServiceNetworks(HttpClient httpClient)
        {

            _httpClient = httpClient;

        }
    }
}
