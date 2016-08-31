using DB1.AvaliacaoTecnica.Domain.Contracts;
using DB1.AvaliacaoTecnica.Domain.Scopes;
using System;

namespace DB1.AvaliacaoTecnica.Domain.Models
{
    public class Technology : ITechnology
    {
        //Contrutor para ser usado pelo EntityFramework
        public Technology() { }

        public Technology(string description)
        {
            this.Description = description;
        }

        public int Id { get; private set; }
        public string Description { get; private set; }

        public bool CanAdd()
        {
            return this.RegisterTechnologyScopeIsValid();
        }
    }
}
