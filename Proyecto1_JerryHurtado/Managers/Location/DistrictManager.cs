using Newtonsoft.Json;
using Proyecto1_JerryHurtado.Infrastructure;
using Proyecto1_JerryHurtado.Managers.Interfaces.Location;
using Proyecto1_JerryHurtado.Models.Api;
using Proyecto1_JerryHurtado.Models.ViewModels.Location;

namespace Proyecto1_JerryHurtado.Managers.Location
{
    public class DistrictManager : IRelationalManager<DistrictVM>
    {
        private readonly HttpClient _client;

        public DistrictManager(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient(HttpClientNames.ApiClient);
        }

        public List<DistrictVM> GetAllById(int parentId)
        {
            var responseJson = _client.GetStringAsync($"Districts/{parentId}").Result;
            var result = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<DistrictVM>>>(responseJson);

            if (result?.Success == true && result.Data != null)
                return result.Data.ToList();

            return new List<DistrictVM>();
        }
    }
}