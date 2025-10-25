using Newtonsoft.Json;
using Proyecto1_JerryHurtado.Infrastructure;
using Proyecto1_JerryHurtado.Managers.Interfaces;
using Proyecto1_JerryHurtado.Mappers;
using Proyecto1_JerryHurtado.Models.Api;
using Proyecto1_JerryHurtado.Models.Entities;
using Proyecto1_JerryHurtado.Models.ViewModels;
using System.Text;

namespace Proyecto1_JerryHurtado.Managers
{
    public class ProcedureManager : IManager<ProcedureVM>
    {
        private const string BaseEndpoint = "pets-procedures";
        private const string ListEndpoint = BaseEndpoint;
        private const string SearchEndpoint = BaseEndpoint;
        private const string CountEndpoint = $"{BaseEndpoint}/count";

        private readonly HttpClient _client;

        public ProcedureManager(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient(HttpClientNames.ApiClient);
        }

        public bool Create(ProcedureVM viewModel)
        {
            var serializedItem = JsonConvert.SerializeObject(viewModel.ToEntity());
            var content = new StringContent(serializedItem, Encoding.UTF8, "application/json");
            var response = _client.PostAsync($"{BaseEndpoint}", content).Result;
            return response.IsSuccessStatusCode;
        }

        public bool Update(ProcedureVM viewModel)
        {
            if (viewModel.Id == Guid.Empty)
                return false;

            var serializedItem = JsonConvert.SerializeObject(viewModel.ToEntity());
            var content = new StringContent(serializedItem, Encoding.UTF8, "application/json");
            var response = _client.PutAsync($"{BaseEndpoint}/{viewModel.Id}", content).Result;

            return response.IsSuccessStatusCode;
        }

        public bool Delete(Guid id)
        {
            var response = _client.DeleteAsync($"{BaseEndpoint}/{id}").Result;
            return response.IsSuccessStatusCode;
        }

        public ProcedureVM? GetById(Guid id)
        {
            var responseJson = _client.GetStringAsync($"{BaseEndpoint}/{id}").Result;
            var result = JsonConvert.DeserializeObject<ApiResponse<ProcedureEntity>>(responseJson);
            return result?.Data?.ToViewModel();
        }

        public List<ProcedureVM> GetAll()
        {
            var responseJson = _client.GetStringAsync(ListEndpoint).Result;
            var result = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<ProcedureEntity>>>(responseJson);

            if (result?.Success == true && result.Data != null)
                return result.Data.ToViewModelList();

            return new List<ProcedureVM>();
        }

        public List<ProcedureVM> Search(string query)
        {
            var encodedQuery = Uri.EscapeDataString(query);
            var responseJson = _client.GetStringAsync($"{SearchEndpoint}?query={encodedQuery}").Result;
            var response = JsonConvert.DeserializeObject<ApiResponse<List<ProcedureEntity>>>(responseJson);

            if (response?.Success == true && response.Data != null)
                return response.Data.ToViewModelList();

            return new List<ProcedureVM>();
        }

        public int Count()
        {
            var responseJson = _client.GetStringAsync(CountEndpoint).Result;
            var result = JsonConvert.DeserializeObject<ApiResponse<int>>(responseJson);
            return result?.Data ?? 0;
        }
    }
}