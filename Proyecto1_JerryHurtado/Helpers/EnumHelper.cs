using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto1_JerryHurtado.Models.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Proyecto1_JerryHurtado.Helpers
{
    /// <summary>
    /// Clase para ayudar a mostrar los nombres de los enums en la UI.
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// Este método devuelve el nombre de visualización de un enum utilizando el atributo Display.
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string GetDisplayName(this Enum enumValue)
            => enumValue.GetType().GetMember(enumValue.ToString()).First().GetCustomAttribute<DisplayAttribute>()?.GetName()!;

        /// <summary>
        /// Este método devuelve una lista de selección con los valores y nombres de visualización de un enum <see cref="Enum"/>.
        /// </summary>
        /// <typeparam name="TEnum">Tipo de enum <see cref="Enum"/>.</typeparam>
        /// <returns>SelectList <see cref="SelectList"/> con los valores y nombres de visualización de un enum.</returns>
        public static SelectList GetEnumSelectList<TEnum>() where TEnum : Enum
        {
            var values = Enum.GetValues(typeof(TEnum))
                .Cast<TEnum>()
                .Select(e => new DropdownItemVM<int>
                {
                    Id = Convert.ToInt32(e),
                    Name = e.GetDisplayName()
                })
                .ToList();

            return new SelectList(values?.OrderBy(x => x.Name), "Id", "Name");
        }
    }
}