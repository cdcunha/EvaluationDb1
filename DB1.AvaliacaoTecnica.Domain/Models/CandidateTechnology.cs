using DB1.AvaliacaoTecnica.Domain.Contracts;
using DB1.AvaliacaoTecnica.Domain.Scopes;
using System;
using System.ComponentModel.DataAnnotations;

namespace DB1.AvaliacaoTecnica.Domain.Models
{
    public class CandidateTechnology : ICandidateTechnology
    {
        //Contrutor para ser usado pelo EntityFramework
        public CandidateTechnology() { }

        public CandidateTechnology(int candidateId, int technologyId, int knowledgeLevel)
        {
            this.CandidateId = candidateId;
            this.TechnologyId = technologyId;
            this.KnowledgeLevel = KnowledgeLevel;
        }

        public int Id { get; private set; }
        public int CandidateId { get; private set; }
        public int TechnologyId { get; private set; }

        [Range(0, 10)]
        public int KnowledgeLevel { get; private set; }

        [Range(0, 10)]
        public int Weight { get; private set; }
        
        public void SetWeight(int weight)
        {
            this.Weight = weight;
        }

        public bool CanAdd()
        {
            return this.RegisterCandidateTechnologyScopeIsValid();
        }
    }
}
