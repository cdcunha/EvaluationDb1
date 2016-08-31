using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DB1.AvaliacaoTecnica.Domain.Scopes;
using DB1.AvaliacaoTecnica.Domain.Models;
using DB1.AvaliacaoTecnica.Domain.Contracts;

namespace DB1.AvaliacaoTecnica.Tests.Domain.Scopes
{
    /// <summary>
    /// Summary description for CandidateScopeTests
    /// </summary>
    [TestClass]
    public class CandidateScopeTests
    {
        private CandidateTechnology candidateTechnology = new CandidateTechnology(1, 1, 1);
        private Candidate validCandidate = new Candidate(1, "José dos Anzóis");
        private Candidate invalidCandidate = new Candidate(1, "");
        private Candidate candidateWithoutTechnologies = new Candidate(1, "José dos Anzóis");


        public CandidateScopeTests()
        {
            validCandidate.AddCandidateTechnology(candidateTechnology);
            invalidCandidate.AddCandidateTechnology(candidateTechnology);
            //candidateWithoutTechnologies.AddCandidateTechnology(new CandidateTechnology());
        }

        [TestMethod]
        [TestCategory("Candidate Scopes")]
        public void ShouldRegisterCandidate()
        {
            Assert.AreEqual(true, CandidateScopes.RegisterCandidateScopeIsValid(validCandidate));
        }

        [TestMethod]
        [TestCategory("Candidate Scopes")]
        public void ShouldNotRegisterCandidate()
        {
            Assert.AreEqual(false, CandidateScopes.RegisterCandidateScopeIsValid(invalidCandidate));
        }

        [TestMethod]
        [TestCategory("Candidate Scopes")]
        public void ShouldNotRegisterCandidateWithouTechnologies()
        {
            Assert.AreEqual(false, CandidateScopes.RegisterCandidateScopeIsValid(candidateWithoutTechnologies));
        }
    }
}
