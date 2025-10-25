using Proyecto1_JerryHurtado.Helpers;
using Proyecto1_JerryHurtado.Models.Entities;
using Proyecto1_JerryHurtado.Models.Enums;
using Proyecto1_JerryHurtado.Models.ViewModels;

namespace Proyecto1_JerryHurtado.Mappers
{
    /// <summary>
    /// Clase que se encarga de mapear entre PetEntity y el ViewModel.
    /// </summary>
    public static class PetMapper
    {
        /// <summary>
        /// Convierte la instancia especificada de <see cref="PetVM"/> en una instancia de <see cref="PetEntity"/>.
        /// </summary>
        /// <param name="viewModel">La instancia especificada de <see cref="PetVM"/> que se va a convertir.</param>
        /// <returns>Instancia de <see cref="PetEntity"/> con los datos correspondientes del parámetro <paramref name="viewModel"/>.</returns>
        public static PetEntity ToEntity(this PetVM viewModel) =>
            new()
            {
                Id = viewModel.Id,
                CustomerId = viewModel.CustomerId,
                PetSpecies = viewModel.PetSpecies,
                Name = viewModel.Name.Trim(),
                Race = viewModel.Race.Trim(),
                Age = viewModel.Age,
                Color = viewModel.Color.Trim(),
                LastVisitDate = viewModel.LastVisitDate
            };

        /// <summary>
        /// Convierte la instancia especificada de <see cref="PetEntity"/> en una instancia de <see cref="PetVM"/>.
        /// </summary>
        /// <param name="entity">La instancia especificada de <see cref="PetEntity"/> que se va a convertir.</param>
        /// <returns>Instancia de <see cref="PetVM"/> con los datos correspondientes del parámetro <paramref name="viewModel"/>.</returns>
        public static PetVM ToViewModel(this PetEntity entity) =>
            new()
            {
                Id = entity.Id,
                CustomerId = entity.CustomerId,
                PetSpecies = entity.PetSpecies,
                PetSpeciesDisplay = EnumHelper.GetDisplayName((PetSpecies)entity.PetSpecies),
                Name = entity.Name.Trim(),
                Race = entity.Race.Trim(),
                Age = entity.Age,
                Color = entity.Color.Trim(),
                LastVisitDate = entity.LastVisitDate,
                LastVisitDateDisplay = entity.LastVisitDate.ToString("dd/MM/yyyy"),
                Owner = entity.Owner?.ToViewModel()
            };

        /// <summary>
        /// Convierte la lista especificada de <see cref="PetEntity"/> en una lista de <see cref="PetVM"/>.
        /// </summary>
        /// <param name="entities">La lista especificada de <see cref="PetEntity"/> que se va a convertir.</param>
        /// <returns>Una lista de instancias de <see cref="PetVM"/> con los datos correspondientes del parámetro <paramref name="entities"/>.</returns>
        public static List<PetVM> ToViewModelList(this IEnumerable<PetEntity> entities) =>
            entities.Select(x => x.ToViewModel()).ToList();
    }
}