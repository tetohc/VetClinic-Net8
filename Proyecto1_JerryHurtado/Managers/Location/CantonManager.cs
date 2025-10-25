using Newtonsoft.Json;
using Proyecto1_JerryHurtado.Infrastructure;
using Proyecto1_JerryHurtado.Managers.Interfaces.Location;
using Proyecto1_JerryHurtado.Models.Api;
using Proyecto1_JerryHurtado.Models.ViewModels.Location;

namespace Proyecto1_JerryHurtado.Managers.Location
{
    public class CantonManager : IRelationalManager<CantonVM>
    {
        private readonly HttpClient _client;

        public CantonManager(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient(HttpClientNames.ApiClient);
        }

        public List<CantonVM> GetAllById(int parentId)
        {
            var responseJson = _client.GetStringAsync($"Cantons/{parentId}").Result;
            var result = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<CantonVM>>>(responseJson);

            if (result?.Success == true && result.Data != null)
                return result.Data.ToList();

            return new List<CantonVM>();
        }
    }
}