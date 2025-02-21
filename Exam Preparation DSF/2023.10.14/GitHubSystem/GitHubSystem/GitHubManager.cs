using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace GitHubSystem
{
    public class GitHubManager : IGitHubManager
    {
        private Dictionary<string, User> users = new Dictionary<string, User>();
        private Dictionary<string, Repository> repositories = new Dictionary<string, Repository>();
        

        public void Create(User user)
        {
            this.users.Add(user.Id, user);
        }

        public void Create(Repository repository)
        {
            this.repositories.Add(repository.Id, repository);
        }

        public bool Contains(User user)
        {
            return this.users.ContainsKey(user.Id);
        }

        public bool Contains(Repository repository)
        {
            return this.repositories.ContainsKey(repository.Id);
        }

        public void CommitChanges(Commit commit)
        {
            if (!this.users.ContainsKey(commit.UserId) || !this.repositories.ContainsKey(commit.RepositoryId))
            {
                throw new ArgumentException();
            }

            this.repositories[commit.RepositoryId].Commits.Add(commit);
            this.repositories[commit.RepositoryId].NumberOfCommits++;
        }

        public Repository ForkRepository(string repositoryId, string userId)
        {
			if (!this.users.ContainsKey(userId) || !this.repositories.ContainsKey(repositoryId))
			{
				throw new ArgumentException();
			}

            var repository = this.repositories[repositoryId];
            repository.NumberOfForks++;
            var newRepository = new Repository()
            {
				Name = repository.Name,
                OwnerId = userId,
				Commits = repository.Commits,
                Id = Guid.NewGuid().ToString(),
				Stars = 0,
				NumberOfForks = 0
			};

            this.repositories.Add(newRepository.Id, newRepository);
            return newRepository;
		}

        public IEnumerable<Commit> GetCommitsForRepository(string repositoryId)
        {
            return this.repositories[repositoryId].Commits;
        }

        public IEnumerable<Repository> GetRepositoriesByOwner(string userId)
        {
            return this.repositories.Values.Where(r => r.OwnerId == userId);
        }

        public IEnumerable<Repository> GetMostForkedRepositories()
        {
            return this.repositories.Values.OrderByDescending(r => r.NumberOfForks);

        }

        public IEnumerable<Repository> GetRepositoriesOrderedByCommitsInDescending()
        {
           return this.repositories.Values.OrderByDescending(r => r.NumberOfCommits);

            
        }
    }
}