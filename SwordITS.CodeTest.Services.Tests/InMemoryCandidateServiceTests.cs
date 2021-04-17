namespace SwordITS.CodeTest.Services.Tests
{
    using SwordITS.CodeTest.Services;
    using SwordITS.CodeTest.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;

    public class InMemoryCandidateServiceTests
    {
        private ICandidateService candidateService;
        private static List<Candidate> candidates = new List<Candidate>
        {
            new Candidate()
            {
                Id = 1,
                Name = "Bob LeBlaw",
                OfferedPosition = null
            },
            new Candidate()
            {
                Id = 2,
                Name = "Pepe LePew",
                OfferedPosition = false
            },
        };

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CandidateExistsTest_CandidateExists_ReturnsTrue()
        {
            this.candidateService = new InMemoryCandidateService(candidates);

            Assert.IsTrue(candidateService.CandidateExists(1));
        }

        [Test]
        public void CandidateExistsTest_CandidateDoesNotExist_ReturnsFalse()
        {
            this.candidateService = new InMemoryCandidateService(candidates);

            Assert.IsFalse(candidateService.CandidateExists(3));
        }

        [Test]
        public void GetAllCandidatesTest()
        {
            this.candidateService = new InMemoryCandidateService(candidates);

            IEnumerable<Candidate> fetchedCandidates = this.candidateService.GetAllCandidates();

            Assert.AreEqual(candidates.Count(), fetchedCandidates.Count());
            CollectionAssert.AreEqual(candidates, fetchedCandidates);
        }

        [Test]
        public void GetCandidateTest_CandidateExists_ReturnsCandidate()
        {
            this.candidateService = new InMemoryCandidateService(candidates);

            Candidate fetchedCandidate = this.candidateService.GetCandidate(1);

            Assert.AreEqual(candidates.ElementAt(0), fetchedCandidate);
        }

        [Test]
        public void GetCandidateTest_CandidateDoesNotExist_ThrowsException()
        {
            this.candidateService = new InMemoryCandidateService(candidates);

            Assert.Throws<KeyNotFoundException>(() => this.candidateService.GetCandidate(3));
        }

        [Test]
        public void DeleteCandidateTest_CandidateExists_DeletesCandidate()
        {
            this.candidateService = new InMemoryCandidateService(candidates);

            this.candidateService.DeleteCandidate(1);
            IEnumerable<Candidate> fetchedCandidates = this.candidateService.GetAllCandidates();

            Assert.AreEqual(1, fetchedCandidates.Count());
            Assert.AreEqual(candidates.ElementAt(1), fetchedCandidates.Single());            
        }

        [Test]
        public void DeleteCandidateTest_CandidateDoesNotExist_ThrowsException()
        {
            this.candidateService = new InMemoryCandidateService(candidates);

            Assert.Throws<KeyNotFoundException>(() => this.candidateService.DeleteCandidate(3));
        }

        [Test]
        public void CreateCandidateTest_ValidCandidate_CandidateIsAdded()
        {
            this.candidateService = new InMemoryCandidateService(candidates);
            Candidate newCandidate = new Candidate
            {
                Id = 3,
                Name = "John Doe",
                OfferedPosition = null
            };

            this.candidateService.CreateCandidate(newCandidate);
            IEnumerable<Candidate> fetchedCandidates = this.candidateService.GetAllCandidates();

            Assert.AreEqual(3, fetchedCandidates.Count());
            Assert.AreEqual(newCandidate, fetchedCandidates.Last());
        }

        [Test]
        public void CreateCandidateTest_CandidateAlreadyExists_ThrowsException()
        {
            this.candidateService = new InMemoryCandidateService(candidates);
            Candidate newCandidate = new Candidate
            {
                Id = 1,
                Name = "John Doe",
                OfferedPosition = null
            };

            Assert.Throws<ArgumentException>(() => this.candidateService.CreateCandidate(newCandidate));
        }

        [TestCase("", Description="Empty")]
        [TestCase(" ", Description="Whitespace")]
        [TestCase(null, Description="Null")]
        public void CreateCandidateTest_InvalidCandidateName_ThrowsException(string name)
        {
            this.candidateService = new InMemoryCandidateService(candidates);
            Candidate newCandidate = new Candidate
            {
                Id = 3,
                Name = name,
                OfferedPosition = null
            };

            Assert.Throws<ArgumentException>(() => this.candidateService.CreateCandidate(newCandidate));
        }

        [Test]
        public void UpdateCandidateTest_CandidateDoesNotExist_ThrowsException()
        {
            this.candidateService = new InMemoryCandidateService(candidates);
            Candidate newCandidate = new Candidate
            {
                Id = 3,
                Name = "John Doe",
                OfferedPosition = null
            };

            Assert.Throws<ArgumentException>(() => this.candidateService.UpdateCandidate(newCandidate));
        }

        [Test]
        public void UpdateCandidateTest_ValidCandidate_UpdatesCandidate()
        {
            this.candidateService = new InMemoryCandidateService(candidates);
            Candidate newCandidate = new Candidate
            {
                Id = 1,
                Name = "Bob LeBlaw",
                OfferedPosition = true
            };

            this.candidateService.UpdateCandidate(newCandidate);
            IEnumerable<Candidate> fetchedCandidates = this.candidateService.GetAllCandidates();
            
            Assert.AreEqual(2, fetchedCandidates.Count());
            Assert.AreEqual(newCandidate, fetchedCandidates.Single(cand => cand.Id == 1));
        }
    }
}