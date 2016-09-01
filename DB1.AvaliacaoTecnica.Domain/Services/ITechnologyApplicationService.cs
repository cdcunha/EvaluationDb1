using DB1.AvaliacaoTecnica.Domain.Commands.TechnologyCommands;
using DB1.AvaliacaoTecnica.Domain.Models;
using System.Collections.Generic;

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
