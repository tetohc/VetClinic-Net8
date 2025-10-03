using Proyecto1_JerryHurtado.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Proyecto1_JerryHurtado.Models.ViewModels
{
    public class SearchVM
    {
        [Display(Name = "Término de búsqueda")]
        [Required(ErrorMessage = "El campo de búsqueda es obligatorio.")]
        public string Query { get; set; } = null!;

        [Display(Name = "Tipo de búsqueda")]
        [Required(ErrorMessage = "Debe seleccionar un tipo de búsqueda.")]
        public EntityType? EntityType { get; set; }
    }
}