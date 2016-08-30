using DB1.AvaliacaoTecnica.Domain.Contracts;
using DB1.AvaliacaoTecnica.SharedKernel.Validation;

namespace DB1.AvaliacaoTecnica.Domain.Scopes
{
    public static class CandidateScopes
    {
        public static bool RegisterCandidateScopeIsValid(this ICandidate candidate)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNull(candidate.VacancyId, "A Vaga do candidato é obrigatória"),
                AssertionConcern.AssertNotNull(candidate.Name, "O Nome do candidato é obrigatório")
            );
        }
    }
}
