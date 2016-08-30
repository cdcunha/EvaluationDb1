using DB1.AvaliacaoTecnica.Domain.Contracts;
using DB1.AvaliacaoTecnica.Domain.Enums;
using System;
using System.Collections.Generic;

namespace DB1.AvaliacaoTecnica.Domain.Models
{
    public class Vacancy : IVacancy
    {
        //Contrutor para ser usado pelo EntityFramework
        public Vacancy() { }

        public Vacancy(string description, IList<IVacancyTechnology> vacancyTechnologies)
        {
            this.Id = Guid.NewGuid();
            this.Description = description;
            this._vacancyTechnologies = vacancyTechnologies;
        }

        #region Propriedades
        public Guid Id { get; private set; }
        public string Description { get; private set; }

        private IList<IVacancyTechnology> _vacancyTechnologies;
        public ICollection<IVacancyTechnology> VacancyTechnologies
        {
            get { return _vacancyTechnologies; }
            private set { _vacancyTechnologies = new List<IVacancyTechnology>(value); }
        }

        private IList<ICandidate> _candidates;
        public ICollection<ICandidate> Candidates
        {
            get { return _candidates; }
            private set { _candidates = new List<ICandidate>(value); }
        }
        public EVacancyStatus Status { get; private set; }
        #endregion

        #region Métodos
        public void AddTechnology(IVacancyTechnology technology)
        {
            if (technology.CanAdd())
                _vacancyTechnologies.Add(technology);
        }

        public void AddCandidate(ICandidate candidate)
        {
            if (candidate.CanAdd())
                _candidates.Add(candidate);
        }

        public void Cancel()
        {
            this.Status = EVacancyStatus.Canceled;
        }
        public void Suspend()
        {
            this.Status = EVacancyStatus.Suspensed;
        }
        #endregion
    }
}
