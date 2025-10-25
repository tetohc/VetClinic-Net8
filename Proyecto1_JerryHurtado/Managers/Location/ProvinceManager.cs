using Newtonsoft.Json;
using Proyecto1_JerryHurtado.Infrastructure;
using Proyecto1_JerryHurtado.Managers.Interfaces;
using Proyecto1_JerryHurtado.Models.Api;
using Proyecto1_JerryHurtado.Models.ViewModels.Location;

namespace Proyecto1_JerryHurtado.Managers.Location
{
    public class ProvinceManager : IGetAllManager<ProvinceVM>
    {
        private readonly HttpClient _client;

        public ProvinceManager(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient(HttpClientNames.ApiClient);
        }

        public List<ProvinceVM> GetAll()
        {
            var responseJson = _client.GetStringAsync("Provinces").Result;
            var result = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<ProvinceVM>>>(responseJson);

            if (result?.Success == true && result.Data != null)
                return result.Data.ToList();

            return new List<ProvinceVM>();
        }
    }
}