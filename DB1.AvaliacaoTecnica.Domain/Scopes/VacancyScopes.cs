using DB1.AvaliacaoTecnica.Domain.Contracts;
using DB1.AvaliacaoTecnica.SharedKernel.Validation;
using System.Collections.Generic;
using System.Linq;

namespace DB1.AvaliacaoTecnica.Domain.Scopes
{
    public static class VacancyScopes
    {
        public static bool RegisterVacancyScopeIsValid(this IVacancy vacancy)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(vacancy.Description, "A Descrição da vaga é obrigatória"),
                AssertionConcern.AssertNotNull(vacancy.VacancyTechnologies, "A escolha de ao menos uma tecnologia é obrigatória")
            );
        }

        public static bool FinalizeVacancyScopeIsValid(this IVacancy vacancy)
        {
            return AssertionConcern.IsSatisfiedBy(
                AssertionConcern.AssertIsGreaterThan(vacancy.VacancyTechnologies.Where(x => x.Weight > 0).Count(), 0, "É necessário atribuir Peso às Tecnologias"),
                AssertionConcern.AssertIsGreaterThan(vacancy.Candidates.Where(x => x.GetKnowledgeLevelSeted() > 0).Count(), 0, "É necessário atribuir Nível de Conhecimento à cada tecnologia dos Candidatos")
            );
        }
    }
}
