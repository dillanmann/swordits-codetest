namespace SwordITS.CodeTest.Services.Exceptions
{
    using System;

    public class CandidateNotFoundException : Exception
    {
        public CandidateNotFoundException()
        {
        }

        public CandidateNotFoundException(string message) : base(message)
        {
        }

        public CandidateNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}