using DB1.AvaliacaoTecnica.Domain.Models;
using System;
using System.Collections.Generic;

namespace DB1.AvaliacaoTecnica.Domain.Contracts.Repositories
{
    public interface ICandidateTechnologyRepository
    {
        List<CandidateTechnology> GetByCandidate(int candidateId);
        CandidateTechnology Get(int id);
        void Create(CandidateTechnology candidateTechnology);
        void Update(CandidateTechnology candidateTechnology);
        void Delete(CandidateTechnology candidateTechnology);
    }
}
