namespace Proyecto1_JerryHurtado.Models.ViewModels
{
    public class DropdownItemVM<T>
    {
        public required T Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
