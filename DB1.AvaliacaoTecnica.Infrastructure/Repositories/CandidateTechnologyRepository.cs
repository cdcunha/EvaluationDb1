using DB1.AvaliacaoTecnica.Domain.Contracts.Repositories;
using DB1.AvaliacaoTecnica.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB1.AvaliacaoTecnica.Domain.Models;
using System.Data.Entity;

namespace DB1.AvaliacaoTecnica.Infrastructure.Repositories
{
    public class CandidateTechnologyRepository : ICandidateTechnologyRepository
    {
        private StoreDataContext _context;

        public CandidateTechnologyRepository(StoreDataContext context)
        {
            this._context = context;
        }

        public void Create(CandidateTechnology candidateTechnology)
        {
            this._context.CandidateTechnologies.Add(candidateTechnology);
        }

        public void Delete(CandidateTechnology candidateTechnology)
        {
            this._context.CandidateTechnologies.Remove(candidateTechnology);
        }

        public CandidateTechnology Get(int id)
        {
            return this._context.CandidateTechnologies.Find(id);
        }

        public List<CandidateTechnology> GetByCandidate(int candidateId)
        {
            return this._context.CandidateTechnologies
                .Where(x => x.CandidateId == candidateId).ToList();
        }

        public void Update(CandidateTechnology candidateTechnology)
        {
            this._context.Entry<CandidateTechnology>(candidateTechnology).State = EntityState.Modified;
        }
    }
}
