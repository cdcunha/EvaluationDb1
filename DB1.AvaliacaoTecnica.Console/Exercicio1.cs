using System.Collections.Generic;


namespace DB1.AvaliacaoTecnica.Sequencias
{
    public class Exercicio1
    {
        public List<long> Sequence { get; private set; }

        public Exercicio1()
        {
            Sequence = new List<long>();
        }

        private void GenerateSequence(long num)
        {
            Sequence.Add(num);
            
            //Loop para gerar sequencia até que o número seja igual a 1
            while (num != 1)
            {   
                if (num % 2 == 0) //Se número é par
                {
                    num /= 2;
                }
                else
                {
                    num = (num * 3) + 1;
                }
                Sequence.Add(num);
            }
        }
                
        public void InitializeAndRun(int num)
        {
            Sequence.Clear();
            if (num > 0)
            {   
                GenerateSequence(num);
            }
        }
    }
}
