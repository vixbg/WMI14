using System.Collections.Generic;
using WIM14.Core.Contracts;
using WIM14.Models;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;
using WIM14.Models.WorkItems;

namespace WIM14.Core
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="WIM14.Core.Contracts.IFactory" />
    public class Factory : IFactory
    {
        private static IFactory instance;

        /// <summary>
        /// Gets the instance.
        /// </summary>
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

        /// <summary>
        /// Creates a board.
        /// </summary>
        /// <param name="name">String between 5 and 15 chars.</param>
        /// <returns></returns>
        public IBoard CreateBoard(string name)
        {
            return new Board(name);
        }

        /// <summary>
        /// Creates a bug.
        /// </summary>
        /// <param name="title">String between 10 and 50 chars.</param>
        /// <param name="description">String between 10 and 500 chars.</param>
        /// <param name="stepsToReproduce">Strings divided by "|".</param>
        /// <param name="priority">High, Medium, Low.</param>
        /// <param name="severity">Critical, Major, Minor.</param>
        /// <returns></returns>
        public IBug CreateBug(string title, string description, List<string> stepsToReproduce, Priority priority, Severity severity)
        {
            return new Bug(title, description, stepsToReproduce, priority, severity);
            
        }

        /// <summary>
        /// Creates a feedback.
        /// </summary>
        /// <param name="title">String between 10 and 50 chars.</param>
        /// <param name="description">String between 10 and 500 chars</param>
        /// <param name="rating">Feedback rating can be between 1 and 5.</param>
        /// <returns></returns>
        public IFeedback CreateFeedback(string title, string description, int rating)
        {
            return new Feedback(title, description, rating);
        }

        /// <summary>
        /// Creates a member.
        /// </summary>
        /// <param name="name">String between 5 and 15 chars.</param>
        /// <returns></returns>
        public IMember CreateMember(string name)
        {
            return new Member(name);
        }

        /// <summary>
        /// Creates a story.
        /// </summary>
        /// <param name="title">String between 10 and 50 chars</param>
        /// <param name="description">String between 10 and 500 chars</param>
        /// <param name="priority">High, Medium, Low.</param>
        /// <param name="size">NotDone, InProgress, Done.</param>
        /// <returns></returns>
        public IStory CreateStory(string title, string description, Priority priority, Size size)
        {
            return new Story(title, description, priority, size);
        }

        /// <summary>
        /// Creates a team.
        /// </summary>
        /// <param name="name">String between 5 and 15 chars</param>
        /// <returns></returns>
        public ITeam CreateTeam(string name)
        {
            return new Team(name);
        }
    }
}
