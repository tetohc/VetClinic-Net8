using Newtonsoft.Json;
using Proyecto1_JerryHurtado.Infrastructure;
using Proyecto1_JerryHurtado.Managers.Interfaces;
using Proyecto1_JerryHurtado.Models.Api;
using Proyecto1_JerryHurtado.Models.Entities;
using Proyecto1_JerryHurtado.Models.ViewModels;

namespace Proyecto1_JerryHurtado.Managers
{
    public class ReportManager : IGetAllManager<ReportVM>
    {
        private const string BaseEndpoint = "reports";
        private readonly HttpClient _client;

        public ReportManager(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient(HttpClientNames.ApiClient);
        }

        public List<ReportVM> GetAll()
        {
            var responseJson = _client.GetStringAsync(BaseEndpoint).Result;
            var result = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<ReportVM>>>(responseJson);

            if (result?.Success != true || result.Data == null)
                return new();

            return result.Data
                .Select(report => new ReportVM
                {
                    Customer = report.Customer ?? new CustomerVM(),
                    Pet = report.Pet ?? new PetVM(),
                    ProjectedProcedure = report.ProjectedProcedure ?? new ProcedureTypeVM()
                })
                .ToList();
        }
    }
}