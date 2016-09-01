using DB1.AvaliacaoTecnica.Domain.Commands.VacancyTechnologyCommands;
using DB1.AvaliacaoTecnica.Domain.Models;
using DB1.AvaliacaoTecnica.SharedKernel.Helpers;
using System.Collections.Generic;

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
        List<Finalized> Finalize(int id);
    }
}
