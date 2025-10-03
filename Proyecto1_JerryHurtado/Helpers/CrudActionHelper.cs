using Microsoft.AspNetCore.Mvc;
using Proyecto1_JerryHurtado.Managers.Interfaces;
using Proyecto1_JerryHurtado.Models.Enums;

namespace Proyecto1_JerryHurtado.Helpers
{
    /// <summary>
    /// Clase auxiliar con métodos genéricos para simplificar las acciones CRUD en los controladores.
    /// Se comunica con la capa de acceso a datos (Managers) para ejecutar operaciones sobre colecciones en memoria.
    /// </summary>

    public static class CrudActionHelper
    {
        /// <summary>
        /// Genera una respuesta JSON con la lista de elementos obtenida desde el <paramref name="manager"/>.
        /// </summary>
        /// <typeparam name="T">Tipo de elemento gestionado por el <paramref name="manager"/>.</typeparam>
        /// <param name="manager">Instancia de <see cref="IManager{T}"/> responsable de recuperar los datos.</param>
        /// <returns><see cref="IActionResult"/> con los elementos envueltos en una propiedad <c>data</c>.</returns>
        public static IActionResult GetList<T>(IManager<T> manager)
        {
            var data = manager.GetAll();
            return new JsonResult(new { data });
        }

        /// <summary>
        /// Genera una respuesta JSON al intentar crear un nuevo elemento utilizando el <paramref name="manager"/>.
        /// </summary>
        /// <typeparam name="T">Tipo de elemento gestionado por el <paramref name="manager"/>.</typeparam>
        /// <param name="manager">Instancia de <see cref="IManager{T}"/> responsable de crear el registro.</param>
        /// <param name="viewModel">Modelo de vista que contiene los datos del nuevo elemento.</param>
        /// <returns><see cref="IActionResult"/> con la respuesta JSON que indica éxito o error.</returns>

        public static IActionResult Create<T>(IManager<T> manager, T viewModel)
        {
            try
            {
                bool created = manager.Create(viewModel);
                return created
                    ? ResponseHelper.Success(ResultMessage.CreateSuccess)
                    : ResponseHelper.Failure(ResultMessage.CreateError);
            }
            catch
            {
                return ResponseHelper.Failure(ResultMessage.UnexpectedError);
            }
        }

        /// <summary>
        /// Genera una respuesta JSON al intentar actualizar un elemento existente utilizando el <paramref name="manager"/>.
        /// </summary>
        /// <typeparam name="T">Tipo de elemento gestionado por el <paramref name="manager"/>.</typeparam>
        /// <param name="manager">Instancia de <see cref="IManager{T}"/> responsable de actualizar el registro.</param>
        /// <param name="viewModel">Modelo de vista que contiene los datos actualizados del elemento.</param>
        /// <returns><see cref="IActionResult"/> con la respuesta JSON que indica éxito o error.</returns>
        public static IActionResult Edit<T>(IManager<T> manager, T viewModel)
        {
            try
            {
                bool updated = manager.Update(viewModel);
                return updated
                    ? ResponseHelper.Success(ResultMessage.UpdateSuccess)
                    : ResponseHelper.Failure(ResultMessage.UpdateError);
            }
            catch
            {
                return ResponseHelper.Failure(ResultMessage.UnexpectedError);
            }
        }

        /// <summary>
        /// Genera una respuesta JSON al intentar eliminar un elemento identificado por <paramref name="id"/> mediante el <paramref name="manager"/>.
        /// </summary>
        /// <typeparam name="T">Tipo de elemento gestionado por el <paramref name="manager"/>.</typeparam>
        /// <param name="manager">Instancia de <see cref="IManager{T}"/> responsable de eliminar el registro.</param>
        /// <param name="id">Identificador único del elemento a eliminar.</param>
        /// <returns><see cref="IActionResult"/> con la respuesta JSON que indica éxito o error.</returns>

        public static IActionResult Delete<T>(IManager<T> manager, Guid id)
        {
            bool deleted = manager.Delete(id);
            return deleted
                ? ResponseHelper.Success(ResultMessage.DeleteSuccess)
                : ResponseHelper.Failure(ResultMessage.DeleteError);
        }
    }
}