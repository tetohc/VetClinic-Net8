using Microsoft.AspNetCore.Mvc;
using Proyecto1_JerryHurtado.Helpers;
using Proyecto1_JerryHurtado.Managers.Interfaces;
using Proyecto1_JerryHurtado.Models.Enums;
using Proyecto1_JerryHurtado.Models.ViewModels;

namespace Proyecto1_JerryHurtado.Controllers
{
    public class SearchController : Controller
    {
        private readonly IManager<EmployeeVM> _employeeManager;
        private readonly IManager<PetVM> _petManager;
        private readonly IManager<CustomerVM> _customerManager;
        private readonly IManager<ProcedureVM> _procedureManager;

        public SearchController(IManager<EmployeeVM> employeeManager,
                IManager<PetVM> petManager,
                IManager<CustomerVM> customerManager,
                IManager<ProcedureVM> procedureManager)
        {
            _employeeManager = employeeManager;
            _petManager = petManager;
            _customerManager = customerManager;
            _procedureManager = procedureManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.EntityTypes = EnumHelper.GetEnumSelectList<EntityType>();
            return View();
        }

        [HttpGet]
        public IActionResult Filter(SearchVM viewModel)
        {
            var data = viewModel.EntityType switch
            {
                EntityType.Customer => _customerManager.Search(viewModel.Query.Trim()).Select(x => new SearchResultVM
                {
                    Title = x.FullName,
                    Description1 = x.Province,
                    Description2 = $"Cantón: {x.Canton}",
                    DetailUrl = Url.Action("Detail", "Customers", new { id = x.Id, origin = (int)ViewOrigin.Search })!,
                    ImageUrl = "/icons/customer.svg",
                    Type = EnumHelper.GetDisplayName(EntityType.Customer)
                }),
                EntityType.Employee => _employeeManager.Search(viewModel.Query.Trim()).Select(x => new SearchResultVM
                {
                    Title = x.TypeDisplay,
                    Description1 = $"Cédula: {x.PersonalIdNumber}",
                    Description2 = $"Salario: ₡{x.DailySalary.ToString("N2")}",
                    DetailUrl = Url.Action("Detail", "Employees", new { id = x.Id, origin = (int)ViewOrigin.Search })!,
                    ImageUrl = "/icons/employee.svg",
                    Type = EnumHelper.GetDisplayName(EntityType.Employee)
                }),
                EntityType.Pet => _petManager.Search(viewModel.Query.Trim()).Select(x => new SearchResultVM
                {
                    Title = x.PetSpeciesDisplay,
                    Description1 = $"Raza: {x.Race}",
                    Description2 = $"Edad: {x.Age}",
                    DetailUrl = Url.Action("Detail", "Pets", new { id = x.Id, origin = (int)ViewOrigin.Search })!,
                    ImageUrl = "/icons/pets.svg",
                    Type = EnumHelper.GetDisplayName(EntityType.Pet)
                }),
                EntityType.Procedure => _procedureManager.Search(viewModel.Query.Trim()).Select(x => new SearchResultVM
                {
                    Title = x.PetName,
                    Description1 = $"{x.StatusDisplay}",
                    Description2 = $"Cédula del propietario: {x.OwnerIdNumber}",
                    DetailUrl = Url.Action("Detail", "Procedures", new { id = x.Id, origin = (int)ViewOrigin.Search })!,
                    ImageUrl = "/icons/procedure.svg",
                    Type = EnumHelper.GetDisplayName(EntityType.Procedure)
                }),
                _ => Enumerable.Empty<SearchResultVM>()
            };
            return Json(new { data });
        }
    }
}