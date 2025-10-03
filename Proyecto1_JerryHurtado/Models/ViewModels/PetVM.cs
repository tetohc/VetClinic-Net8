using System.ComponentModel.DataAnnotations;

namespace Proyecto1_JerryHurtado.Models.ViewModels
{
    public class PetVM
    {
        public Guid Id { get; set; }

        [Display(Name = "Cédula del propietario")]
        [Required(ErrorMessage = "La cédula es obligatoria.")]
        public string OwnerIdNumber { get; set; } = null!;

        [Display(Name = "Especie")]
        [Required(ErrorMessage = "Seleccione una especie válida.")]
        public int PetSpecies { get; set; }

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

        [Display(Name = "Número de teléfono del propietario")]
        [Required(ErrorMessage = "El número de teléfono es obligatorio.")]
        [RegularExpression(@"^\d{4}-\d{4}$", ErrorMessage = "Formato inválido. Use 0000-0000")]
        public string OwnerPhoneNumber { get; set; } = null!;


        [Display(Name = "Correo electrónico del propietario")]
        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "Ingrese una dirección de correo electrónico válida.")]
        public string OwnerEmailAddress { get; set; } = null!;

        #region Optional Display Properties

        [Display(Name = "Especie")]
        public string PetSpeciesDisplay { get; set; } = null!;

        [Display(Name = "Fecha de la última visita")]
        public string LastVisitDateDisplay { get; set; } = null!;

        #endregion Optional Display Properties
    }
}