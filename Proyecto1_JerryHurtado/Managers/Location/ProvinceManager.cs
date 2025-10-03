using Proyecto1_JerryHurtado.Managers.Interfaces;
using Proyecto1_JerryHurtado.Models.ViewModels.Location;

namespace Proyecto1_JerryHurtado.Managers.Location
{
    public class ProvinceManager : IReadOnlyManager<ProvinceVM>
    {
        private readonly List<ProvinceVM> _entities = new()
        {
            new() { Id = 1, Name = "San José" },
            new() { Id = 2, Name = "Alajuela" },
            new() { Id = 3, Name = "Cartago" },
            new() { Id = 4, Name = "Heredia" },
            new() { Id = 5, Name = "Guanacaste" },
            new() { Id = 6, Name = "Puntarenas" },
            new() { Id = 7, Name = "Limón" }
        };

        public List<ProvinceVM> GetAll() => _entities;

        public ProvinceVM? GetById(int id) => _entities.FirstOrDefault(x => x.Id == id);

        public int Count() => _entities.Count;
    }
}