using System;
using System.Collections.Generic;
using System.Text;
using WIM14.Core.Contracts;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;
using WIM14.Models.WorkItems;

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
        public IBoard CreateBoard(string name, IList<IWorkItem> workItems, IList<HistoryEntry> history)
        {
            throw new NotImplementedException();
        }

        public IBug CreateBug(string title, string description, List<string> stepsToReproduce, Priority priority, Severity severity, IMember assignee)
        {
            return new Bug(title, description, stepsToReproduce, priority, severity, assignee);
            
        }

        public IFeedback CreateFeedback(string title, string description, int rating)
        {
            return new Feedback(title, description, rating);
        }

        public IMember CreateMember(string name, IList<IWorkItem> workItems, IList<HistoryEntry> history, ITeam team)
        {
            throw new NotImplementedException();
        }

        public IStory CreateStory(string title, string description, Priority priority, Size size, IMember assignee)
        {
            return new Story(title, description, priority, size, assignee);
        }

        public ITeam CreateTeam(string name, IList<IMember> members, IList<IBoard> boards)
        {
            throw new NotImplementedException();
        }
    }
}
