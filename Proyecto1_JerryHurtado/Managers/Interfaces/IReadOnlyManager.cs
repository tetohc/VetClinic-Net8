namespace Proyecto1_JerryHurtado.Managers.Interfaces
{
    public interface IReadOnlyManager<T> : IGetAllManager<T>
    {
        T? GetById(int id);

        int Count();
    }
}