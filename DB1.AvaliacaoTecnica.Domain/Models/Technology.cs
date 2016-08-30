using DB1.AvaliacaoTecnica.Domain.Contracts;
using System;

namespace DB1.AvaliacaoTecnica.Domain.Models
{
    public class Technology : ITechnology
    {
        //Contrutor para ser usado pelo EntityFramework
        public Technology() { }

        public Technology(string description)
        {
            this.Id = Guid.NewGuid();
            this.Description = description;
        }

        public Guid Id { get; private set; }
        public string Description { get; private set; }
    }
}
