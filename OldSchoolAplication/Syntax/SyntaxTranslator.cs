using OldSchoolAplication.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldSchoolAplication
{
    public class SyntaxTranslator
    {
        private Syntax _syntax;

        public SyntaxTranslator()
        {
            _syntax = Syntax.GetSyntax();
        }
        public CommandContextEnum IdentifyContext(string[] commandParts)
        {
            //Delete me / Update me
            if (commandParts[0] == _syntax.DeleteUser[0] && commandParts[1] == _syntax.DeleteUser[1])
            {
                return CommandContextEnum.CurrentUserWantToDeleteAccount;
            }

            if (commandParts[0] == _syntax.UpdateUser[0] && commandParts[1] == _syntax.UpdateUser[0])
            {
                return CommandContextEnum.CurrentUserWantToUpdateAccount;
            }

            //User
            if (commandParts[0] == _syntax.CreateUser[0]
                && commandParts[1] == _syntax.CreateUser[1]
                && commandParts[2] == _syntax.CreateUser[2]
                && commandParts[4] == _syntax.CreateUser[4])
            {
                return CommandContextEnum.CreateUser;
            }

            if (commandParts[0] == _syntax.ReadUser[0]
                && commandParts[1] == _syntax.ReadUser[1]
                && commandParts[2] == _syntax.ReadUser[2]
                && commandParts[3] == _syntax.ReadUser[3])
            {
                return CommandContextEnum.ReadUser;
            }

            //Post
            if (commandParts[0] == _syntax.CreatePost[0]
                && commandParts[1] == _syntax.CreatePost[1]
                && commandParts[2] == _syntax.CreatePost[2]
                )
            {
                return CommandContextEnum.CreatePost;
            }

            if (commandParts[0] == _syntax.ReadPost[0]
                && commandParts[1] == _syntax.ReadPost[1]
                && commandParts[2] == _syntax.ReadPost[2]
                && commandParts[3] == _syntax.ReadPost[3])
            {
                return CommandContextEnum.ReadPost;
            }

            if (commandParts[0] == _syntax.DeletePost[0]
                && commandParts[1] == _syntax.DeletePost[1]
                && commandParts[2] == _syntax.DeletePost[2]
                && commandParts[3] == _syntax.DeletePost[3]
                && commandParts[4] == _syntax.DeletePost[4])
            {
                return CommandContextEnum.CurrentUserWantToDeleteHisPost;
            }

            if (commandParts[0] == _syntax.UpdatePost[0]
                && commandParts[1] == _syntax.UpdatePost[1]
                && commandParts[2] == _syntax.UpdatePost[2]
                && commandParts[3] == _syntax.UpdatePost[3]
                && commandParts[4] == _syntax.UpdatePost[4]
                && commandParts[6] == _syntax.UpdatePost[6])
            {
                return CommandContextEnum.CurrentUserWantToUpdatePost;
            }

            if (commandParts[0] == _syntax.LikePost[0]
                && commandParts[1] == _syntax.LikePost[1]
                && commandParts[2] == _syntax.LikePost[2]
                && commandParts[3] == _syntax.LikePost[3])
            {
                return CommandContextEnum.LikePost;
            }

            //Comment
            if (commandParts[0] == _syntax.CreateComment[0]
                && commandParts[1] == _syntax.CreateComment[1]
                && commandParts[2] == _syntax.CreateComment[2]
                && commandParts[4] == _syntax.CreateComment[4]
                )
            {
                return CommandContextEnum.CreateComment;
            }

            if (commandParts[0] == _syntax.ReadComment[0]
                && commandParts[1] == _syntax.ReadComment[1]
                && commandParts[2] == _syntax.ReadComment[2]
                && commandParts[3] == _syntax.ReadComment[3])
            {
                return CommandContextEnum.ReadComment;
            }

            if (commandParts[0] == _syntax.UpdateComment[0]
                && commandParts[1] == _syntax.UpdateComment[1]
                && commandParts[2] == _syntax.UpdateComment[2]
                && commandParts[3] == _syntax.UpdateComment[3])
            {
                return CommandContextEnum.CurrentUserWantToUpdateComment;
            }

            if (commandParts[0] == _syntax.DeleteComment[0]
                && commandParts[1] == _syntax.DeleteComment[1]
                && commandParts[2] == _syntax.DeleteComment[2]
                && commandParts[3] == _syntax.DeleteComment[3]
                && commandParts[4] == _syntax.DeleteComment[4])
            {
                return CommandContextEnum.CurrentUserWantToDeleteHisComment;
            }

            return CommandContextEnum.CommandNotFound;
        }
    }
}
