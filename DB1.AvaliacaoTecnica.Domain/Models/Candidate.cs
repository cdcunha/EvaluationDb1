using DB1.AvaliacaoTecnica.Domain.Contracts;
using DB1.AvaliacaoTecnica.Domain.Scopes;
using System;
using System.Collections.Generic;

namespace DB1.AvaliacaoTecnica.Domain.Models
{
    public class Candidate : ICandidate
    {
        //Contrutor para ser usado pelo EntityFramework
        public Candidate(){}

        public Candidate(Guid vacancyId, string name, IList<ICandidateTechnology> candidateTechnologies)
        {
            this.Id = Guid.NewGuid();
            this.VacancyId = vacancyId;
            this.Name = name;
            this.CandidateTechnologies = candidateTechnologies;
        }

        #region Propriedades
        public Guid Id { get; private set; }
        public Guid VacancyId { get; private set; }
        public string Name { get; private set; }

        private IList<ICandidateTechnology> _candidateTechnologies;
        public ICollection<ICandidateTechnology> CandidateTechnologies
        {
            get { return _candidateTechnologies; }
            private set { _candidateTechnologies = new List<ICandidateTechnology>(value); }
        }

        #region Calcula Pontuação
        public int Pontuation
        {
            get
            {
                int total = 0;

                foreach (var candidateTech in _candidateTechnologies)
                {
                    total += candidateTech.Weight * candidateTech.KnowledgeLevel;
                }

                return total;
            }
        }
        #endregion
        #endregion

        #region Métodos
        public void AddCandidateTechnology(ICandidateTechnology candidateTechnology)
        {
            if (candidateTechnology.CanAdd())
                _candidateTechnologies.Add(candidateTechnology);
        }

        public bool CanAdd()
        {
            return this.RegisterCandidateScopeIsValid();
        }
        #endregion
    }
}
