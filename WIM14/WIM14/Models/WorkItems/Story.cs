using System;
using System.Collections.Generic;
using System.Text;
using WIM14.Models.Contracts;
using Type = WIM14.Models.Enums.Type;

namespace WIM14.Models.WorkItems
{
    class Story : Abstracts.WorkItems, IStory, IType
    {
        private Type _type;

        Type IType.Type => _type;
    }
}
