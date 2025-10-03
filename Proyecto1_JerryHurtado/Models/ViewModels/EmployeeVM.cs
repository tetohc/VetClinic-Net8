using System.ComponentModel.DataAnnotations;

namespace Proyecto1_JerryHurtado.Models.ViewModels
{
    public class EmployeeVM
    {
        public Guid Id { get; set; }

        [Display(Name = "Cédula")]
        [Required(ErrorMessage = "La cédula es obligatoria.")]
        [RegularExpression(@"^\d{1,3}-\d{3,4}-\d{4,6}$", ErrorMessage = "Formato de cédula inválido")]
        public string PersonalIdNumber { get; set; } = null!;

        [Display(Name = "Fecha de nacimiento")]
        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        public DateOnly Birthdate { get; set; }

        [Display(Name = "Fecha de ingreso")]
        [Required(ErrorMessage = "La fecha de ingreso es obligatoria.")]
        public DateOnly HireDate { get; set; }

        [Display(Name = "Salario diario")]
        [Required(ErrorMessage = "El salario es obligatorio.")]
        [DataType(DataType.Currency)]
        [Range(0.01, double.MaxValue, ErrorMessage = "Ingrese un monto válido mayor que cero.")]
        public decimal DailySalary { get; set; }

        [Display(Name = "Fecha de retiro")]
        [Required(ErrorMessage = "La fecha de retiro es obligatoria.")]
        public DateOnly TerminationDate { get; set; }

        [Display(Name = "Tipo")]
        [Required(ErrorMessage = "Seleccione un tipo de empleado válido.")]
        public int Type { get; set; }

        #region Optional Display Properties

        [Display(Name = "Tipo")]
        public string TypeDisplay { get; set; } = null!;

        [Display(Name = "Fecha de ingreso")]
        public string HireDateDisplay { get; set; } = null!;

        #endregion Optional Display Properties
    }
}