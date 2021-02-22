using System;
using System.Collections.Generic;
using System.Linq;
using WIM14.Commands.Abstracts;
using WIM14.Models.Contracts;

namespace WIM14.Commands
{
    class CreateMemberCommand : Command
    {
        //createmember [MEMBERNAME] 
        public CreateMemberCommand(IList<string> commandParameters) : base(commandParameters)
        {
        }
        public override string Execute()
        {
            string personName = this.CommandParameters[0];

            if (this.Database.Members.ToList().Exists(person => person.Name == personName))
            {
                throw new ArgumentException($"Name {personName} is taken. Please provide a unique name.");
            }

            IMember newMember = this.Factory.CreateMember(personName);

            this.Database.Members.Add(newMember);

            return $"Member with ID {this.Database.Members.Count} was created.";
        }
    }
}
