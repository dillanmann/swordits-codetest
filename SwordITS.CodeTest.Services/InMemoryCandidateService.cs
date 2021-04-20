namespace SwordITS.CodeTest.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SwordITS.CodeTest.Model;
    using SwordITS.CodeTest.Services.Exceptions;
    using SwordITS.CodeTest.Services.Validation;

    public class InMemoryCandidateService : ICandidateService
    {
        private readonly List<Candidate> candidates;
        private readonly IDataValidator<Candidate> candidateValidator;

        public InMemoryCandidateService(IDataValidator<Candidate> candidateValidator, IEnumerable<Candidate> candidates = null)
        {
            this.candidates = new List<Candidate>(candidates ?? Array.Empty<Candidate>());
            this.candidateValidator = candidateValidator ?? throw new ArgumentNullException(nameof(candidateValidator));
        }

        public bool CandidateExists(int id) => this.candidates.Any(cand => cand.Id == id);

        public Candidate CreateCandidate(Candidate candidate)
        {
            int candidateId = candidate.Id;
            if (this.CandidateExists(candidateId))
            {
                throw new CandidateAlreadyExistsException($"Candidate with id `{candidateId}` already exists.");
            }

            if (!this.candidateValidator.IsValid(candidate))
            {
                throw new CandidateValidationFailedException($"Provided candidate is not valid.");
            }

            this.candidates.Add(candidate);
            return candidate;
        }

        public void DeleteCandidate(int id)
        {
            if (!this.CandidateExists(id))
            {
                throw new CandidateNotFoundException($"Candidate with id `{id}` does not exist.");
            }

            int candidateIndex = this.candidates.FindIndex(cand => cand.Id == id);
            this.candidates.RemoveAt(candidateIndex);
        }

        public IEnumerable<Candidate> GetAllCandidates() => this.candidates;

        public Candidate GetCandidate(int id)
        {
            if (!this.CandidateExists(id))
            {
                throw new CandidateNotFoundException($"Candidate with id `{id}` does not exist.");
            }

            return this.candidates.Single(cand => cand.Id == id);
        }

        public void UpdateCandidate(Candidate candidate)
        {
            int candidateId = candidate.Id;
            if (!this.CandidateExists(candidateId))
            {
                throw new CandidateNotFoundException($"Candidate with id `{candidateId}` does not exist.");
            }

            if (!this.candidateValidator.IsValid(candidate))
            {
                throw new CandidateValidationFailedException($"Provided candidate is not valid.");
            }

            Candidate existingCandidate = this.candidates.Single(cand => cand.Id == candidateId);

            this.candidates.Remove(existingCandidate);
            this.candidates.Add(candidate);
        }
    }

}