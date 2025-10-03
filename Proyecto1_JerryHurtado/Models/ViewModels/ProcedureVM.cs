using System.ComponentModel.DataAnnotations;

namespace Proyecto1_JerryHurtado.Models.ViewModels
{
    public class ProcedureVM
    {
        public Guid Id { get; set; }

        [Display(Name = "Cédula del propietario")]
        [Required(ErrorMessage = "La cédula es obligatoria.")]
        public string OwnerIdNumber { get; set; } = null!;

        [Display(Name = "Nombre de la mascota")]
        [Required(ErrorMessage = "El nombre de la mascota es obligatorio.")]
        public string PetName { get; set; } = null!;

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
    }
}