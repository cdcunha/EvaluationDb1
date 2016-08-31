using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB1.AvaliacaoTecnica.SharedKernel.Helpers
{
    public class Finalized
    {
        public Finalized(){}

        public Finalized(string name, int pontuation)
        {
            this.Name = name;
            this.Pontuation = pontuation;
        }

        public string Name { get; set; }
        public int Pontuation { get; set; }
    }
}
