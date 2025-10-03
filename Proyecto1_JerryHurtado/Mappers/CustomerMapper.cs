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
                FullName = viewModel.FullName.Trim(),
                Province = viewModel.Province.Trim(),
                Canton = viewModel.Canton.Trim(),
                District = viewModel.District.Trim(),
                Address = viewModel.Address.Trim(),
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
                PersonalIdNumber = entity.PersonalIdNumber.Trim(),
                FullName = entity.FullName.Trim(),
                Province = entity.Province.Trim(),
                Canton = entity.Canton.Trim(),
                District = entity.District.Trim(),
                Address = entity.Address.Trim(),
                PhoneNumber = entity.PhoneNumber.Trim(),
                ContactPreference = entity.ContactPreference,
                ContactPreferenceDisplay = EnumHelper.GetDisplayName((ContactPreference)entity.ContactPreference)
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