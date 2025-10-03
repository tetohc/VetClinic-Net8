using Proyecto1_JerryHurtado.Helpers;
using Proyecto1_JerryHurtado.Managers.Interfaces;
using Proyecto1_JerryHurtado.Mappers;
using Proyecto1_JerryHurtado.Models.Entities;
using Proyecto1_JerryHurtado.Models.Enums;
using Proyecto1_JerryHurtado.Models.ViewModels;

namespace Proyecto1_JerryHurtado.Managers
{
    public class PetManager : IManager<PetVM>
    {
        private List<PetEntity> _entities = new()
        {
            new PetEntity
            {
                Id = Guid.NewGuid(),
                OwnerIdNumber = "1-2345-6789",
                PetSpecies = 2,
                Race = "Labrador",
                Age = 5,
                Color = "Amarillo",
                LastVisitDate = new DateOnly(2023, 10, 15),
                OwnerPhoneNumber = "1234-5678",
                OwnerEmailAddress = "test@email.com"
            }
        };

        public bool Create(PetVM viewModel)
        {
            viewModel.Id = Guid.NewGuid();
            try
            {
                PetEntity entity = viewModel.ToEntity();
                _entities.Add(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(PetVM viewModel)
        {
            var existingEntity = _entities.FirstOrDefault(x => x.Id == viewModel.Id);
            if (existingEntity == null)
                return false;

            try
            {
                existingEntity.OwnerIdNumber = viewModel.OwnerIdNumber.Trim();
                existingEntity.PetSpecies = viewModel.PetSpecies;
                existingEntity.Race = viewModel.Race.Trim();
                existingEntity.Age = viewModel.Age;
                existingEntity.Color = viewModel.Color.Trim();
                existingEntity.LastVisitDate = viewModel.LastVisitDate;
                existingEntity.OwnerPhoneNumber = viewModel.OwnerPhoneNumber.Trim();
                existingEntity.OwnerEmailAddress = viewModel.OwnerEmailAddress.Trim();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Guid id)
        {
            var entityToRemove = _entities.FirstOrDefault(x => x.Id == id);
            if (entityToRemove == null)
                return false;
            return _entities.Remove(entityToRemove);
        }

        public PetVM? GetById(Guid id) => _entities.FirstOrDefault(x => x.Id == id)?.ToViewModel();

        public List<PetVM> GetAll() => _entities.ToViewModelList();

        public List<PetVM> Search(string query)
        {
            return _entities
                .Where(x => EnumHelper.GetDisplayName((PetSpecies)x.PetSpecies).Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    x.Race.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    x.Color.Contains(query, StringComparison.OrdinalIgnoreCase))
                .ToViewModelList();
        }

        public int Count() => _entities.Count;
    }
}