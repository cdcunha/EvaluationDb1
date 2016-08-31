using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB1.AvaliacaoTecnica.Domain.Commands.TechnologyCommands
{
    public class CreateCandidateTechnologyCommand
    {
        public CreateCandidateTechnologyCommand(int knowledgeLevel)
        {
            this.KnowledgeLevel = knowledgeLevel;
        }

        public int KnowledgeLevel { get; set; }
    }
}
