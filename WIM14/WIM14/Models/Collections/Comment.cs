using System;
using System.Collections.Generic;
using System.Text;
using WIM14.Models.Contracts;

namespace WIM14.Models.Collections
{
    class Comment: IComment
    {
        public Comment(IMember author, string message)
        {
            this.Author = author;
            this.Message = message;
        }

        public IMember Author { get; set; }

        public string Message { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"**Author:{Author}**");
            sb.Append($"|{Message}|");
            return sb.ToString().Trim();
        }
    }
}
