using Microsoft.AspNetCore.Mvc;
using Proyecto1_JerryHurtado.Helpers;
using Proyecto1_JerryHurtado.Managers.Interfaces;
using Proyecto1_JerryHurtado.Models.Enums;
using Proyecto1_JerryHurtado.Models.ViewModels;

namespace Proyecto1_JerryHurtado.Controllers
{
    public class EmployeesController(IManager<EmployeeVM> _manager) : Controller
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

            ViewBag.ReturnUrl = NavigationHelper.GetReturnUrl(this, (ViewOrigin)origin, "Employees");
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.EmployeeTypes = EnumHelper.GetEnumSelectList<EmployeeType>();
            return View();
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var data = _manager.GetById(id);
            if (data == null)
                return NotFound();
            ViewBag.EmployeeTypes = EnumHelper.GetEnumSelectList<EmployeeType>();
            return View(data);
        }

        #endregion CRUD Vistas

        #region CRUD JSON

        [HttpGet]
        public IActionResult GetEmployees() => CrudActionHelper.GetList(_manager);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeVM viewModel) => CrudActionHelper.Create(_manager, viewModel);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EmployeeVM viewModel) => CrudActionHelper.Edit(_manager, viewModel);

        [HttpDelete]
        public IActionResult Delete(Guid id) => CrudActionHelper.Delete(_manager, id);

        #endregion CRUD JSON
    }
}