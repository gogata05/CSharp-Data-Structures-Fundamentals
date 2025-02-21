using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NationalElectionSystem
{
    public class ElectionManager : IElectionManager
    {
        private Dictionary<string, Candidate> candidates = new Dictionary<string, Candidate>();
        private Dictionary<string,Voter> voters = new Dictionary<string, Voter>();

        
        public void AddCandidate(Candidate candidate)
        {
            this.candidates.Add(candidate.Id, candidate);
        }

        public void AddVoter(Voter voter)
        {
            this.voters.Add(voter.Id, voter);
        }

        public bool Contains(Candidate candidate)
        {
          return this.candidates.ContainsKey(candidate.Id);
        }

        public bool Contains(Voter voter)
        {
            return this.voters.ContainsKey(voter.Id);
        }

        public IEnumerable<Candidate> GetCandidates()
        {
           return this.candidates.Values;
        }

        public IEnumerable<Voter> GetVoters()
        {
            return this.voters.Values;
        }

        public void Vote(string voterId, string candidateId)
        {

			if (!this.voters.ContainsKey(voterId) || !this.candidates.ContainsKey(candidateId)|| this.voters[voterId].Age < 18 || this.voters[voterId].IsVoted)
            {
                throw new ArgumentException();
            }

			var voter = this.voters[voterId];
			var candidate = GetCandidate(candidateId);

			candidate.CountVotes++;
            voter.IsVoted = true;

        }

		private Candidate GetCandidate(string candidateId)
		{
			return this.candidates[candidateId];
		}

		public int GetVotesForCandidate(string candidateId)
        {
          return GetCandidate(candidateId).CountVotes;
        }

        public IEnumerable<Candidate> GetWinner()
        {
            var winners =  this.candidates.Where(c => c.Value.CountVotes == this.candidates.Max(c => c.Value.CountVotes)).Select(c => c.Value);

            if (winners.All(x => x.CountVotes == 0))
            {
                return null;
            }

            return winners;
           
        }

        public IEnumerable<Candidate> GetCandidatesByParty(string party)
        {
            return this.candidates.Where(c => c.Value.Party == party).OrderByDescending(c => c.Value.CountVotes).Select(c => c.Value);
        }
    }
}