using System;
using System.Collections.Generic;
using System.Text;
using WIM14.Core.Contracts;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;

namespace WIM14.Core
{
    public class Factory : IFactory
    {
        private static IFactory instance;

        public static IFactory Instance 
        { 
            get
            {
                if(instance == null)
                {
                    instance = new Factory();
                }

                return instance;
            }
        }
        public IBoard CreateBoard(string name, IList<IWorkItems> workItems, IList<HistoryEntry> history)
        {
            throw new NotImplementedException();
        }

        public IBug CreateBug(int id, string title, string description, List<string> stepsToReproduce, Priority priority, Severity severity, BugStatus status, IMember member, List<string> comment, IList<HistoryEntry> history)
        {
            throw new NotImplementedException();
        }

        public IFeedback CreateFeedback(int id, string title, string description, int rating, List<string> comment, IList<HistoryEntry> history)
        {
            throw new NotImplementedException();
        }

        public IMember CreateMember(string name, IList<IWorkItems> workItems, IList<HistoryEntry> history, ITeam team)
        {
            throw new NotImplementedException();
        }

        public IStory CreateStory(int id, string title, string description, Priority priority, Size size, StoryStatus status, IMember member, List<string> comment, IList<HistoryEntry> history)
        {
            throw new NotImplementedException();
        }

        public ITeam CreateTeam(string name, IList<IMember> members, IList<IBoard> boards)
        {
            throw new NotImplementedException();
        }
    }
}
