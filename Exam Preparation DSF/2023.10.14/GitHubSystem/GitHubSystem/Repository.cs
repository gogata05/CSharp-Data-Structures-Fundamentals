using System.Collections.Generic;

namespace GitHubSystem
{
    public class Repository
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Stars { get; set; }

        public string OwnerId { get; set; }

        public int NumberOfForks { get; set; }

        public int NumberOfCommits { get; set; }

        public List<Commit> Commits { get; set; } = new List<Commit>();
    }
}