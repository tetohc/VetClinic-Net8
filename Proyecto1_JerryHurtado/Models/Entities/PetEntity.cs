namespace Proyecto1_JerryHurtado.Models.Entities
{
    public class PetEntity
    {
        public Guid Id { get; set; }
        public string OwnerIdNumber { get; set; } = null!;
        public int PetSpecies { get; set; }
        public string Race { get; set; } = null!;
        public int Age { get; set; }
        public string Color { get; set; } = null!;
        public DateOnly LastVisitDate { get; set; }
        public string OwnerPhoneNumber { get; set; } = null!;
        public string OwnerEmailAddress { get; set; } = null!;
    }
}