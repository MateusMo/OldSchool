using OldSchoolAplication.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldSchoolAplication
{
    public class Syntax
    {
        public string[] Login { get; set; }
        
        public string[] CreateUser { get; set; }
        public string[] DeleteUser { get; set; }
        public string[] ReadUser { get; set; }
        public string[] ReadMe { get; set; }
        public string[] UpdateUser { get; set; }

        public string[] CreatePost { get; set; }
        public string[] CreatePostWithMindset { get; set; }

        public string[] DeletePost { get; set; }
        public string[] ReadPost { get; set; }
        public string[] UpdatePost { get; set; }
        public string[] LikePost { get; set; }

        public string[] CreateComment { get; set; }
        public string[] DeleteComment { get; set; }
        public string[] ReadComment { get; set; }
        public string[] ReadCommentById { get; set; }
        public string[] UpdateComment { get; set; }

        public string[] CreateMindset { get; set; }
        public string[] DeleteMindset { get; set; }
        public string[] ReadMindset { get; set; }
        public string[] UpdateMindset { get; set; }
        public string[] LikeMindset { get; set; }


        public static Syntax GetSyntax()
        {
            var syntax = new Syntax()
            {
                //Login basic syntax
                Login = ["MAY", "I","COME","IN","?","NICKNAME","","PASSWORD",""],

                //User basic syntax
                CreateUser = ["CREATE", "USER", "NICKNAME", "", "PASSWORD", ""],
                DeleteUser = ["DELETE", "ME"],
                ReadMe = ["READ","ME"],
                ReadUser = ["READ", "USER", "ID", ""],
                UpdateUser = ["UPDATE", "ME", "NICKNAME", "", "PASSWORD", ""],

                //Post basic syntax
                CreatePost = ["CREATE", "POST", "CONTENT", ""],
                CreatePostWithMindset = ["CREATE", "POST", "CONTENT", "","MINDSET_ID",""],
                DeletePost = ["DELETE", "POST", "ID", ""],
                ReadPost = ["READ", "POST", "ID", ""],
                UpdatePost = ["UPDATE", "POST", "ID", "", "CONTENT", ""],
                LikePost = ["LIKE", "POST", "ID", ""],

                //Comment basic syntax
                CreateComment = ["CREATE", "COMMENT", "CONTENT", "", "POST_ID", ""],
                DeleteComment = ["DELETE", "COMMENT", "ID", ""],
                ReadComment = ["READ", "COMMENT", "POST_ID", "", "DATE", "", "TOP", ""],
                ReadCommentById = ["READ","COMMENT","ID",""],
                UpdateComment = ["UPDATE", "COMMENT", "ID", "", "CONTENT", ""],

                //Mindset basic syntax
                CreateMindset = ["CREATE", "MINDSET", "CONTENT", ""],
                DeleteMindset = ["DELETE", "MINDSET", "ID", ""],
                ReadMindset = ["READ", "MINDSET", "ID", ""],
                UpdateMindset = ["UPDATE", "MINDSET", "ID", "", "CONTENT", ""],
                LikeMindset = ["LIKE", "MINDSET", "ID", ""],

            };

            return syntax;
        }
    }
}
