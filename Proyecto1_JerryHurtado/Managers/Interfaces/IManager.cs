namespace Proyecto1_JerryHurtado.Managers.Interfaces
{
    public interface IManager<T>
    {
        bool Create(T viewModel);

        bool Update(T viewModel);

        bool Delete(Guid id);

        T? GetById(Guid id);

        List<T> GetAll();

        List<T> Search(string query);

        int Count();
    }
}