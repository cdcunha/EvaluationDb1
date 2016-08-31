using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DB1.AvaliacaoTecnica.Domain.Scopes;
using DB1.AvaliacaoTecnica.Domain.Models;

namespace DB1.AvaliacaoTecnica.Tests.Domain.Scopes
{
    [TestClass]
    public class VacancyScopeTests
    {
        private Vacancy validVacancy = new Vacancy("Programador");
        private Vacancy invalidVacancy = new Vacancy("");

        public VacancyScopeTests()
        {
            validVacancy.AddTechnology(new VacancyTechnology(1, 1, 3));
        }

        [TestMethod]
        [TestCategory("Vacancy Scopes")]
        public void ShouldRegisterVacancy()
        {
            Assert.AreEqual(true, VacancyScopes.RegisterVacancyScopeIsValid(validVacancy));
        }

        [TestMethod]
        [TestCategory("Vacancy Scopes")]
        public void ShouldNotRegisterVacancy()
        {
            Assert.AreEqual(false, VacancyScopes.RegisterVacancyScopeIsValid(invalidVacancy));
        }
    }
}
