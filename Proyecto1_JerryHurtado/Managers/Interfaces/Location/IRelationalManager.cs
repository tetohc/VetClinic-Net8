namespace Proyecto1_JerryHurtado.Managers.Interfaces.Location
{
    public interface IRelationalManager<T> : IReadOnlyManager<T>
    {
        List<T> GetAllById(int parentId);
    }
}