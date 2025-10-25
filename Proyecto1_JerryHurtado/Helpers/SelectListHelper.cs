using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto1_JerryHurtado.Managers.Interfaces;
using Proyecto1_JerryHurtado.Managers.Interfaces.Location;
using Proyecto1_JerryHurtado.Models.ViewModels;
using Proyecto1_JerryHurtado.Models.ViewModels.Location;

namespace Proyecto1_JerryHurtado.Helpers
{
    /// <summary>
    /// Proporciona métodos auxiliares para construir listas desplegables (<see cref="SelectList"/>) a partir de distintos recursos del sistema.
    /// Facilita la carga de formularios mediante la transformación de datos en estructuras listas para UI.
    /// </summary>
    public static class SelectListHelper
    {
        #region Ubicación Geográfica

        /// <summary>
        /// Obtiene una lista de selección con todas las provincias disponibles.
        /// </summary>
        /// <param name="manager">Instancia de <see cref="IGetAllManager{ProvinceVM}"/> que proporciona los datos de provincias.</param>
        /// <returns>Una <see cref="SelectList"/> con los identificadores y nombres de las provincias.</returns>
        public static SelectList GetProvinces(IGetAllManager<ProvinceVM> manager) =>
            new(manager.GetAll().Select(x => new DropdownItemVM<int> { Id = x.Id, Name = x.Name }), "Id", "Name");

        /// <summary>
        /// Obtiene una lista de selección con los cantones asociados a una provincia específica.
        /// </summary>
        /// <param name="manager">Instancia de <see cref="IRelationalManager{CantonVM}"/> que proporciona los datos de cantones.</param>
        /// <param name="provinceId">Identificador de la provincia seleccionada.</param>
        /// <returns>Una <see cref="SelectList"/> con los cantones correspondientes.</returns>
        public static SelectList GetCantons(IRelationalManager<CantonVM> manager, int provinceId) =>
            new(manager.GetAllById(provinceId).Select(x => new DropdownItemVM<int> { Id = x.Id, Name = x.Name }), "Id", "Name");

        /// <summary>
        /// Obtiene una lista de selección con los distritos asociados a un cantón específico.
        /// </summary>
        /// <param name="manager">Instancia de <see cref="IRelationalManager{DistrictVM}"/> que proporciona los datos de distritos.</param>
        /// <param name="cantonId">Identificador del cantón seleccionado.</param>
        /// <returns>Una <see cref="SelectList"/> con los distritos correspondientes.</returns>
        public static SelectList GetDistricts(IRelationalManager<DistrictVM> manager, int cantonId) =>
            new(manager.GetAllById(cantonId).Select(x => new DropdownItemVM<int> { Id = x.Id, Name = x.Name }), "Id", "Name");

        #endregion Ubicación Geográfica

        #region Clientes

        /// <summary>
        /// Obtiene una lista de selección con todos los clientes disponibles.
        /// </summary>
        /// <param name="manager">Instancia de <see cref="IGetAllManager{CustomerVM}"/> que proporciona los datos de clientes.</param>
        /// <returns>Una <see cref="SelectList"/> con los identificadores y nombres de los clientes.</returns>
        public static SelectList GetCustomers(IGetAllManager<CustomerVM> manager) =>
            new(manager.GetAll().Select(x => new DropdownItemVM<Guid> { Id = x.Id, Name = x.Name }), "Id", "Name");

        #endregion Clientes

        #region Mascotas

        /// <summary>
        /// Obtiene una lista de selección con todas las mascotas asociadas a un cliente.
        /// </summary>
        /// <param name="manager">Instancia de <see cref="IManager{PetVM}"/> que proporciona las mascotas.</param>
        /// <returns>Una <see cref="SelectList"/> con los identificadores y nombres de las mascotas.</returns>
        public static SelectList GetPetsByCustomer(IManager<PetVM> manager, Guid customerId) =>
            new(manager.GetAll()
                .Where(x => x.CustomerId == customerId)
                .Select(x => new DropdownItemVM<Guid> { Id = x.Id, Name = x.Name }), "Id", "Name");

        #endregion
    }
}