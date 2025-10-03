using Proyecto1_JerryHurtado.Helpers;
using Proyecto1_JerryHurtado.Managers.Interfaces;
using Proyecto1_JerryHurtado.Mappers;
using Proyecto1_JerryHurtado.Models.Entities;
using Proyecto1_JerryHurtado.Models.Enums;
using Proyecto1_JerryHurtado.Models.ViewModels;

namespace Proyecto1_JerryHurtado.Managers
{
    public class EmployeeManager : IManager<EmployeeVM>
    {
        private List<EmployeeEntity> _entities = new()
        {
            new EmployeeEntity
            {
                Id = Guid.NewGuid(),
                PersonalIdNumber = "1-2345-6789",
                Birthdate = new DateOnly(1990, 1, 1),
                HireDate = new DateOnly(2020, 1, 1),
                DailySalary = 15000,
                TerminationDate = new DateOnly(2025, 12, 31),
                Type = 1
            }
        };

        public bool Create(EmployeeVM viewModel)
        {
            viewModel.Id = Guid.NewGuid();
            try
            {
                EmployeeEntity entity = viewModel.ToEntity();
                _entities.Add(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(EmployeeVM viewModel)
        {
            var existingEntity = _entities.FirstOrDefault(x => x.Id == viewModel.Id);
            if (existingEntity == null)
                return false;

            try
            {
                existingEntity.PersonalIdNumber = viewModel.PersonalIdNumber.Trim();
                existingEntity.Birthdate = viewModel.Birthdate;
                existingEntity.HireDate = viewModel.HireDate;
                existingEntity.DailySalary = viewModel.DailySalary;
                existingEntity.TerminationDate = viewModel.TerminationDate;
                existingEntity.Type = viewModel.Type;
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

        public EmployeeVM? GetById(Guid id) => _entities.FirstOrDefault(x => x.Id == id)?.ToViewModel();

        public List<EmployeeVM> GetAll() => _entities.ToViewModelList();

        public List<EmployeeVM> Search(string query)
        {
            return _entities
                .Where(e => e.PersonalIdNumber.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                        EnumHelper.GetDisplayName((EmployeeType)e.Type).Contains(query, StringComparison.OrdinalIgnoreCase))
                .ToViewModelList();
        }

        public int Count() => _entities.Count;
    }
}