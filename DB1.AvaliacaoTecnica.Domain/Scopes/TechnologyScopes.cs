using DB1.AvaliacaoTecnica.Domain.Contracts;
using DB1.AvaliacaoTecnica.SharedKernel.Validation;

namespace DB1.AvaliacaoTecnica.Domain.Scopes
{
    public static class TechnologyScopes
    {
        public static bool RegisterTechnologyScopeIsValid(this ITechnology technology)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(technology.Description, "A Descrição da Tecnologia é obrigatória")
            );
        }
    }
}
