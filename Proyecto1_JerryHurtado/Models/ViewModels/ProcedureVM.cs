using System.ComponentModel.DataAnnotations;

namespace Proyecto1_JerryHurtado.Models.ViewModels
{
    public class ProcedureVM
    {
        public Guid Id { get; set; }

        [Display(Name = "Propietario de la mascota")]
        [Required(ErrorMessage = "Seleccione un propietario válido.")]
        public Guid CustomerId { get; set; }

        [Display(Name = "Mascota")]
        [Required(ErrorMessage = "Seleccione una mascota válida.")]
        public Guid PetId { get; set; }

        [Display(Name = "Tipo de procedimiento")]
        [Required(ErrorMessage = "El tipo de procedimiento es requerido.")]
        public int ProcedureTypeId { get; set; }

        [Display(Name = "Tipo de procedimiento")]
        public ProcedureTypeVM ProcedureType { get; set; } = null!;

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Seleccione un estado válido.")]
        public int Status { get; set; }

        #region Optional Display Properties

        public string StatusDisplay { get; set; } = null!;

        #endregion Optional Display Properties

        public CustomerVM Customer { get; set; } = null!;
        public PetVM Pet { get; set; } = null!;
    }
}