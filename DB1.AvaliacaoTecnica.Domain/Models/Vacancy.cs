using DB1.AvaliacaoTecnica.Domain.Contracts;
using DB1.AvaliacaoTecnica.Domain.Enums;
using DB1.AvaliacaoTecnica.Domain.Scopes;
using DB1.AvaliacaoTecnica.SharedKernel.Helpers;
using DB1.AvaliacaoTecnica.SharedKernel.Validation;
using System.Collections.Generic;
using System.Linq;

namespace DB1.AvaliacaoTecnica.Domain.Models
{
    public class Vacancy : IVacancy
    {
        //Contrutor para ser usado pelo EntityFramework
        public Vacancy() { }

        public Vacancy(string description)
        {
            this.Description = description;
            this._vacancyTechnologies = new List<IVacancyTechnology>();
            this._candidates = new List<ICandidate>();
            this.Status = EVacancyStatus.Opened;
        }

        #region Propriedades
        public int Id { get; private set; }
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
        /// <summary>
        /// Adiciona um tecnologia à vaga
        /// </summary>
        /// <param name="technology"></param>
        public void AddTechnology(IVacancyTechnology technology)
        {
            if (technology.CanAdd())
                _vacancyTechnologies.Add(technology);
        }

        /// <summary>
        /// Adiciona um candidato à vaga
        /// </summary>
        /// <param name="candidate"></param>
        public void AddCandidate(ICandidate candidate)
        {
            if (candidate.CanAdd())
                this.Candidates.Add(candidate);
        }

        /// <summary>
        /// Cancela a vaga
        /// </summary>
        public void Cancel()
        {
            this.Status = EVacancyStatus.Canceled;
        }

        /// <summary>
        /// Suspend a vaga
        /// </summary>
        public void Suspend()
        {
            this.Status = EVacancyStatus.Suspensed;
        }

        public bool CanAdd()
        {
            return this.RegisterVacancyScopeIsValid();
        }
        
        /// <summary>
        /// Verifica se a triagem de candidatos pode ser finalizada.
        /// </summary>
        /// <remarks>O método verifica o seguinte:
        /// 1) Se foi atribuído um peso para cada tecnologia relacionada à vaga
        /// 2) Se foi atribuído um nível de conhecimento para cada tecnologia relaciondo à cada candidato da vaga</remarks>
        /// <returns>Se retorno for verdadeiro, a triagem poderá ser finalizada. Ver método Finalize()</returns>
        /// <seealso cref="Finalize"/>
        private bool CanFinalize()
        {
            return this.FinalizeVacancyScopeIsValid();
        }
        
        private void SetWeightToCandidateTechnologies()
        {
            foreach (IVacancyTechnology vacancyTech in this._vacancyTechnologies)
            {   
                foreach (ICandidate candidate in this._candidates)
                {
                    foreach (ICandidateTechnology candidateTech in candidate.CandidateTechnologies
                        .Where(y => y.TechnologyId == vacancyTech.TechnologyId))
                    {
                        candidateTech.SetWeight(vacancyTech.Weight);
                    }
                }
            }
        }

        /// <summary>
        /// Método para finalizar a triagem de candidatos.
        /// </summary>
        /// <remarks>Após a checagem se a vaga pode ser finalizada, a situação será alterada para Fechada(2-Closed) 
        /// e será devolvido uma lista com os nomes dos candidatos e suas respectivas pontuações.
        /// A lista é ordenada pelo candidato</remarks>
        /// <seealso cref="CanFinalize">O método CanFinalize será chamado para verificar se a triagem pode ser finalizada</seealso>/>
        public List<Finalized> Finalize()
        {
            if (CanFinalize())
            {
                SetWeightToCandidateTechnologies();

                this.Status = EVacancyStatus.Finalized;

                return _candidates.OrderBy(x => x.Name)
                    .Select(x => new Finalized { Name = x.Name, Pontuation = x.Pontuation }).ToList();
            }
            else
            {
                return new List<Finalized>();
            }
        }
        #endregion
    }
}
