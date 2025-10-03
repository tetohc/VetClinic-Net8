using Microsoft.AspNetCore.Mvc;
using Proyecto1_JerryHurtado.Helpers;
using Proyecto1_JerryHurtado.Managers.Interfaces;
using Proyecto1_JerryHurtado.Managers.Interfaces.Location;
using Proyecto1_JerryHurtado.Models.Enums;
using Proyecto1_JerryHurtado.Models.ViewModels;
using Proyecto1_JerryHurtado.Models.ViewModels.Location;

namespace Proyecto1_JerryHurtado.Controllers
{
    public class CustomersController
        (
            IManager<CustomerVM> _manager,
            IReadOnlyManager<ProvinceVM> _provinceManager,
            IRelationalManager<CantonVM> _cantonManager,
            IRelationalManager<DistrictVM> _districtManager
        ) : Controller
    {
        #region CRUD Vistas

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Detail(Guid id, int origin = (int)ViewOrigin.Index)
        {
            var data = _manager.GetById(id);
            if (data == null)
                return NotFound();

            ViewBag.ReturnUrl = NavigationHelper.GetReturnUrl(this, (ViewOrigin)origin, "Customers");
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.ContactPreference = EnumHelper.GetEnumSelectList<ContactPreference>();
            ViewBag.Province = LocationHelper.GetProvinces(_provinceManager);
            return View();
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var viewModel = _manager.GetById(id);
            if (viewModel == null)
                return NotFound();

            LocationHelper.AssignLocationIds(viewModel, _provinceManager, _cantonManager, _districtManager);
            ViewBag.ContactPreference = EnumHelper.GetEnumSelectList<ContactPreference>();
            ViewBag.Province = LocationHelper.GetProvinces(_provinceManager);
            ViewBag.Canton = LocationHelper.GetCantons(_cantonManager, viewModel.ProvinceId);
            ViewBag.District = LocationHelper.GetDistricts(_districtManager, viewModel.CantonId);
            return View(viewModel);
        }

        #endregion CRUD Vistas

        #region CRUD JSON

        [HttpGet]
        public IActionResult GetCustomers() => CrudActionHelper.GetList(_manager);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CustomerVM viewModel)
        {
            LocationHelper.AssignLocationNames(viewModel, _provinceManager, _cantonManager, _districtManager);
            return CrudActionHelper.Create(_manager, viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CustomerVM viewModel)
        {
            LocationHelper.AssignLocationNames(viewModel, _provinceManager, _cantonManager, _districtManager);
            return CrudActionHelper.Edit(_manager, viewModel);
        }

        [HttpDelete]
        public IActionResult Delete(Guid id) => CrudActionHelper.Delete(_manager, id);

        #endregion CRUD JSON
    }
}