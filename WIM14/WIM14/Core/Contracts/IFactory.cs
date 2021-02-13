using System;
using System.Collections.Generic;
using System.Text;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;

namespace WIM14.Core.Contracts
{
    public interface IFactory
    {
        IBoard CreateBoard(string name, IList<IWorkItem> workItems, IList<HistoryEntry> history);
        IMember CreateMember(string name, IList<IWorkItem> workItems, IList<HistoryEntry> history, ITeam team);
        ITeam CreateTeam(string name, IList<IMember> members, IList<IBoard> boards);
        IBug CreateBug(string title, string description, List<string> stepsToReproduce, Priority priority, Severity severity);
        IStory CreateStory(string title, string description, Priority priority, Size size);
        IFeedback CreateFeedback(string title, string description, int rating);
    }
}
