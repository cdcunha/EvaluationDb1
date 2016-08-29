using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB1.AvaliacaoTecnica.Sequencias
{
    public class Exercicio3
    {
        public IEnumerable<int> Run(int[] arr1, int[] arr2)
        {
            return arr1.Except(arr2);
        }
    }
}
