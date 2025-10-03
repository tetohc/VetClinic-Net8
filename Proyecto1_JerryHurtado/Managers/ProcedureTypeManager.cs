using Proyecto1_JerryHurtado.Managers.Interfaces;
using Proyecto1_JerryHurtado.Models.ViewModels;

namespace Proyecto1_JerryHurtado.Managers
{
    public class ProcedureTypeManager : IReadOnlyManager<ProcedureTypeVM>
    {
        private readonly List<ProcedureTypeVM> _entities = new()
        {
            new ProcedureTypeVM
            {
                Id = 1,
                Name = "Consulta",
                Description = "Consulta de mascota.",
                Price = 15000
            },
            new ProcedureTypeVM
            {
                Id = 2,
                Name = "Consulta en horario especial",
                Description = "Consulta de mascota después de las 18:00 hrs de lunes a sábado, o domingo o feriado.",
                Price = 17000
            },
            new ProcedureTypeVM
            {
                Id = 3,
                Name = "Castración de 0-5 kg",
                Description = "Mascota castrada con un peso de 0-5 kg.",
                Price = 35000
            },
            new ProcedureTypeVM
            {
                Id = 4,
                Name = "Castración de 5-10 kg",
                Description = "Mascota castrada con un peso de 5-10 kg.",
                Price = 45000
            },
            new ProcedureTypeVM
            {
                Id = 5,
                Name = "Castración de 10-20 kg",
                Description = "Mascota castrada con un peso de 10-00 kg.",
                Price = 55000
            },
            new ProcedureTypeVM
            {
                Id = 6,
                Name = "Castración de 20-30 kg",
                Description = "Mascota castrada con un peso de 20-30 kg.",
                Price = 80000
            },
            new ProcedureTypeVM
            {
                Id = 7,
                Name = "Castración de 30-50 kg",
                Description = "Mascota castrada con un peso de 30-50 kg.",
                Price = 100000
            },
            new ProcedureTypeVM
            {
                Id = 8,
                Name = "Cirugía menor",
                Description = "Costo por kilo de peso del paciente.",
                Price = 15000
            },
            new ProcedureTypeVM
            {
                Id = 9,
                Name = "Cirugía mayor",
                Description = "Costo por kilo de peso del paciente.",
                Price = 25000
            },
            new ProcedureTypeVM
            {
                Id = 10,
                Name = "Gromming completo de mascota pequeña",
                Description = "Gromming completo de mascota pequeña.",
                Price = 15000
            },
            new ProcedureTypeVM
            {
                Id = 11,
                Name = "Gromming completo de mascota mediana",
                Description = "Gromming completo de mascota mediana.",
                Price = 20000
            },
            new ProcedureTypeVM
            {
                Id = 12,
                Name = "Gromming completo de mascota grande",
                Description = "Gromming completo de mascota grande.",
                Price = 25000
            },
            new ProcedureTypeVM
            {
                Id = 13,
                Name = "Gromming completo de mascota extra grande",
                Description = "Gromming completo de mascota extra grande.",
                Price = 35000
            },
            new ProcedureTypeVM
            {
                Id = 14,
                Name = "Vacunas Anuales de mascota",
                Description = "Vacunas anuales.",
                Price = 40000
            },
        };

        public List<ProcedureTypeVM> GetAll() => _entities;

        public ProcedureTypeVM? GetById(int id) =>
            _entities.FirstOrDefault(x => x.Id == id);

        public int Count() => _entities.Count;
    }
}