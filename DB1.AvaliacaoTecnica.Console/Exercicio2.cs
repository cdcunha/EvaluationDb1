using System.Collections.Generic;
using System.Linq;

namespace DB1.AvaliacaoTecnica.Sequencias
{
    public class Exercicio2
    {
        public IEnumerable<int> Odd { get; private set; }
                
        public bool Run(int[] nums)
        {
            Odd = nums.Where(i => i % 2 != 0);
            return nums.SequenceEqual(Odd);
        }
    }
}
