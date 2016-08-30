using DB1.AvaliacaoTecnica.Domain.Contracts;
using DB1.AvaliacaoTecnica.SharedKernel.Validation;

namespace DB1.AvaliacaoTecnica.Domain.Scopes
{
    public static class CandidateTechnologyScopes
    {
        public static bool RegisterCandidateTechnologyScopeIsValid(this ICandidateTechnology candidateTechnology)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNull(candidateTechnology.CandidateId, "O Candidato é obrigatório"),
                AssertionConcern.AssertNotNull(candidateTechnology.TechnologyId, "A Tecnologia é obrigatória"),
                AssertionConcern.AssertNotNull(candidateTechnology.KnowledgeLevel, "O Nível de conhecimento é obrigatório"),
                AssertionConcern.AssertLength(candidateTechnology.KnowledgeLevel.ToString(), 0, 10, "O valor do Nível de conhecimento deve estar entre 0 e 10")
            );
        }

        public static bool UpdateWeightScopeIsValid(this ICandidateTechnology candidateTechnology, int weight)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertLength(weight.ToString(), 0, 10, "O valor do Peso deve estar entre 0 e 10")
            );
        }
    }
}
