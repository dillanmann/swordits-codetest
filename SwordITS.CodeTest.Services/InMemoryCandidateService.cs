namespace SwordITS.CodeTest.Services
{
    using System;
    using System.Collections.Generic;
    using SwordITS.CodeTest.Model;

    public class InMemoryCandidateService : ICandidateService
    {
        private readonly List<Candidate> candidates;

        public InMemoryCandidateService(IEnumerable<Candidate> candidates)
        {
            this.candidates = new List<Candidate>(candidates ?? Array.Empty<Candidate>());
        }

        public bool CandidateExists(int id)
        {
            throw new System.NotImplementedException();
        }

        public Candidate CreateCandidate(Candidate candidate)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCandidate(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Candidate> GetAllCandidates()
        {
            throw new NotImplementedException();
        }

        public Candidate GetCandidate(int id)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCandidate(Candidate candidate)
        {
            throw new System.NotImplementedException();
        }
    }

}