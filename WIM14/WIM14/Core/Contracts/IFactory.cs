using System;
using System.Collections.Generic;
using System.Text;
using WIM14.Models.Contracts;
using WIM14.Models.Enums;

namespace WIM14.Core.Contracts
{
    public interface IFactory
    {
        IBoard CreateBoard(string name, IList<IWorkItems> workItems, IList<HistoryEntry> history);
        IMember CreateMember(string name, IList<IWorkItems> workItems, IList<HistoryEntry> history, ITeam team);
        ITeam CreateTeam(string name, IList<IMember> members, IList<IBoard> boards);
        IBug CreateBug(int id, string title, string description, List<string> stepsToReproduce, Priority priority, Severity severity, BugStatus status, IMember member, List<string> comment, IList<HistoryEntry> history);
        IStory CreateStory(int id, string title, string description, Priority priority, Size size, StoryStatus status, IMember member, List<string> comment, IList<HistoryEntry> history);
        IFeedback CreateFeedback(int id, string title, string description, int rating, List<string> comment, IList<HistoryEntry> history);
    }
}
