﻿namespace Proyecto1_JerryHurtado.Models.Entities
{
    public class EmployeeEntity
    {
        public Guid Id { get; set; }
        public string PersonalIdNumber { get; set; } = null!;
        public DateOnly Birthdate { get; set; }
        public DateOnly HireDate { get; set; }
        public decimal DailySalary { get; set; }
        public DateOnly TerminationDate { get; set; }
        public int Type { get; set; }
    }
}