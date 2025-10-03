using System.ComponentModel.DataAnnotations;

namespace Proyecto1_JerryHurtado.Models.ViewModels
{
    public class CustomerVM
    {
        public Guid Id { get; set; }

        [Display(Name = "Cédula")]
        [Required(ErrorMessage = "La cédula es obligatoria.")]
        public string PersonalIdNumber { get; set; } = null!;

        [Display(Name = "Nombre completo")]
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string FullName { get; set; } = null!;

        [Display(Name = "Provincia")]
        public string Province { get; set; } = null!;

        [Display(Name = "Provincia")]
        [Required(ErrorMessage = "La provincia es obligatoria.")]
        public int ProvinceId { get; set; }

        [Display(Name = "Cantón")]
        public string Canton { get; set; } = null!;

        [Display(Name = "Cantón")]
        [Required(ErrorMessage = "El cantón es obligatorio.")]
        public int CantonId { get; set; }

        [Display(Name = "Distrito")]
        public string District { get; set; } = null!;

        [Display(Name = "Distrito")]
        [Required(ErrorMessage = "El distrito es obligatorio.")]
        public int DistrictId { get; set; }

        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "La dirección es obligatoria.")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; } = null!;

        [Display(Name = "Número de teléfono")]
        [Required(ErrorMessage = "El número de teléfono es obligatorio.")]
        [RegularExpression(@"^\d{4}-\d{4}$", ErrorMessage = "Formato inválido. Use 0000-0000")]
        public string PhoneNumber { get; set; } = null!;

        [Display(Name = "Preferencia de contacto")]
        [Required(ErrorMessage = "La preferencia de contacto es obligatoria.")]
        public int ContactPreference { get; set; }

        #region Optional Display Properties

        [Display(Name = "Preferencia de contacto")]
        public string ContactPreferenceDisplay { get; set; } = null!;

        #endregion Optional Display Properties
    }
}