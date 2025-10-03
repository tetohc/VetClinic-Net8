using System.ComponentModel.DataAnnotations;

namespace Proyecto1_JerryHurtado.Models.Enums
{
    public enum ProcedureStatus
    {
        [Display(Name = "En proceso")]
        InProgress = 1,

        [Display(Name = "Facturado")]
        Billed,

        [Display(Name = "Agendado")]
        Scheduled
    }
}