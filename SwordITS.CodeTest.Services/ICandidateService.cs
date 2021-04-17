namespace SwordITS.CodeTest.Services
{
    using System.Collections.Generic;
    using SwordITS.CodeTest.Model;

    public interface ICandidateService
    {
        bool CandidateExists(int id);

        IEnumerable<Candidate> GetAllCandidates();

        Candidate GetCandidate(int id);

        Candidate CreateCandidate(Candidate candidate);

        void UpdateCandidate(Candidate candidate);

        void DeleteCandidate(int id);
    }
}