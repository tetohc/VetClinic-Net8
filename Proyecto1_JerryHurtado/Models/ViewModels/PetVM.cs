using System.ComponentModel.DataAnnotations;

namespace Proyecto1_JerryHurtado.Models.ViewModels
{
    public class PetVM
    {
        public Guid Id { get; set; }

        [Display(Name = "Propietario de la mascota")]
        [Required(ErrorMessage = "Seleccione un cliente válido.")]
        public Guid CustomerId { get; set; }

        [Display(Name = "Especie")]
        [Required(ErrorMessage = "Seleccione una especie válida.")]
        public int PetSpecies { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Name { get; set; } = null!;

        [Display(Name = "Raza")]
        [Required(ErrorMessage = "La raza es obligatoria.")]
        public string Race { get; set; } = null!;

        [Display(Name = "Edad")]
        [Required(ErrorMessage = "La edad es obligatoria.")]
        [Range(0, 100, ErrorMessage = "Ingrese una edad válida entre 0 y 100.")]
        public int Age { get; set; }

        [Display(Name = "Color")]
        [Required(ErrorMessage = "El color es obligatorio.")]
        public string Color { get; set; } = null!;

        [Display(Name = "Fecha de la última visita")]
        [Required(ErrorMessage = "La fecha de la última visita es obligatoria.")]
        public DateOnly LastVisitDate { get; set; }

        #region Optional Display Properties

        [Display(Name = "Especie")]
        public string PetSpeciesDisplay { get; set; } = null!;

        [Display(Name = "Fecha de la última visita")]
        public string LastVisitDateDisplay { get; set; } = null!;

        #endregion Optional Display Properties

        public CustomerVM? Owner { get; set; }
    }
}