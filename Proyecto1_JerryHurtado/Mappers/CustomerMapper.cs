using Proyecto1_JerryHurtado.Helpers;
using Proyecto1_JerryHurtado.Models.Entities;
using Proyecto1_JerryHurtado.Models.Enums;
using Proyecto1_JerryHurtado.Models.ViewModels;

namespace Proyecto1_JerryHurtado.Mappers
{
    /// <summary>
    /// Esta clase se encarga de mapear entre CustomerEntity y el ViewModel.
    /// </summary>
    public static class CustomerMapper
    {
        /// <summary>
        /// Convierte la instancia especificada de <see cref="CustomerVM"/> en una instancia de <see cref="CustomerEntity"/>.
        /// </summary>
        /// <param name="viewModel">La instancia especificada de <see cref="CustomerVM"/> que se va a convertir.</param>
        /// <returns>Instancia de <see cref="CustomerEntity"/> con los datos correspondientes del parámetro <paramref name="viewModel"/>.</returns>
        public static CustomerEntity ToEntity(this CustomerVM viewModel) =>
            new()
            {
                Id = viewModel.Id,
                PersonalIdNumber = viewModel.PersonalIdNumber.Trim(),
                Name = viewModel.Name.Trim(),
                ProvinceId = viewModel.ProvinceId,
                CantonId = viewModel.CantonId,
                DistrictId = viewModel.DistrictId,
                Address = viewModel.Address.Trim(),
                Email = viewModel.Email.Trim(),
                PhoneNumber = viewModel.PhoneNumber.Trim(),
                ContactPreference = viewModel.ContactPreference
            };

        /// <summary>
        /// Convierte la instancia especificada de <see cref="CustomerEntity"/> en una instancia de <see cref="CustomerVM"/>.
        /// </summary>
        /// <param name="entity">La instancia especificada de <see cref="CustomerEntity"/> que se va a convertir.</param>
        /// <returns>Instancia de <see cref="CustomerVM"/> con los datos correspondientes del parámetro <paramref name="entity"/>.</returns>
        public static CustomerVM ToViewModel(this CustomerEntity entity) =>
            new()
            {
                Id = entity.Id,
                PersonalIdNumber = entity?.PersonalIdNumber?.Trim() ?? string.Empty,
                Name = entity?.Name?.Trim() ?? string.Empty,
                ProvinceId = entity?.ProvinceId ?? 0,
                CantonId = entity?.CantonId ?? 0,
                DistrictId = entity?.DistrictId ?? 0,
                Province = entity?.Province?.Trim() ?? string.Empty,
                Canton = entity?.Canton?.Trim() ?? string.Empty,
                District = entity?.District?.Trim() ?? string.Empty,
                Address = entity?.Address?.Trim() ?? string.Empty,
                Email = entity?.Email?.Trim() ?? string.Empty,
                PhoneNumber = entity?.PhoneNumber?.Trim() ?? string.Empty,
                ContactPreference = entity?.ContactPreference ?? 1,
                ContactPreferenceDisplay = EnumHelper.GetDisplayName((ContactPreference)entity?.ContactPreference!)
            };

        /// <summary>
        /// Convierte la lista especificada de <see cref="CustomerEntity"/> en una lista de <see cref="CustomerVM"/>.
        /// </summary>
        /// <param name="entities">La lista especificada de <see cref="CustomerEntity"/> que se va a convertir.</param>
        /// <returns>Una lista de instancias de <see cref="CustomerVM"/> con los datos correspondientes del parámetro <paramref name="entities"/>.</returns>
        public static List<CustomerVM> ToViewModelList(this IEnumerable<CustomerEntity> entities) =>
            entities.Select(x => x.ToViewModel()).ToList();
    }
}