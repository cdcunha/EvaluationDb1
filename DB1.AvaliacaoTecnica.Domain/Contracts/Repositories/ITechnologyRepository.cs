using DB1.AvaliacaoTecnica.Domain.Models;
using System;
using System.Collections.Generic;

namespace DB1.AvaliacaoTecnica.Domain.Contracts.Repositories
{
    public interface ITechnologyRepository
    {
        List<Technology> Get();
        Technology Get(Guid id);
        void Create(Technology technology);
        void Update(Technology technology);
        void Delete(Technology technology);
    }
}
