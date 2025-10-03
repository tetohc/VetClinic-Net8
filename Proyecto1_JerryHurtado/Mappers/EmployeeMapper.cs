using Proyecto1_JerryHurtado.Helpers;
using Proyecto1_JerryHurtado.Models.Entities;
using Proyecto1_JerryHurtado.Models.Enums;
using Proyecto1_JerryHurtado.Models.ViewModels;

namespace Proyecto1_JerryHurtado.Mappers
{
    /// <summary>
    /// Esta clase se encarga de mapear entre EmployeeEntity y el ViewModel.
    /// </summary>
    public static class EmployeeMapper
    {
        /// <summary>
        /// Convierte la instancia especificada de <see cref="EmployeeVM"/> en una instancia de <see cref="EmployeeEntity"/>.
        /// </summary>
        /// <param name="viewModel">La instancia de <see cref="EmployeeVM"/> que se va a convertir.</param>
        /// <returns>Instancia de <see cref="EmployeeEntity"/> con los datos correspondientes del parámetro <paramref name="viewModel"/>.</returns>
        public static EmployeeEntity ToEntity(this EmployeeVM viewModel) =>
            new()
            {
                Id = viewModel.Id,
                PersonalIdNumber = viewModel.PersonalIdNumber.Trim(),
                Birthdate = viewModel.Birthdate,
                HireDate = viewModel.HireDate,
                DailySalary = viewModel.DailySalary,
                TerminationDate = viewModel.TerminationDate,
                Type = viewModel.Type
            };

        /// <summary>
        /// Convierte la instancia especificada de <see cref="EmployeeEntity"/> en una instancia de <see cref="EmployeeVM"/>.
        /// </summary>
        /// <param name="entity">La instancia de <see cref="EmployeeEntity"/> que se va a convertir.</param>
        /// <returns>Instancia de <see cref="EmployeeVM"/> con los datos correspondientes del parámetro <paramref name="entity"/>.</returns>
        public static EmployeeVM ToViewModel(this EmployeeEntity entity) =>
            new()
            {
                Id = entity.Id,
                PersonalIdNumber = entity.PersonalIdNumber,
                Birthdate = entity.Birthdate,
                HireDate = entity.HireDate,
                HireDateDisplay = entity.HireDate.ToString("dd/MM/yyyy"),
                DailySalary = entity.DailySalary,
                TerminationDate = entity.TerminationDate,
                Type = entity.Type,
                TypeDisplay = EnumHelper.GetDisplayName((EmployeeType)entity.Type)
            };

        /// <summary>
        /// Convierte la lista especificada de <see cref="EmployeeEntity"/> en una lista de <see cref="EmployeeVM"/>.
        /// </summary>
        /// <param name="entities">La lista especificada de <see cref="EmployeeEntity"/> que se va a convertir.</param>
        /// <returns>Una lista de instancias de <see cref="EmployeeEntity"/> con los datos correspondientes del parámetro <paramref name="entities"/>.</returns>
        public static List<EmployeeVM> ToViewModelList(this IEnumerable<EmployeeEntity> entities) =>
            entities.Select(x => x.ToViewModel()).ToList();
    }
}