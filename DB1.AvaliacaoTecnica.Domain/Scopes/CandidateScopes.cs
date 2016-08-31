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
                AssertionConcern.AssertNotNull(candidate.VacancyId, "É necessario que o candidato esteja associado à uma vaga"),
                AssertionConcern.AssertNotNullOrEmpty(candidate.Name, "O Nome do candidato é obrigatório"),
                AssertionConcern.AssertIsGreaterThan(candidate.CandidateTechnologies.Count, 0, "É necessario que o candidato esteja associado ao menos a uma tecnologia")
            );
        }
    }
}
