namespace SwordITS.CodeTest.Services.Validation
{
    using SwordITS.CodeTest.Model;

    public class CandidateValidator : IDataValidator<Candidate>
    {
        public bool IsValid(Candidate data) => data != null && !string.IsNullOrWhiteSpace(data.Name);
    }
}