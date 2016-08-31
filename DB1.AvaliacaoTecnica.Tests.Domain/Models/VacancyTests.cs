using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DB1.AvaliacaoTecnica.Domain.Models;
using DB1.AvaliacaoTecnica.SharedKernel.Helpers;

namespace DB1.AvaliacaoTecnica.Tests.Domain.Models
{
    /// <summary>
    /// Summary description for VacancyTests
    /// </summary>
    [TestClass]
    public class VacancyTests
    {
        #region Propriedade privadas para teste
        private List<Finalized> finalizedsExpected = new List<Finalized>();

        #region Cria Candidato
        private Candidate validCandidate = new Candidate(1, "José dos Anzóis");
        private Candidate invalidCandidate = new Candidate(1, "José dos Anzóis da Silva");
        #endregion

        #region Cria Vaga
        private Vacancy validVacancy = new Vacancy("Programador");
        private Vacancy validVacancyInvalidCandidate = new Vacancy("Programador");
        #endregion

        #endregion

        public VacancyTests()
        {
            finalizedsExpected.Add(new Finalized("José dos Anzóis", 15));

            #region Adiciona Tecnologia ao Candidato
            validCandidate.AddCandidateTechnology(new CandidateTechnology(1, 1, 5));
            invalidCandidate.AddCandidateTechnology(new CandidateTechnology(1, 1, 5));
            #endregion
            
            #region Adiciona Candidato à Vaga
            validVacancy.AddCandidate(validCandidate);
            validVacancyInvalidCandidate.AddCandidate(invalidCandidate);
            #endregion

            #region Adiciona Tecnologia à Vaga
            validVacancy.AddTechnology(new VacancyTechnology(1, 1, 3));
            validVacancyInvalidCandidate.AddTechnology(new VacancyTechnology(1, 1, 3));
            #endregion
        }
        
        [TestMethod]
        [TestCategory("Vacancy")]
        public void ShouldFinalize()
        {
            List<Finalized> resultList = validVacancy.Finalize();
            
            //Caso a lista retornada tenha count diferente de um é erro
            if (resultList.Count != 1)
                Assert.AreEqual(true, false);
            else
            {
                bool result = finalizedsExpected[0].Name == resultList[0].Name &&
                               finalizedsExpected[0].Pontuation == resultList[0].Pontuation;
                Assert.AreEqual(true, result);
            }
        }

        [TestMethod]
        [TestCategory("Vacancy")]
        public void ShouldNotFinalize()
        {
            List<Finalized> resultList = validVacancyInvalidCandidate.Finalize();

            //Caso a lista retornada tenha count diferente de um é erro
            if (resultList.Count != 1)
                Assert.AreEqual(true, false);
            else
            {
                bool result = finalizedsExpected[0].Name == resultList[0].Name &&
                               finalizedsExpected[0].Pontuation == resultList[0].Pontuation;
                Assert.AreEqual(false, result);
            }
        }
    }
}
