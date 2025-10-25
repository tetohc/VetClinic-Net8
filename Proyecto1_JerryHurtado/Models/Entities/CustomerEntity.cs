﻿namespace Proyecto1_JerryHurtado.Models.Entities
{
    public class CustomerEntity
    {
        public Guid Id { get; set; }
        public string PersonalIdNumber { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int ProvinceId { get; set; }
        public string Province { get; set; } = null!;
        public int CantonId { get; set; }
        public string Canton { get; set; } = null!;
        public int DistrictId { get; set; }
        public string District { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public int ContactPreference { get; set; }
    }
}