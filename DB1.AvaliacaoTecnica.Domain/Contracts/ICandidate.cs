using System;
using System.Collections.Generic;

namespace DB1.AvaliacaoTecnica.Domain.Contracts
{
    public interface ICandidate
    {
        Guid Id { get; }
        Guid VacancyId { get; }
        string Name { get; }
        int Pontuation { get; }
        ICollection<ICandidateTechnology> CandidateTechnologies { get; }

        void AddCandidateTechnology(ICandidateTechnology candidateTechnology);

        bool CanAdd();
    }
}
