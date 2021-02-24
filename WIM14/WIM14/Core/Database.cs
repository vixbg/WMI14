using System.Collections.Generic;
using WIM14.Core.Contracts;
using WIM14.Models.Contracts;

namespace WIM14.Core
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="WIM14.Core.Contracts.IDatabase" />
    class Database : IDatabase
    {
        private static IDatabase instance = null;

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
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

        /// <summary>
        /// Gets the members.
        /// </summary>
        /// <value>
        /// The members.
        /// </value>
        public IList<IMember> Members => this.members;

        private readonly List<ITeam> teams = new List<ITeam>();

        /// <summary>
        /// Gets the teams.
        /// </summary>
        /// <value>
        /// The teams.
        /// </value>
        public IList<ITeam> Teams => this.teams;

        private readonly List<IWorkItem> workItems = new List<IWorkItem>();

        /// <summary>
        /// Gets the work items.
        /// </summary>
        /// <value>
        /// The work items.
        /// </value>
        public IList<IWorkItem> WorkItems => this.workItems;

    }
}
