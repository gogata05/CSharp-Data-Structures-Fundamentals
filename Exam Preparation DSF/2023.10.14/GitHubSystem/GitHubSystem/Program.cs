using System;

namespace GitHubSystem
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var gitHubManager = new GitHubManager();
			var user = new User()
            {
				Id = "1",
				Username = "Pesho"
			};
			var user2 = new User()
			{
				Id = "2",
				Username = "Misho"
			};
			var repository = new Repository()
            {
				Id = "1",
				Name = "Test",
				OwnerId = "2"
			};
			var repository2 = new Repository()
			{
				Id = "2",
				Name = "Test",
				OwnerId = "2"
			};
			var commit = new Commit()
			{
				Id = "1",
				RepositoryId = "2",
				UserId = "1",
				Message = "Test",
				Timestamp = 123456789
			};
		
			gitHubManager.Create(user);
			gitHubManager.Create(user2);
			gitHubManager.Create(repository);
			gitHubManager.Create(repository2);

			//gitHubManager.CommitChanges(commit);
            gitHubManager.ForkRepository("2", "1");
			

			foreach (var item in gitHubManager.GetMostForkedRepositories())
			{
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Name);
            }
        }
    }
}