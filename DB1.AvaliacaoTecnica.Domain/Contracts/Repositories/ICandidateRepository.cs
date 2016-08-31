using DB1.AvaliacaoTecnica.Domain.Models;
using System;
using System.Collections.Generic;

namespace DB1.AvaliacaoTecnica.Domain.Contracts.Repositories
{
    public interface ICandidateRepository
    {        
        List<Candidate> GetByVancancy(int vacancyId);
        Candidate Get(int id);
        void Create(Candidate candidateId);
        void Update(Candidate candidateId);
        void Delete(Candidate candidateId);
    }
}
