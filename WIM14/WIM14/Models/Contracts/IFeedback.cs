using System;
using System.Collections.Generic;
using System.Text;
using WIM14.Models.Enums;

namespace WIM14.Models.Contracts
{
    public interface IFeedback : IWorkItem, IWorkItemStatus<FeedbackStatus>
    {
        int Raiting { get; }
    }
}
