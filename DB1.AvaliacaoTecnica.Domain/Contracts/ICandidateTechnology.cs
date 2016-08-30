using System;

namespace DB1.AvaliacaoTecnica.Domain.Contracts
{
    public interface ICandidateTechnology
    {
        Guid Id { get; }
        Guid CandidateId { get; }
        Guid TechnologyId { get; }
        int KnowledgeLevel { get; }
        int Weight { get; }

        void SetWeight(int weight);
        bool CanAdd();
    }
}
