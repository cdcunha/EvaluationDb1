using DB1.AvaliacaoTecnica.Domain.Enums;
using DB1.AvaliacaoTecnica.SharedKernel.Helpers;
using System.Collections.Generic;

namespace DB1.AvaliacaoTecnica.Domain.Contracts
{
    public interface IVacancy
    {
        int Id { get; }
        string Description { get; }
        ICollection<IVacancyTechnology> VacancyTechnologies { get; }
        ICollection<ICandidate> Candidates { get; }
        EVacancyStatus Status { get; }

        void AddTechnology(IVacancyTechnology vacancyTecnology);
        void AddCandidate(ICandidate candidate);

        bool CanAdd();
        List<Finalized> Finalize();
    }
}
