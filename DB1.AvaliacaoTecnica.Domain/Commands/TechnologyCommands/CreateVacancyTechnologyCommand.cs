using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB1.AvaliacaoTecnica.Domain.Commands.TechnologyCommands
{
    public class CreateVacancyTechnologyCommand
    {
        public CreateVacancyTechnologyCommand(int technologyId)
        {
            this.TechnologyId = technologyId;
        }

        public int TechnologyId { get; set; }
    }
}
