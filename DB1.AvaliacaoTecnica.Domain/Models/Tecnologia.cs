using DB1.AvaliacaoTecnica.Domain.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB1.AvaliacaoTecnica.Domain.Models
{
    public class Tecnologia : ITecnologia
    {
        //Contrutor para ser usado pelo EntityFramework
        public Tecnologia() { }

        public Tecnologia(string descricao)
        {
            this.Descricao = descricao;
        }

        public Guid Id { get; private set; }
        public string Descricao { get; private set; }
    }
}
