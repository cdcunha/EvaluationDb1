﻿using DB1.AvaliacaoTecnica.Domain.Contracts.Repositories;
using DB1.AvaliacaoTecnica.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB1.AvaliacaoTecnica.Domain.Models;
using System.Data.Entity;
using DB1.AvaliacaoTecnica.SharedKernel.Validation;

namespace DB1.AvaliacaoTecnica.Infrastructure.Repositories
{
    public class TechnologyRepository : ITechnologyRepository
    {
        private StoreDataContext _context;

        public TechnologyRepository(StoreDataContext context)
        {
            this._context = context;
        }

        private bool HasDBConnectionAndNotificate()
        {
            return AssertionConcern.IsSatisfiedBy(
                AssertionConcern.AssertTrue(this._context.Database.Exists(), "Sem conexão com o Banco de Dados")
            );
        }

        public void Create(Technology technology)
        {
            this._context.Technologies.Add(technology);
        }

        public void Delete(Technology technology)
        {
            this._context.Technologies.Remove(technology);
        }

        public List<Technology> Get()
        {
            return this._context.Technologies
                .OrderBy(x => x.Description).ToList();
        }

        public Technology Get(int id)
        {
            return this._context.Technologies.Find(id);
        }

        public void Update(Technology technology)
        {
            this._context.Entry<Technology>(technology).State = EntityState.Modified;
        }
    }
}
