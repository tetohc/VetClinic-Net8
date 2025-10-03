namespace Proyecto1_JerryHurtado.Models.Entities
{
    public class ProcedureEntity
    {
        public Guid Id { get; set; }
        public string OwnerIdNumber { get; set; } = null!;
        public string PetName { get; set; } = null!;
        public int ProcedureTypeId { get; set; }
        public int Status { get; set; }
    }
}