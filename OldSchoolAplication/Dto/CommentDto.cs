using OldSchoolDomain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace OldSchoolAplication.Dto
{
    public class CommentDto
    {
        public static List<CommentDomain> CommandAddToDomain(string[] command)
        {
            List<CommentDomain> commentList = new();
            var postIds = command.Skip(5).Select(int.Parse).ToList();
            foreach (var item in postIds)
            {
                commentList.Add(new CommentDomain 
                { 
                    PostId = item,
                    Content = command[3],
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                });
            }
            return commentList; 
        }
        public static CommentOptions CommandReadToDomain(string[] command)
        {
            var options = new CommentOptions();

            if (command.Length > 3 && int.TryParse(command[3], out var postId))
            {
                options.PostId = postId;
            }

            if (command.Length > 5 && DateTime.TryParse(command[5], out var dateTime))
            {
                options.DateTime = dateTime;
            }

            if (command.Length > 7 && int.TryParse(command[7], out var top))
            {
                options.Top = top;
            }

            return options;
        }

        public static CommentDomain CommandUpdateToDomain(CommentDomain comment,string[] command)
        {
            comment.UpdatedAt = DateTime.Now;
            comment.Content = command[5];
            return comment;
        }
        public static int GetCommentId(string[] commands)
            => int.Parse(commands[3]);
        public static int[] CommandDeleteToDomain(string[] command)
        {
            return command.Skip(3).Select(int.Parse).ToArray();
        }
    }

    public class CommentOptions()
    {
        public DateTime? DateTime { get; set; }
        public int? Top { get; set; }
        public int PostId { get; set; }
    }
}
