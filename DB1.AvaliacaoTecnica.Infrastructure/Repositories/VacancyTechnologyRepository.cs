using DB1.AvaliacaoTecnica.Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB1.AvaliacaoTecnica.Domain.Models;
using DB1.AvaliacaoTecnica.Infrastructure.Data;
using System.Data.Entity;

namespace DB1.AvaliacaoTecnica.Infrastructure.Repositories
{
    public class VacancyTechnologyRepository : IVacancyTechnologyRepository
    {
        private StoreDataContext _context;

        public VacancyTechnologyRepository(StoreDataContext context)
        {
            this._context = context;
        }

        public void Create(VacancyTechnology vacancyTechnology)
        {
            this._context.VacancyTechnologies.Add(vacancyTechnology);
        }

        public void Delete(VacancyTechnology vacancyTechnology)
        {
            this._context.VacancyTechnologies.Remove(vacancyTechnology);
        }

        public VacancyTechnology Get(int id)
        {
            return this._context.VacancyTechnologies.Find(id);
        }

        public List<VacancyTechnology> GetByVacancy(int vacancyId)
        {
            return this._context.VacancyTechnologies
                .Where(x => x.VacancyId == vacancyId).ToList();
        }

        public void Update(VacancyTechnology vacancyTechnology)
        {
            _context.Entry<VacancyTechnology>(vacancyTechnology).State = EntityState.Modified;
        }
    }
}
