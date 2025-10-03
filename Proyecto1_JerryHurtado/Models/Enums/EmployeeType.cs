﻿using System.ComponentModel.DataAnnotations;

namespace Proyecto1_JerryHurtado.Models.Enums
{
    public enum EmployeeType
    {
        [Display(Name = "Veterinario")]
        Veterinarian = 1,

        [Display(Name = "Asistente")]
        Assistant,

        [Display(Name = "Administrativo")]
        Administrative,

        [Display(Name = "Mantenimiento")]
        Maintenance,

        [Display(Name = "Peluquero de mascotas")]
        Groomer
    }
}