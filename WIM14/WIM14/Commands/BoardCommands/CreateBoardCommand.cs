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
            // listworkitems [type|all] [orderby|name] [orderdirection|asc]
            // listworkitems -type all -orderby name -orderdirection asc
            // listworkitems -order=name
        }
        public override string Execute()
        {
            //ToDo
            throw new NotImplementedException();
        }
    }
}
