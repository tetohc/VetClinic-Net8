using System.ComponentModel.DataAnnotations;

namespace Proyecto1_JerryHurtado.Models.Enums
{
    public enum ResultMessage
    {
        [Display(Name = "Registro creado exitosamente.")]
        CreateSuccess = 1,

        [Display(Name = "Ha ocurrido un error al crear el registro. Inténtelo de nuevo.")]
        CreateError,

        [Display(Name = "Registro actualizado exitosamente.")]
        UpdateSuccess,

        [Display(Name = "Ha ocurrido un error al actualizar el registro.")]
        UpdateError,

        [Display(Name = "Registro eliminado exitosamente.")]
        DeleteSuccess,

        [Display(Name = "Ha ocurrido un error al eliminar el registro.")]
        DeleteError,

        [Display(Name = "Ha ocurrido un error inesperado. Inténtelo de nuevo.")]
        UnexpectedError
    }
}