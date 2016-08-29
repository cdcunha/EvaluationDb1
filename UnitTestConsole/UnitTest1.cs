using Microsoft.VisualStudio.TestTools.UnitTesting;
using DB1.AvaliacaoTecnica.Sequencias;
using System.Linq;

namespace UnitTestConsole
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [TestCategory("Exercício 1")]
        public void ShouldSameSequence()
        {
            long[] sequenceList =  new long[] { 13, 40, 20, 10, 5, 16, 8, 4, 2, 1 };

            Exercicio1 exerc1 = new Exercicio1();
            exerc1.InitializeAndRun(13);

            Assert.AreEqual(true, sequenceList.SequenceEqual(exerc1.Sequence.ToArray()));
        }

        [TestMethod]
        [TestCategory("Exercício 1")]
        public void ShouldLastItemBeNumberOne()
        {
            Exercicio1 exerc1 = new Exercicio1();
            exerc1.InitializeAndRun(13);

            Assert.AreEqual(true, exerc1.Sequence[9] == 1);
        }

        [TestMethod]
        [TestCategory("Exercício 1")]
        public void ShouldGreaterSequence()
        {
            Exercicio1 exerc1 = new Exercicio1();
            exerc1.InitializeAndRun(837799);

            Assert.AreEqual(true, exerc1.Sequence.Count == 525);
        }

        [TestMethod]
        [TestCategory("Exercício 2")]
        public void ShouldOnlyOddNumbers()
        {
            Exercicio2 exerc2 = new Exercicio2();
            Assert.AreEqual(true, exerc2.Run(new int[] { 1, 3, 5, 13, 21, 55, 89 }));
        }

        [TestMethod]
        [TestCategory("Exercício 2")]
        public void ShouldNotOnlyOddNumbers()
        {
            Exercicio2 exerc2 = new Exercicio2();
            Assert.AreEqual(false, exerc2.Run(new int[] { 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144 }));
        }

        [TestMethod]
        [TestCategory("Exercício 3")]
        public void ShouldNumbersFirstArrayThatNotIntercepSecondArray()
        {
            int[] primeiroArray = { 1, 3, 7, 29, 42, 98, 234, 93 };
            int[] segundoArray = { 4, 6, 93, 7, 55, 32, 3 };
            int[] resultArray = { 1, 29, 42, 98, 234 };

            Exercicio3 exerc3 = new Exercicio3();
            Assert.AreEqual(true, resultArray.SequenceEqual(exerc3.Run(primeiroArray, segundoArray).ToArray()));
        }
    }
}
