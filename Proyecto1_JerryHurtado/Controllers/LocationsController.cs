using Microsoft.AspNetCore.Mvc;
using Proyecto1_JerryHurtado.Helpers;
using Proyecto1_JerryHurtado.Managers.Interfaces.Location;
using Proyecto1_JerryHurtado.Models.ViewModels.Location;

namespace Proyecto1_JerryHurtado.Controllers
{
    public class LocationsController
        (
            IRelationalManager<CantonVM> _cantonManager,
            IRelationalManager<DistrictVM> _districtManager
        ) : Controller
    {
        [HttpGet]
        public IActionResult GetCantons(int provinceId)
        {
            var cantons = SelectListHelper.GetCantons(_cantonManager, provinceId);
            return Json(cantons);
        }

        [HttpGet]
        public IActionResult GetDistricts(int cantonId)
        {
            var districts = SelectListHelper.GetDistricts(_districtManager, cantonId);
            return Json(districts);
        }
    }
}