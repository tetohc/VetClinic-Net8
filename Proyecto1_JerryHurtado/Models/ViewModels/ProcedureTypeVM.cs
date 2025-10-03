using System.ComponentModel.DataAnnotations;

namespace Proyecto1_JerryHurtado.Models.ViewModels
{
    public class ProcedureTypeVM
    {
        public int Id { get; set; }

        [Display(Name = "Tipo de Lavado")]
        public string Name { get; set; } = null!;

        [Display(Name = "Incluye")]
        public string Description { get; set; } = null!;

        [Display(Name = "Precio")]
        public decimal Price { get; set; }

        [Display(Name = "IVA")]
        public string IVA { get; set; } = "13%";

        /// <summary>
        /// Metodo que retorna el precio con impuesto incluido (13%)
        /// </summary>
        /// <returns>Precio con IVA incluido.</returns>
        public decimal GetPriceWithTax() => Price * 1.13m;
    }
}