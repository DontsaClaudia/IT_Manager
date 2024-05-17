using GesParck.Models;

namespace GesParck.Services
{
    public class ServiceComputers
    {
        private readonly HttpClient _httpClient;
        public ServiceComputers(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
    }
}
