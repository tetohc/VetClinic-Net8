namespace Proyecto1_JerryHurtado.Models.Entities
{
    public class CustomerEntity
    {
        public Guid Id { get; set; }
        public string PersonalIdNumber { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string Province { get; set; } = null!;
        public string Canton { get; set; } = null!;
        public string District { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public int ContactPreference { get; set; }
    }
}