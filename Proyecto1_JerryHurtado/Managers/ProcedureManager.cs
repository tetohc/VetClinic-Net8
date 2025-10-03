using Proyecto1_JerryHurtado.Helpers;
using Proyecto1_JerryHurtado.Managers.Interfaces;
using Proyecto1_JerryHurtado.Mappers;
using Proyecto1_JerryHurtado.Models.Entities;
using Proyecto1_JerryHurtado.Models.Enums;
using Proyecto1_JerryHurtado.Models.ViewModels;

namespace Proyecto1_JerryHurtado.Managers
{
    public class ProcedureManager : IManager<ProcedureVM>
    {
        private readonly List<ProcedureEntity> _entities = new()
        {
            new ProcedureEntity
            {
                Id = Guid.NewGuid(),
                OwnerIdNumber = "1-2345-6789",
                PetName = "Fido",
                ProcedureTypeId = 1,
                Status = 3
            },
        };

        public bool Create(ProcedureVM viewModel)
        {
            viewModel.Id = Guid.NewGuid();
            try
            {
                ProcedureEntity entity = viewModel.ToEntity();
                _entities.Add(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(ProcedureVM viewModel)
        {
            var existingEntity = _entities.FirstOrDefault(x => x.Id == viewModel.Id);
            if (existingEntity == null)
                return false;

            try
            {
                existingEntity.OwnerIdNumber = viewModel.OwnerIdNumber.Trim();
                existingEntity.PetName = viewModel.PetName.Trim();
                existingEntity.ProcedureTypeId = viewModel.ProcedureTypeId;
                existingEntity.Status = viewModel.Status;
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

        public ProcedureVM? GetById(Guid id) => _entities.FirstOrDefault(x => x.Id == id)?.ToViewModel();

        public List<ProcedureVM> GetAll() => _entities.ToViewModelList();

        public List<ProcedureVM> Search(string query)
        {
            return _entities
                .Where(x => x.PetName.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                            EnumHelper.GetDisplayName((ProcedureStatus)x.Status).Contains(query, StringComparison.OrdinalIgnoreCase))
                .ToViewModelList();
        }

        public int Count() => _entities.Count;
    }
}