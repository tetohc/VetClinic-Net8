namespace Proyecto1_JerryHurtado.Managers.Interfaces
{
    public interface IReadOnlyManager<T>
    {
        T? GetById(int id);

        List<T> GetAll();

        int Count();
    }
}