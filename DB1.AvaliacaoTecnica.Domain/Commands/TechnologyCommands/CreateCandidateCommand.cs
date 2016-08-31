using DB1.AvaliacaoTecnica.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB1.AvaliacaoTecnica.Domain.Commands.TechnologyCommands
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
