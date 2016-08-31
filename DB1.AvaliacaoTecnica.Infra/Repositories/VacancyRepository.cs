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
    public class VacancyRepository : IVacancyRepository
    {
        private StoreDataContext _context;

        public VacancyRepository(StoreDataContext context)
        {
            this._context = context;
        }

        public void Create(Vacancy vacancy)
        {
            this._context.Vacancies.Add(vacancy);
        }

        public void Delete(Vacancy vacancy)
        {
            this._context.Vacancies.Remove(vacancy);
        }

        public Vacancy GetDetails(int id)
        {
            return _context.Vacancies
                .Include(x => x.Candidates)
                .Include(x => x.VacancyTechnologies)
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }
        public List<Vacancy> Get()
        {
            return this._context.Vacancies
                .OrderBy(x => x.Description).ToList();
        }

        public Vacancy GetHeader(int id)
        {
            return this._context.Vacancies.Find(id);
        }

        public List<Vacancy> Get(string description)
        {
            return this._context.Vacancies
                .Where(x => x.Description == description)
                .OrderBy(x => x.Description).ToList();
        }

        public void Update(Vacancy vacancy)
        {
            this._context.Entry<Vacancy>(vacancy).State = EntityState.Modified;
        }
    }
}
