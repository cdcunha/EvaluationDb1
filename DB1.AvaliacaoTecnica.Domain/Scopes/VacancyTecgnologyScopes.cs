using DB1.AvaliacaoTecnica.Domain.Contracts;
using DB1.AvaliacaoTecnica.SharedKernel.Validation;

namespace DB1.AvaliacaoTecnica.Domain.Scopes
{
    public static class VacancyTecgnologyScopes
    {
        public static bool RegisterVacancyTechnologyScopeIsValid(this IVacancyTechnology vacancyTechnology)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNull(vacancyTechnology.VacancyId, "A Vaga é obrigatória"),
                AssertionConcern.AssertNotNull(vacancyTechnology.TechnologyId, "A Tecnologia é obrigatória")
            );
        }

        public static bool UpdateWeightScopeIsValid(this ICandidateTechnology vacancyTechnology, int weight)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertLength(vacancyTechnology.Weight.ToString(), 0, 10, "O valor do Peso deve estar entre 0 e 10")
            );
        }
    }
}
