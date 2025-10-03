using System.ComponentModel.DataAnnotations;

namespace Proyecto1_JerryHurtado.Models.Enums
{
    public enum EntityType
    {
        [Display(Name = "Cliente")]
        Customer = 1,

        [Display(Name = "Empleado")]
        Employee,

        [Display(Name = "Mascota")]
        Pet,

        [Display(Name = "Procedimiento")]
        Procedure
    }
}