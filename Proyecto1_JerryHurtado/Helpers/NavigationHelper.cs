using Microsoft.AspNetCore.Mvc;
using Proyecto1_JerryHurtado.Models.Enums;

namespace Proyecto1_JerryHurtado.Helpers
{
    /// <summary>
    /// Clase auxiliar para manejar la navegación entre vistas, generando URLs de retorno basadas en el origen de navegación.
    /// </summary>
    public static class NavigationHelper
    {
        /// <summary>
        /// Genera una URL de retorno para la vista actual, basada en el origen de navegación especificado.
        /// </summary>
        /// <param name="controller">Instancia del controlador que genera la URL.</param>
        /// <param name="origin">Origen de la vista, utilizado para determinar la ruta de retorno.</param>
        /// <param name="controllerName">Nombre del controlador principal al que se debe retornar si el origen no es Search.</param>
        /// <returns>Cadena con la URL generada para redirigir al origen correspondiente.</returns>

        public static string GetReturnUrl(Controller controller, ViewOrigin origin, string controllerName)
        {
            return origin switch
            {
                ViewOrigin.Index => controller.Url.Action("Index", controllerName)!,
                ViewOrigin.Search => controller.Url.Action("Index", "Search")!,
                _ => controller.Url.Action("Index", controllerName)!
            };
        }
    }
}