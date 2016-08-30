using System;

namespace DB1.AvaliacaoTecnica.Domain.Contracts
{
    public interface IVacancyTechnology
    {
        Guid Id { get; }
        Guid VacancyId { get; }
        Guid TechnologyId { get; }
        int Weight { get; }

        void SetWeight(int weight);
        bool CanAdd();
    }
}
