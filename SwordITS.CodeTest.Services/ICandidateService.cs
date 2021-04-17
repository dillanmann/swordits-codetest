namespace SwordITS.CodeTest.Services
{
    using SwordITS.CodeTest.Model;

    public interface ICandidateService
    {
        bool CandidateExists(int id);

        Candidate GetCandidate(int id);

        Candidate CreateCandidate(Candidate candidate);

        void UpdateCandidate(Candidate candidate);
        
        void DeleteCandidate(int id);
    }
}