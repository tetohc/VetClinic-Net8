using Proyecto1_JerryHurtado.Helpers;
using Proyecto1_JerryHurtado.Models.Entities;
using Proyecto1_JerryHurtado.Models.Enums;
using Proyecto1_JerryHurtado.Models.ViewModels;

namespace Proyecto1_JerryHurtado.Mappers
{
    /// <summary>
    /// Esta clase se encarga de mapear entre ProcedureEntity y el ViewModel.
    /// </summary>
    public static class ProcedureMapper
    {
        /// <summary>
        /// Convierte la instancia especificada de <see cref="ProcedureVM"/> en una instancia de <see cref="ProcedureEntity"/>.
        /// </summary>
        /// <param name="viewModel">La instancia especificada de <see cref="ProcedureVM"/> que se va a convertir.</param>
        /// <returns>Instancia de <see cref="ProcedureEntity"/> con los datos correspondientes del parámetro <paramref name="viewModel"/>.</returns>
        public static ProcedureEntity ToEntity(this ProcedureVM viewModel) =>
            new()
            {
                Id = viewModel.Id,
                CustomerId = viewModel.CustomerId,
                PetId = viewModel.PetId,
                ProcedureTypeId = viewModel.ProcedureTypeId,
                Status = viewModel.Status
            };

        /// <summary>
        /// Convierte la instancia especificada de <see cref="ProcedureEntity"/> en una instancia de <see cref="ProcedureVM"/>.
        /// </summary>
        /// <param name="entity">La instancia especificada de <see cref="ProcedureEntity"/> que se va a convertir.</param>
        /// <returns>Instancia de <see cref="ProcedureVM"/> con los datos correspondientes del parámetro <paramref name="viewModel"/>.</returns>
        public static ProcedureVM ToViewModel(this ProcedureEntity entity) =>
            new()
            {
                Id = entity.Id,
                CustomerId = entity.CustomerId,
                PetId = entity.PetId,
                ProcedureTypeId = entity.ProcedureTypeId,
                Status = entity.Status,
                StatusDisplay = EnumHelper.GetDisplayName((ProcedureStatus)entity.Status),
                Customer = entity?.Customer?.ToViewModel() ?? new(),
                Pet = entity?.Pet?.ToViewModel() ?? new()
            };

        /// <summary>
        /// Convierte la lista especificada de <see cref="ProcedureEntity"/> en una lista de <see cref="ProcedureVM"/>.
        /// </summary>
        /// <param name="entities">lista especificada de <see cref="ProcedureEntity"/> que se va a convertir.</param>
        /// <returns>Una lista de instancias de <see cref="ProcedureVM"/> con los datos correspondientes del parámetro <paramref name="entities"/>.</returns>
        public static List<ProcedureVM> ToViewModelList(this IEnumerable<ProcedureEntity> entities) =>
            entities.Select(x => x.ToViewModel()).ToList();
    }
}