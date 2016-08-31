using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB1.AvaliacaoTecnica.Domain.Commands.TechnologyCommands
{
    public class CreateVacancyCommand
    {
        public CreateVacancyCommand(string description, IList<CreateVacancyTechnologyCommand> vacancyTechnologies, IList<CreateCandidateCommand> candidates)
        {
            this.Description = description;
            this.VacancyTechnologies = vacancyTechnologies;
            this.Candidates = candidates;
        }

        public string Description { get; set; }
        public IList<CreateVacancyTechnologyCommand> VacancyTechnologies { get; set; }
        public IList<CreateCandidateCommand> Candidates { get; set; }
    }
}
