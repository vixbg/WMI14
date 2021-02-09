using System;
using System.Collections.Generic;
using System.Text;

namespace WIM14.Commands.Contracts
{
    public interface ICommand
    {
        string Execute();
    }
}
