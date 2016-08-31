using DB1.AvaliacaoTecnica.Domain.Contracts;
using DB1.AvaliacaoTecnica.Domain.Scopes;
using System;
using System.ComponentModel.DataAnnotations;

namespace DB1.AvaliacaoTecnica.Domain.Models
{
    public class VacancyTechnology : IVacancyTechnology
    {
        public VacancyTechnology(){}

        public VacancyTechnology(int technologyId)
        {
            this.TechnologyId = technologyId;
        }
        public VacancyTechnology(int vacancyId, int technologyId, int weight)
        {
            this.VacancyId = vacancyId;
            this.TechnologyId = technologyId;
            SetWeight(weight);
        }

        #region Properties
        public int Id { get; private set; }
        public int VacancyId { get; private set; }
        public int TechnologyId { get; private set; }
        [Range(0, 10)]
        public int Weight { get; private set; }
        #endregion

        public void SetWeight(int weight)
        {
            this.Weight = weight;
        }
        public bool CanAdd()
        {
            return this.RegisterVacancyTechnologyScopeIsValid();
        }

    }
}
