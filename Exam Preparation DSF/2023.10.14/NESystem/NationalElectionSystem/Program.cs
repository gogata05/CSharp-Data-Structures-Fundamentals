using System;

namespace NationalElectionSystem
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var electionManager = new ElectionManager();
            var candidate1 = new Candidate()
            {
				Id = "1",
				Name = "Candidate 1",
				Party = "Party 1"
			};

            var candidate2 = new Candidate()
            {
                Id = "2",
                Name = "Candidate 2",
                Party = "Party 2"
            };
            var candidate3 = new Candidate()
            {
				Id = "3",
				Name = "Candidate 3",
				Party = "Party 3"
			};

            electionManager.AddCandidate(candidate1);
            electionManager.AddCandidate(candidate2);

            var voter1 = new Voter()
            {
				Id = "11",
				Name = "Voter 1",
				Age = 18
			};
            var voter2 = new Voter()
            {
                Id = "12",
				Name = "Voter 2",
				Age = 18,
				IsVoted = true
			};
			var voter3 = new Voter()
			{
				Id = "13",
				Name = "Voter 3",
				Age = 18
			}; 
			var voter4 = new Voter()
			{
				Id = "14",
				Name = "Voter 4",
				Age = 18
			};

			electionManager.AddVoter(voter1);
			electionManager.AddVoter(voter2);
			electionManager.AddVoter(voter3);

			//electionManager.Vote("1", "1");
			//electionManager.Vote("2", "1");
			//electionManager.Vote("3", "2");
			//electionManager.Vote("4", "2");

			electionManager.Vote("12", "1");
   //         Console.WriteLine(string.Join(",", result));
			//foreach (var candidate in result)
			//{
			//	Console.WriteLine(candidate.Name);
			//	Console.WriteLine();
			//}




		}
    }
}