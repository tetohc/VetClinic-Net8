namespace Proyecto1_JerryHurtado.Models.Entities
{
    public class ProcedureEntity
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid PetId { get; set; }
        public int ProcedureTypeId { get; set; }
        public int Status { get; set; }

        public CustomerEntity? Customer { get; set; } = null;
        public PetEntity? Pet { get; set; } = null;
    }
}