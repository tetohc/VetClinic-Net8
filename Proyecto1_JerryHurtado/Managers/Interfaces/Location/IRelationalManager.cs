namespace Proyecto1_JerryHurtado.Managers.Interfaces.Location
{
    public interface IRelationalManager<T>
    {
        List<T> GetAllById(int parentId);
    }
}