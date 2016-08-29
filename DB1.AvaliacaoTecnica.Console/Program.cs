using System;
using System.Collections.Generic;
using System.Linq;

namespace DB1.AvaliacaoTecnica.Sequencias
{
    class Collatz
    {
        static void Main(string[] args)
        {
            #region Exercício 1
            Console.WriteLine("### EXERCÍCIO 1 ###");
            int num = 0;
            int count = 0;

            Exercicio1 exec1 = new Exercicio1();
            for (int i=1; i <= 1000000; i++)
            {
                exec1.InitializeAndRun(i);
                if (exec1.Sequence.Count > count)
                {
                    num = i;
                    count = exec1.Sequence.Count;
                }
            }

            Console.WriteLine(string.Format("O número inicial {0} produziu a maior sequência: {1} números", num, count));
            #endregion

            #region Exercício 2
            Console.WriteLine();
            Console.WriteLine("### EXERCÍCIO 2 ###");
            int[] numeros = { 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144 };
            Exercicio2 exec2 = new Exercicio2();
            if (exec2.Run(numeros))
                Console.WriteLine(string.Format("A sequencia ({0}) possui somente número ímpares.", string.Join(", ", numeros)));
            else
                Console.WriteLine(string.Format("A sequencia ({0}) NÃO possui somente número ímpares.", string.Join(", ", numeros)));
            Console.WriteLine(string.Join(", ", exec2.Odd.ToArray()));
            #endregion

            #region Exercício 3
            Console.WriteLine();
            Console.WriteLine("### EXERCÍCIO 3 ###");
            Exercicio3 exec3 = new Exercicio3();
            int[] primeiroArray = { 1, 3, 7, 29, 42, 98, 234, 93 };
            int[] segundoArray = { 4, 6, 93, 7, 55, 32, 3 };
            IEnumerable<int> nums = exec3.Run(primeiroArray, segundoArray);
            Console.WriteLine(string.Format("Números do primeiro array não contidos no segundo array: {0}", string.Join(", ", nums.ToArray())));
            #endregion

            Console.ReadKey();
        }
    }
}
