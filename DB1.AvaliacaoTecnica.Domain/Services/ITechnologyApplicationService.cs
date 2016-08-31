using DB1.AvaliacaoTecnica.Domain.Commands.TechnologyCommands;
using DB1.AvaliacaoTecnica.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB1.AvaliacaoTecnica.Domain.Services
{
    public interface ITechnologyApplicationService
    {
        List<Technology> Get();
        Technology Get(int id);
        Technology Create(string description);
        Technology Update(EditTechnologyCommand command);
        Technology Delete(int id);
    }
}
