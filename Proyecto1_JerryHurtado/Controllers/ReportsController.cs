using Microsoft.AspNetCore.Mvc;
using Proyecto1_JerryHurtado.Helpers;
using Proyecto1_JerryHurtado.Managers.Interfaces;
using Proyecto1_JerryHurtado.Models.Enums;
using Proyecto1_JerryHurtado.Models.ViewModels;

namespace Proyecto1_JerryHurtado.Controllers
{
    public class ReportsController(IGetAllManager<ReportVM> _reportManager) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Reports = _reportManager.GetAll();
            return View();
        }
    }
}