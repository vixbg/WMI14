using System;
using System.Collections.Generic;
using System.Text;
using WIM14.Commands.Abstracts;

namespace WIM14.Commands
{
    public class CreateBoardCommand : Command
    {
        public CreateBoardCommand(List<string> commandParameters) : base(commandParameters)
        {            
        }
        public override string Execute()
        {
            //ToDo
            throw new NotImplementedException();
        }
    }
}
