using System;
using System.Collections.Generic;
using System.Text;
using WIM14.Commands.Contracts;

namespace WIM14.Core.Contracts
{
    public interface ICommandManager
    {
        ICommand ParseCommand(string commandLine);
    }
}
