namespace SwordITS.CodeTest.Services.Exceptions
{
    using System;

    public class CandidateValidationFailedException : Exception
    {
        public CandidateValidationFailedException()
        {
        }

        public CandidateValidationFailedException(string message) : base(message)
        {
        }

        public CandidateValidationFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

}