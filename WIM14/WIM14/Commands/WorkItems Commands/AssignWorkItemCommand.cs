﻿using System;
using System.Collections.Generic;
using System.Text;
using WIM14.Commands.Abstracts;

namespace WIM14.Commands
{
    class AssignWorkItemCommand : Command
    {
        public AssignWorkItemCommand(IList<string> commandParameters) : base(commandParameters)
        {
        }
        public override string Execute()
        {
            //ToDo
            throw new NotImplementedException();
        }
    }
}