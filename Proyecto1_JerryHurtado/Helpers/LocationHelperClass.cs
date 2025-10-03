using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto1_JerryHurtado.Managers.Interfaces;
using Proyecto1_JerryHurtado.Managers.Interfaces.Location;
using Proyecto1_JerryHurtado.Models.ViewModels;
using Proyecto1_JerryHurtado.Models.ViewModels.Location;

namespace Proyecto1_JerryHurtado.Helpers
{
    /// <summary>
    /// Proporciona métodos auxiliares para manejar ubicaciones geográficas como provincias, cantones y distritos.
    /// Facilita la carga de listas desplegables y la conversión entre identificadores y nombres.
    /// </summary>
    public static class LocationHelper
    {
        /// <summary>
        /// Obtiene una lista de selección con todas las provincias disponibles.
        /// </summary>
        /// <param name="manager">Instancia de <see cref="IReadOnlyManager{ProvinceVM}"/> que proporciona los datos de provincias.</param>
        /// <returns>Una <see cref="SelectList"/> con los identificadores y nombres de las provincias.</returns>
        public static SelectList GetProvinces(IReadOnlyManager<ProvinceVM> manager) =>
            new(manager.GetAll().Select(x => new DropdownItemVM { Id = x.Id, Name = x.Name }), "Id", "Name");

        /// <summary>
        /// Obtiene una lista de selección con los cantones asociados a una provincia específica.
        /// </summary>
        /// <param name="manager">Instancia de <see cref="IRelationalManager{CantonVM}"/> que proporciona los datos de cantones.</param>
        /// <param name="provinceId">Identificador de la provincia seleccionada.</param>
        /// <returns>Una <see cref="SelectList"/> con los cantones correspondientes.</returns>
        public static SelectList GetCantons(IRelationalManager<CantonVM> manager, int provinceId) =>
            new(manager.GetAllById(provinceId).Select(x => new DropdownItemVM { Id = x.Id, Name = x.Name }), "Id", "Name");

        /// <summary>
        /// Obtiene una lista de selección con los distritos asociados a un cantón específico.
        /// </summary>
        /// <param name="manager">Instancia de <see cref="IRelationalManager{DistrictVM}"/> que proporciona los datos de distritos.</param>
        /// <param name="cantonId">Identificador del cantón seleccionado.</param>
        /// <returns>Una <see cref="SelectList"/> con los distritos correspondientes.</returns>
        public static SelectList GetDistricts(IRelationalManager<DistrictVM> manager, int cantonId) =>
            new(manager.GetAllById(cantonId).Select(x => new DropdownItemVM { Id = x.Id, Name = x.Name }), "Id", "Name");

        /// <summary>
        /// Asigna los nombres de provincia, cantón y distrito a un objeto <see cref="CustomerVM"/>
        /// a partir de sus identificadores respectivos.
        /// </summary>
        /// <param name="viewModel">Instancia de <see cref="CustomerVM"/> que contiene los identificadores.</param>
        /// <param name="provinceManager">Manager de provincias.</param>
        /// <param name="cantonManager">Manager de cantones.</param>
        /// <param name="districtManager">Manager de distritos.</param>
        public static void AssignLocationNames(CustomerVM viewModel,
            IReadOnlyManager<ProvinceVM> provinceManager,
            IRelationalManager<CantonVM> cantonManager,
            IRelationalManager<DistrictVM> districtManager)
        {
            viewModel.Province = provinceManager.GetById(viewModel.ProvinceId)?.Name ?? "";
            viewModel.Canton = cantonManager.GetById(viewModel.CantonId)?.Name ?? "";
            viewModel.District = districtManager.GetById(viewModel.DistrictId)?.Name ?? "";
        }

        /// <summary>
        /// Asigna los identificadores de provincia, cantón y distrito a un objeto <see cref="CustomerVM"/>
        /// a partir de sus nombres respectivos.
        /// </summary>
        /// <param name="viewModel">Instancia de <see cref="CustomerVM"/> que contiene los nombres.</param>
        /// <param name="provinceManager">Manager de provincias.</param>
        /// <param name="cantonManager">Manager de cantones.</param>
        /// <param name="districtManager">Manager de distritos.</param>
        public static void AssignLocationIds(CustomerVM viewModel,
            IReadOnlyManager<ProvinceVM> provinceManager,
            IRelationalManager<CantonVM> cantonManager,
            IRelationalManager<DistrictVM> districtManager)
        {
            viewModel.ProvinceId = provinceManager.GetAll().FirstOrDefault(x => x.Name == viewModel.Province)?.Id ?? 1;
            viewModel.CantonId = cantonManager.GetAllById(viewModel.ProvinceId).FirstOrDefault(x => x.Name == viewModel.Canton)?.Id ?? 1;
            viewModel.DistrictId = districtManager.GetAllById(viewModel.CantonId).FirstOrDefault(x => x.Name == viewModel.District)?.Id ?? 1;
        }
    }
}