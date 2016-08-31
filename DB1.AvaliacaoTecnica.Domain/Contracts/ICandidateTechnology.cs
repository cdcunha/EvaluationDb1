using System;

namespace DB1.AvaliacaoTecnica.Domain.Contracts
{
    public interface ICandidateTechnology
    {
        int Id { get; }
        int CandidateId { get; }
        int TechnologyId { get; }
        int KnowledgeLevel { get; }
        int Weight { get; }

        void SetWeight(int weight);
        bool CanAdd();
    }
}
