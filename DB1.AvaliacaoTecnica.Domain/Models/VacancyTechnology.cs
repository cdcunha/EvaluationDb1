using DB1.AvaliacaoTecnica.Domain.Contracts;
using DB1.AvaliacaoTecnica.Domain.Scopes;
using System;
using System.ComponentModel.DataAnnotations;

namespace DB1.AvaliacaoTecnica.Domain.Models
{
    public class VacancyTechnology : IVacancyTechnology
    {
        public VacancyTechnology(){}

        public VacancyTechnology(int weight)
        {
            this.Id = Guid.NewGuid();
            SetWeight(weight);
        }

        #region Properties
        public Guid Id { get; private set; }
        public Guid VacancyId { get; private set; }
        public Guid TechnologyId { get; private set; }
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
