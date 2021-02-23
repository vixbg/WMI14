using System;
using System.Collections.Generic;
using System.Linq;
using WIM14.Commands.Abstracts;
using WIM14.Core.Contracts;
using WIM14.Models.Collections;
using WIM14.Models.Contracts;

namespace WIM14.Commands
{
    class AddCommentToWorkItemCommand : Command
    {
        public AddCommentToWorkItemCommand(IList<string> commandParameters, IDatabase database, IFactory factory) : base(commandParameters, database, factory)
        {
        }
        //addcomment [ID] [Author] [Comment]
        public override string Execute()
        {
            int id;
            IWorkItem item;
            IComment comment = new Comment();
            string author;

            try
            {
                id = int.Parse(this.CommandParameters[0]);
                author = CommandParameters[1];
                var message = CommandParameters[2];

                item = this.Database.WorkItems.FirstOrDefault(w => w.Id == id) as IWorkItem;

                comment.Author = this.Database.Members.FirstOrDefault(m => m.Name == author);

                comment.Message = message;
            }
            catch 
            {
                throw new ArgumentException("Failed to parse AddComment command parameters.");

            }
            if (item == null)
            {
                throw new Exception($"No WorkItem was found with id {id}");
            }
            if (comment.Author == null)
            {
                throw new Exception($"No member was found with name {author}");
            }

            item.Comments.Add(comment);

            return $"Comment added successfully to {item.GetType().Name} with title {item.Title}.";
        }
    }
}
