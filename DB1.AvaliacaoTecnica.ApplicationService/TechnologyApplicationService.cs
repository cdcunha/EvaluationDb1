using DB1.AvaliacaoTecnica.Domain.Services;
using System.Collections.Generic;
using DB1.AvaliacaoTecnica.Domain.Commands.TechnologyCommands;
using DB1.AvaliacaoTecnica.Domain.Models;
using DB1.AvaliacaoTecnica.Domain.Contracts.Repositories;
using DB1.AvaliacaoTecnica.Infrastructure.Persistence;

namespace DB1.AvaliacaoTecnica.ApplicationService
{
    public class TechnologyApplicationService : ApplicationService, ITechnologyApplicationService
    {
        private ITechnologyRepository _repository;

        public TechnologyApplicationService(ITechnologyRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
        }

        public Technology Create(string description)
        {
            Technology technology = new Technology(description);
            if(technology.CanAdd())
            {
                _repository.Create(technology);
                if(Commit())
                    return technology;
            }
            return null;
        }

        public Technology Delete(int id)
        {
            Technology technology = _repository.Get(id);
            _repository.Delete(technology);

            if(Commit())
                return technology;

            return null;
        }

        public List<Technology> Get()
        {
            return _repository.Get();
        }

        public Technology Get(int id)
        {
            return _repository.Get(id);
        }

        public Technology Update(EditTechnologyCommand command)
        {
            Technology technology = _repository.Get(command.Id);
            if(technology.CanAdd())
            {
                _repository.Update(technology);
                if(Commit())
                    return technology;
            }

            return null;
        }
    }
}
