using DB1.AvaliacaoTecnica.Domain.Contracts.Repositories;
using DB1.AvaliacaoTecnica.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using DB1.AvaliacaoTecnica.Domain.Models;
using System.Data.Entity;

namespace DB1.AvaliacaoTecnica.Infrastructure.Repositories
{
    class CandidateRepository : ICandidateRepository
    {
        private StoreDataContext _context;

        public CandidateRepository(StoreDataContext context)
        {
            this._context = context;
        }

        public void Create(Candidate candidate)
        {
            this._context.Candidates.Add(candidate);
        }

        public void Delete(Candidate candidate)
        {
            this._context.Candidates.Remove(candidate);
        }

        public Candidate Get(int id)
        {
            return this._context.Candidates.Find(id);
        }

        public List<Candidate> GetByVancancy(int vacancyId)
        {
            return _context.Candidates
                .Where(x => x.VacancyId == vacancyId)
                .OrderByDescending(x => x.Name).ToList();
        }

        public void Update(Candidate candidate)
        {
            _context.Entry<Candidate>(candidate).State = EntityState.Modified;
        }
    }
}
