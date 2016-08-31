using DB1.AvaliacaoTecnica.Domain.Contracts;
using DB1.AvaliacaoTecnica.Domain.Scopes;
using System.Collections.Generic;
using System.Linq;

namespace DB1.AvaliacaoTecnica.Domain.Models
{
    public class Candidate : ICandidate
    {
        //Contrutor para ser usado pelo EntityFramework
        public Candidate(){}

        public Candidate(string name, List<ICandidateTechnology> candidateTechnologies)
        {
            this.Name = name;
            this.CandidateTechnologies = candidateTechnologies;
        }

        public Candidate(int vacancyId, string name)
        {
            this.VacancyId = vacancyId;
            this.Name = name;
            this._candidateTechnologies = new List<ICandidateTechnology>();
        }

        #region Propriedades
        public int Id { get; private set; }
        public int VacancyId { get; private set; }
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
                this.CandidateTechnologies.Add(candidateTechnology);
        }

        public bool CanAdd()
        {
            return this.RegisterCandidateScopeIsValid();
        }

        public int GetKnowledgeLevelSeted()
        {
            return _candidateTechnologies.Where(x => x.KnowledgeLevel > 0).Count();
        }
        #endregion
    }
}
