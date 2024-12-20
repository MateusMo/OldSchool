﻿using OldSchoolAplication.Enum;
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
            //Login
            if (commandParts[0] == _syntax.Login[0]
                && commandParts[1] == _syntax.Login[1]
                && commandParts[2] == _syntax.Login[2]
                && commandParts[3] == _syntax.Login[3]
                && commandParts[4] == _syntax.Login[4]
                && commandParts[5] == _syntax.Login[5]
                && commandParts[7] == _syntax.Login[7])
            {
                return CommandContextEnum.Login;
            }
            //Delete me / Update me
            if (commandParts[0] == _syntax.DeleteUser[0] && commandParts[1] == _syntax.DeleteUser[1])
            {
                return CommandContextEnum.CurrentUserWantToDeleteAccount;
            }

            if (commandParts[0] == _syntax.UpdateUser[0] && commandParts[1] == _syntax.UpdateUser[1])
            {
                return CommandContextEnum.CurrentUserWantToUpdateAccount;
            }

            //User
            if (commandParts[0] == _syntax.ReadMe[0]
                && commandParts[1] == _syntax.ReadMe[1]
                )
            {
                return CommandContextEnum.ReadMe;
            }

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
                )
            {
                return CommandContextEnum.ReadUser;
            }

            //Post
            //Post com mindset precisa ser verificado antes
            if (commandParts[0] == _syntax.CreatePostWithMindset[0]
                && commandParts[1] == _syntax.CreatePostWithMindset[1]
                && commandParts[2] == _syntax.CreatePostWithMindset[2]
                && commandParts[4] == _syntax.CreatePostWithMindset[4]
                )
            {
                return CommandContextEnum.CreatePostWithMindset;
            }

            if (commandParts[0] == _syntax.CreatePost[0]
                && commandParts[1] == _syntax.CreatePost[1]
                && commandParts[2] == _syntax.CreatePost[2]
                )
            {
                return CommandContextEnum.CreatePost;
            }

            
            if (commandParts[0] == _syntax.ReadPost[0]
                && commandParts[1] == _syntax.ReadPost[1]
                && commandParts[2] == _syntax.ReadPost[2])
            {
                return CommandContextEnum.ReadPost;
            }

            if (commandParts[0] == _syntax.DeletePost[0]
                && commandParts[1] == _syntax.DeletePost[1]
                && commandParts[2] == _syntax.DeletePost[2]
                )
            {
                return CommandContextEnum.CurrentUserWantToDeleteHisPost;
            }

            if (commandParts[0] == _syntax.UpdatePost[0]
                && commandParts[1] == _syntax.UpdatePost[1]
                && commandParts[2] == _syntax.UpdatePost[2]
                && commandParts[4] == _syntax.UpdatePost[4])
            {
                return CommandContextEnum.CurrentUserWantToUpdatePost;
            }

            if (commandParts[0] == _syntax.LikePost[0]
                && commandParts[1] == _syntax.LikePost[1]
                && commandParts[2] == _syntax.LikePost[2])
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
                && commandParts[2] == _syntax.ReadComment[2])
            {
                return CommandContextEnum.ReadComment;
            }

            if (commandParts[0] == _syntax.ReadCommentById[0]
                && commandParts[1] == _syntax.ReadCommentById[1]
                && commandParts[2] == _syntax.ReadCommentById[2])
            {
                return CommandContextEnum.ReadCommentById;
            }

            if (commandParts[0] == _syntax.UpdateComment[0]
                && commandParts[1] == _syntax.UpdateComment[1]
                && commandParts[2] == _syntax.UpdateComment[2])
            {
                return CommandContextEnum.CurrentUserWantToUpdateComment;
            }

            if (commandParts[0] == _syntax.DeleteComment[0]
                && commandParts[1] == _syntax.DeleteComment[1]
                && commandParts[2] == _syntax.DeleteComment[2]
                )
            {
                return CommandContextEnum.CurrentUserWantToDeleteHisComment;
            }

            //Mindset
            if (commandParts[0] == _syntax.CreateMindset[0]
                && commandParts[1] == _syntax.CreateMindset[1]
                && commandParts[2] == _syntax.CreateMindset[2]
                )
            {
                return CommandContextEnum.CreateMindset;
            }

            if (commandParts[0] == _syntax.ReadMindset[0]
                && commandParts[1] == _syntax.ReadMindset[1]
                && commandParts[2] == _syntax.ReadMindset[2])
            {
                return CommandContextEnum.ReadMindset;
            }

            if (commandParts[0] == _syntax.DeleteMindset[0]
                && commandParts[1] == _syntax.DeleteMindset[1]
                && commandParts[2] == _syntax.DeleteMindset[2]
                )
            {
                return CommandContextEnum.CurrentUserWantToDeleteHisMindset;
            }

            if (commandParts[0] == _syntax.UpdateMindset[0]
                && commandParts[1] == _syntax.UpdateMindset[1]
                && commandParts[2] == _syntax.UpdateMindset[2]
                && commandParts[4] == _syntax.UpdateMindset[4])
            {
                return CommandContextEnum.CurrentUserWantToUpdateMindset;
            }

            if (commandParts[0] == _syntax.LikeMindset[0]
                && commandParts[1] == _syntax.LikeMindset[1]
                && commandParts[2] == _syntax.LikeMindset[2])
            {
                return CommandContextEnum.LikeMindset;
            }

            return CommandContextEnum.CommandNotFound;
        }
    }
}
