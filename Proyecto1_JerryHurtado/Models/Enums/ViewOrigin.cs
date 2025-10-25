using System.ComponentModel.DataAnnotations;

namespace Proyecto1_JerryHurtado.Models.Enums
{
    public enum ViewOrigin
    {
        [Display(Name = "Vista principal")]
        Index = 1,

        [Display(Name = "Vista de búsqueda")]
        Search,

        [Display(Name = "Vista de reportes")]
        Report
    }
}