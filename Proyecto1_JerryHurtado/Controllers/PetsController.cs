using Microsoft.AspNetCore.Mvc;
using Proyecto1_JerryHurtado.Helpers;
using Proyecto1_JerryHurtado.Managers.Interfaces;
using Proyecto1_JerryHurtado.Models.Enums;
using Proyecto1_JerryHurtado.Models.ViewModels;

namespace Proyecto1_JerryHurtado.Controllers
{
    public class PetsController(
        IManager<PetVM> _manager,
        IGetAllManager<CustomerVM> _getAllManager) : Controller
    {
        #region CRUD Vistas

        [HttpGet]
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

            ViewBag.ReturnUrl = NavigationHelper.GetReturnUrl(this, (ViewOrigin)origin, "Pets");
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.PetSpecies = EnumHelper.GetEnumSelectList<PetSpecies>().OrderBy(x => Convert.ToInt32(x.Value));
            ViewBag.CustomerId = SelectListHelper.GetCustomers(_getAllManager);
            return View();
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var data = _manager.GetById(id);
            if (data == null)
                return NotFound();

            ViewBag.PetSpecies = EnumHelper.GetEnumSelectList<PetSpecies>().OrderBy(x => Convert.ToInt32(x.Value));
            ViewBag.CustomerId = SelectListHelper.GetCustomers(_getAllManager);
            return View(data);
        }

        #endregion CRUD Vistas

        #region CRUD JSON

        [HttpGet]
        public IActionResult GetPets() => CrudActionHelper.GetList(_manager);

        [HttpGet]
        public IActionResult GetPetByCustomer(Guid customerId)
        {
            var data = SelectListHelper.GetPetsByCustomer(_manager, customerId);
            return Json(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PetVM viewModel) => CrudActionHelper.Create(_manager, viewModel);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PetVM viewModel) => CrudActionHelper.Edit(_manager, viewModel);

        [HttpDelete]
        public IActionResult Delete(Guid id) => CrudActionHelper.Delete(_manager, id);

        #endregion CRUD JSON
    }
}