using System.ComponentModel.DataAnnotations;

namespace Proyecto1_JerryHurtado.Models.Enums
{
    public enum ContactPreference
    {
        [Display(Name = "Llamada telefónica")]
        PhoneCall = 1,

        [Display(Name = "Mensaje de WhatsApp")]
        WhatsAppMessage,
    }
}