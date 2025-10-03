using Microsoft.AspNetCore.Mvc;
using Proyecto1_JerryHurtado.Managers;
using Proyecto1_JerryHurtado.Managers.Interfaces;
using Proyecto1_JerryHurtado.Models;
using Proyecto1_JerryHurtado.Models.ViewModels;
using System.Diagnostics;

namespace Proyecto1_JerryHurtado.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IManager<EmployeeVM> _employeeManager;
        private readonly IManager<PetVM> _petManager;
        private readonly IManager<CustomerVM> _customerManager;
        private readonly IManager<ProcedureVM> _procedureManager;

        public HomeController
            (
                ILogger<HomeController> logger,
                IManager<EmployeeVM> employeeManager,
                IManager<PetVM> petManager,
                IManager<CustomerVM> customerManager,
                IManager<ProcedureVM> procedureManager
            )
        {
            _logger = logger;
            _employeeManager = employeeManager;
            _petManager = petManager;
            _customerManager = customerManager;
            _procedureManager = procedureManager;
        }

        public IActionResult Index()
        {
            ViewBag.EmployeeCount = _employeeManager.Count();
            ViewBag.ClientCount = _customerManager.Count();
            ViewBag.PetCount = _petManager.Count();
            ViewBag.ProcedureCount = _procedureManager.Count();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}