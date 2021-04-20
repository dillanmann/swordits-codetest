using System;

namespace SwordITS.CodeTest.Model
{
    public class Candidate
    {        
        public int Id { get; init; }

        public string Name { get; init; }

        public CandidateOfferStatus? OfferStatus { get; init; }

        public override bool Equals(object obj)
        {
            return obj is Candidate candidate &&
                   Id == candidate.Id &&
                   Name == candidate.Name &&
                   OfferStatus == candidate.OfferStatus;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, OfferStatus);
        }
    }
}