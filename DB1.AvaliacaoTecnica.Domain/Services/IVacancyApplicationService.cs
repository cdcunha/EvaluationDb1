using DB1.AvaliacaoTecnica.Domain.Commands.TechnologyCommands;
using DB1.AvaliacaoTecnica.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB1.AvaliacaoTecnica.Domain.Services
{
    public interface IVacancyApplicationService
    {
        List<Vacancy> Get();
        List<Vacancy> Get(string description);
        Vacancy GetDetails(int id);
        Vacancy Get(int id);
        Vacancy Create(CreateVacancyCommand command);
        Vacancy Update(EditVacancyCommand command);
        Vacancy Delete(int id);
        void Cancel(int id);
        void Suspend(int id);
    }
}
