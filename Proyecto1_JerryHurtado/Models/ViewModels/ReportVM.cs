namespace Proyecto1_JerryHurtado.Models.ViewModels
{
    public class ReportVM
    {
        public CustomerVM Customer { get; set; } = null!;
        public PetVM Pet { get; set; } = null!;
        public ProcedureTypeVM ProjectedProcedure { get; set; } = null!;
    }
}