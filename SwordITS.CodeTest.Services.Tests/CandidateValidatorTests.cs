namespace SwordITS.CodeTest.Services.Tests
{
    using SwordITS.CodeTest.Services.Validation;
    using SwordITS.CodeTest.Model;
    using NUnit.Framework;

    public class CandidateValidatorTests
    {
        private CandidateValidator validator;

        [SetUp]
        public void Setup()
        {
            this.validator = new CandidateValidator();
        }

        [Test]
        public void IsValidTest_NullCandidate_ReturnsFalse()
        {
            Assert.IsFalse(this.validator.IsValid(null));
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void IsValidTest_CandidateWithInvalidName_ReturnsFalse(string name)
        {
            Candidate invalidCandidate = new Candidate
            {
                Name = name,
                Id = 0,
                OfferStatus = CandidateOfferStatus.NoDecisionMade
            };

            Assert.IsFalse(this.validator.IsValid(invalidCandidate));
        }

        [Test]
        public void IsValidTest_ValidCandidate_ReturnsTrue()
        {
            Candidate validCandidate = new Candidate
            {
                Name = "A Real Name",
                Id = 0,
                OfferStatus = CandidateOfferStatus.NoDecisionMade
            };

            Assert.IsTrue(this.validator.IsValid(validCandidate));
        }
    }

}