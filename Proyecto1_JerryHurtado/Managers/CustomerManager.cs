using Proyecto1_JerryHurtado.Managers.Interfaces;
using Proyecto1_JerryHurtado.Mappers;
using Proyecto1_JerryHurtado.Models.Entities;
using Proyecto1_JerryHurtado.Models.ViewModels;

namespace Proyecto1_JerryHurtado.Managers
{
    public class CustomerManager : IManager<CustomerVM>
    {
        private List<CustomerEntity> _entities = new()
        {
            new CustomerEntity
            {
                Id = Guid.NewGuid(),
                PersonalIdNumber = "1-2345-6789",
                FullName = "Juan Pérez",
                Province = "San José",
                Canton = "Escazú",
                District = "San Rafael",
                Address = "Calle 1, Casa 2",
                PhoneNumber = "8888-8888",
                ContactPreference = 1
            },
        };

        public bool Create(CustomerVM viewModel)
        {
            viewModel.Id = Guid.NewGuid();
            try
            {
                CustomerEntity entity = viewModel.ToEntity();
                _entities.Add(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(CustomerVM viewModel)
        {
            var existingEntity = _entities.FirstOrDefault(x => x.Id == viewModel.Id);
            if (existingEntity == null)
                return false;

            try
            {
                existingEntity.PersonalIdNumber = viewModel.PersonalIdNumber.Trim();
                existingEntity.FullName = viewModel.FullName.Trim();
                existingEntity.Province = viewModel.Province.Trim();
                existingEntity.Canton = viewModel.Canton.Trim();
                existingEntity.District = viewModel.District.Trim();
                existingEntity.Address = viewModel.Address.Trim();
                existingEntity.PhoneNumber = viewModel.PhoneNumber.Trim();
                existingEntity.ContactPreference = viewModel.ContactPreference;
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

        public CustomerVM? GetById(Guid id) => _entities.FirstOrDefault(x => x.Id == id)?.ToViewModel();

        public List<CustomerVM> GetAll() => _entities.ToViewModelList();

        public List<CustomerVM> Search(string query)
        {
            return _entities
                .Where(x => x.FullName.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                            x.PersonalIdNumber.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                            x.Province.Contains(query, StringComparison.OrdinalIgnoreCase))
                .ToViewModelList();
        }

        public int Count() => _entities.Count;
    }
}