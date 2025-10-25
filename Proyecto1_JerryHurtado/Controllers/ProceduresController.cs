using Microsoft.AspNetCore.Mvc;
using Proyecto1_JerryHurtado.Helpers;
using Proyecto1_JerryHurtado.Managers;
using Proyecto1_JerryHurtado.Managers.Interfaces;
using Proyecto1_JerryHurtado.Models.Enums;
using Proyecto1_JerryHurtado.Models.ViewModels;

namespace Proyecto1_JerryHurtado.Controllers
{
    public class ProceduresController
        (
            IManager<ProcedureVM> _procedureManager,
            IReadOnlyManager<ProcedureTypeVM> _procedureTypeManager,
            IGetAllManager<CustomerVM> _customerGetAllManager
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
            var data = _procedureManager.GetById(id);
            if (data == null)
                return NotFound();

            var procedureType = _procedureTypeManager.GetById(data.ProcedureTypeId)!;
            data.ProcedureType = procedureType!;

            ViewBag.ReturnUrl = NavigationHelper.GetReturnUrl(this, (ViewOrigin)origin, "Procedures");
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.ProcedureType = _procedureTypeManager.GetAll();
            ViewBag.CustomerId = SelectListHelper.GetCustomers(_customerGetAllManager);
            ViewBag.Status = EnumHelper.GetEnumSelectList<ProcedureStatus>();
            return View();
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var data = _procedureManager.GetById(id);
            if (data == null)
                return NotFound();

            var procedureType = _procedureTypeManager.GetById(data.ProcedureTypeId);
            data.ProcedureType = procedureType!;

            ViewBag.ProcedureType = _procedureTypeManager.GetAll();
            ViewBag.Status = EnumHelper.GetEnumSelectList<ProcedureStatus>();
            return View(data);
        }

        #endregion CRUD Vistas

        #region CRUD JSON

        [HttpGet]
        public IActionResult GetProcedures()
        {
            var data = _procedureManager.GetAll();
            data.ForEach(procedure =>
            {
                procedure.ProcedureType = _procedureTypeManager.GetById(procedure.ProcedureTypeId)!;
            });
            return new JsonResult(new { data });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProcedureVM viewModel) => CrudActionHelper.Create(_procedureManager, viewModel);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProcedureVM viewModel) => CrudActionHelper.Edit(_procedureManager, viewModel);

        [HttpDelete]
        public IActionResult Delete(Guid id) => CrudActionHelper.Delete(_procedureManager, id);

        #endregion CRUD JSON
    }
}