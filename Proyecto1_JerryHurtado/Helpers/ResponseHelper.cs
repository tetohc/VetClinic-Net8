using Microsoft.AspNetCore.Mvc;
using Proyecto1_JerryHurtado.Models.Enums;

namespace Proyecto1_JerryHurtado.Helpers
{
    /// <summary>
    /// Esta clase proporciona métodos auxiliares para generar respuestas JSON estándar
    /// para operaciones exitosas, fallidas o excepciones.
    /// </summary>
    public static class ResponseHelper
    {
        /// <summary>
        /// Genera una respuesta JSON estándar para una operación exitosa en el flujo CRUD.
        /// </summary>
        /// <param name="message">Enumeración <see cref="ResultMessage"/> que representa el tipo de éxito (CRUD).</param>
        /// <returns>Objeto <see cref="JsonResult"/> con el resultado y el mensaje correspondiente.</returns>

        public static JsonResult Success(ResultMessage message)
        {
            return new JsonResult(new
            {
                result = true,
                message = EnumHelper.GetDisplayName(message)
            });
        }

        /// <summary>
        /// Genera una respuesta JSON estándar para una operación fallida en el flujo CRUD.
        /// </summary>
        /// <param name="message">Enumeración <see cref="ResultMessage"/> que representa el tipo de éxito (CRUD).</param>
        /// <returns>Objeto <see cref="JsonResult"/> con el resultado y el mensaje correspondiente.</returns>
        public static JsonResult Failure(ResultMessage message)
        {
            return new JsonResult(new
            {
                result = false,
                message = EnumHelper.GetDisplayName(message)
            });
        }
    }
}