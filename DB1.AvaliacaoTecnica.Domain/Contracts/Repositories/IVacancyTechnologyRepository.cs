using DB1.AvaliacaoTecnica.Domain.Models;
using System;
using System.Collections.Generic;

namespace DB1.AvaliacaoTecnica.Domain.Contracts.Repositories
{
    public interface IVacancyTechnologyRepository
    {
        List<VacancyTechnology> GetByVacancy(Guid vacancyId);
        VacancyTechnology Get(Guid id);
        void Create(VacancyTechnology vacancyTechnology);
        void Update(VacancyTechnology vacancyTechnology);
        void Delete(VacancyTechnology vacancyTechnology);
    }
}
