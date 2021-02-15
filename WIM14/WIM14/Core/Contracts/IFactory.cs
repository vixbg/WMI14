using System;
using System.Collections.Generic;
using System.Text;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;

namespace WIM14.Core.Contracts
{
    public interface IFactory
    {
        IBoard CreateBoard(string name);
        IMember CreateMember(string name);
        ITeam CreateTeam(string name);
        IBug CreateBug(string title, string description, List<string> stepsToReproduce, Priority priority, Severity severity);
        IStory CreateStory(string title, string description, Priority priority, Size size);
        IFeedback CreateFeedback(string title, string description, int rating);
    }
}
