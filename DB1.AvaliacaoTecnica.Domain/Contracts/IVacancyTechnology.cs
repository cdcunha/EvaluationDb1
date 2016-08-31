using System;

namespace DB1.AvaliacaoTecnica.Domain.Contracts
{
    public interface IVacancyTechnology
    {
        int Id { get; }
        int VacancyId { get; }
        int TechnologyId { get; }
        int Weight { get; }

        void SetWeight(int weight);
        bool CanAdd();
    }
}
