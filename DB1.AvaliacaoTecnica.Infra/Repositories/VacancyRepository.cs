using DB1.AvaliacaoTecnica.Domain.Contracts.Repositories;
using DB1.AvaliacaoTecnica.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB1.AvaliacaoTecnica.Domain.Models;
using System.Data.Entity;
using DB1.AvaliacaoTecnica.SharedKernel.Validation;

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

        private bool CheckDBConnectionAndNotificate()
        {
            return AssertionConcern.IsSatisfiedBy(
                AssertionConcern.AssertTrue(this._context.Database.Exists(), "Sem conexão com o Banco de Dados")
            );
        }

        public void Delete(Vacancy vacancy)
        {
            if (CheckDBConnectionAndNotificate())
                this._context.Vacancies.Remove(vacancy);
        }

        public Vacancy GetDetails(int id)
        {
            if (CheckDBConnectionAndNotificate())
            {
                return _context.Vacancies
                .Include(x => x.Candidates)
                .Include(x => x.VacancyTechnologies)
                .Where(x => x.Id == id)
                .FirstOrDefault();
            }
            else
                return null;
        }
        public List<Vacancy> Get()
        {
            if (CheckDBConnectionAndNotificate())
            {
                return this._context.Vacancies
                .OrderBy(x => x.Description).ToList();
            }
            else
                return null;
        }

        public Vacancy GetHeader(int id)
        {
            if (CheckDBConnectionAndNotificate())
            {
                return this._context.Vacancies.Find(id);
            }
            else
                return null;
        }

        public List<Vacancy> Get(string description)
        {
            if (CheckDBConnectionAndNotificate())
            {
                return this._context.Vacancies
                .Where(x => x.Description == description)
                .OrderBy(x => x.Description).ToList();
            }
            else
                return null;
        }

        public void Update(Vacancy vacancy)
        {
            if (CheckDBConnectionAndNotificate())
                this._context.Entry<Vacancy>(vacancy).State = EntityState.Modified;
        }
    }
}
