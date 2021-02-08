using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using WIM14.Models;

namespace WIM14.Core
{
    class Database
    {
        public static List<Team> Teams { get; set; }
        public static List<Member> Members { get; set; }

        // Add team, edit team, remove team

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
    }
}
