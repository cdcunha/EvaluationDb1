using DB1.AvaliacaoTecnica.Domain.Contracts;
using DB1.AvaliacaoTecnica.SharedKernel.Validation;

namespace DB1.AvaliacaoTecnica.Domain.Scopes
{
    public static class VacancyScopes
    {
        public static bool RegisterVacancyScopeIsValid(this IVacancy vacancy)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNull(vacancy.Description, "A Descrição da vaga é obrigatória"),
                AssertionConcern.AssertNotNull(vacancy.VacancyTechnologies, "A escolha de ao menos uma tecnologia é obrigatória")
            );
        }
    }
}
