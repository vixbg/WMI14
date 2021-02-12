using System;
using System.Collections.Generic;
using System.Text;
using WIM14.Models.Contracts;

namespace WIM14.Core.Contracts
{
    public interface IDatabase
    {
        IList<IMember> Members { get; }
        IList<ITeam> Teams { get; }
        IList<IWorkItem> WorkItems { get; }
    }
}
