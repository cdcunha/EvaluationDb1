using DB1.AvaliacaoTecnica.Domain.Models;
using System.Collections.Generic;

namespace DB1.AvaliacaoTecnica.Domain.Commands.VacancyTechnologyCommands
{
    public class CreateCandidateCommand
    {
        public CreateCandidateCommand(string name, List<CandidateTechnology> candidateTechnologies)
        {
            this.Name = name;
            this.CandidateTechnologies = candidateTechnologies;
        }

        public string Name { get; set; }
        public List<CandidateTechnology> CandidateTechnologies { get; set; }
    }
}
