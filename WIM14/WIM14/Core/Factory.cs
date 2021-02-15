using System;
using System.Collections.Generic;
using System.Text;
using WIM14.Core.Contracts;
using WIM14.Models;
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
        public IBoard CreateBoard(string name)
        {
            return new Board(name);
        }

        public IBug CreateBug(string title, string description, List<string> stepsToReproduce, Priority priority, Severity severity)
        {
            return new Bug(title, description, stepsToReproduce, priority, severity);
            
        }

        public IFeedback CreateFeedback(string title, string description, int rating)
        {
            return new Feedback(title, description, rating);
        }

        public IMember CreateMember(string name)
        {
            return new Member(name);
        }

        public IStory CreateStory(string title, string description, Priority priority, Size size)
        {
            return new Story(title, description, priority, size);
        }

        public ITeam CreateTeam(string name)
        {
            return new Team(name);
        }
    }
}
