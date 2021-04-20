namespace SwordITS.CodeTest.Services.Exceptions
{
    using System;

    public class CandidateAlreadyExistsException : Exception
    {
        public CandidateAlreadyExistsException()
        {
        }

        public CandidateAlreadyExistsException(string message) : base(message)
        {
        }

        public CandidateAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

}