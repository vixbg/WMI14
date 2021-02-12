using System.Collections.Generic;
using WIM14.Core.Contracts;
using WIM14.Models.Contracts;

namespace WIM14.Core
{
    class Database : IDatabase
    {
        private static IDatabase instance = null;
        public static IDatabase Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Database();
                }

                return instance;
            }
        }

        private readonly List<IMember> members = new List<IMember>();
        public IList<IMember> Members => this.members;

        private readonly List<ITeam> teams = new List<ITeam>();
        public IList<ITeam> Teams => this.teams;

        private readonly List<IWorkItem> workItems = new List<IWorkItem>();
        public IList<IWorkItem> WorkItems => this.workItems;

        // Add team, edit team, remove team

        /*
        public Member CreateMember(string name, Team team) // Move to Factory 
        {
            if (Database.Members.Any(m => m.Name == name))
            {
                throw new Exception("Member with that name already exists!");
            }
            return new Member()
            {
                Id = Database.Members.Max(m => m.Id) + 1,
                Name = name,
                History = new List<object>(),
                Team = team
            };
        }
        */
        //JSON 
        /*
        public void Save()
        {
            var database = JsonSerializer.Serialize(Teams, new JsonSerializerOptions()
            {
                
            });
            File.WriteAllText("database.json", database);
        }

        public void Load()
        {
            if (!File.Exists("database.json"))
            {
                Teams = new List<Team>();
                return;
            }
            var database = File.ReadAllText("database.json");
            Teams = JsonSerializer.Deserialize<List<Team>>(database);
        }
        */
    }
}
