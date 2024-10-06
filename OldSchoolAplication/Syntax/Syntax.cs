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
        public string[] CreateUser { get; set; }
        public string[] DeleteUser { get; set; }
        public string[] ReadUser { get; set; }
        public string[] UpdateUser { get; set; }

        public string[] CreatePost { get; set; }
        public string[] DeletePost { get; set; }
        public string[] ReadPost { get; set; }
        public string[] UpdatePost { get; set; }
        public string[] LikePost { get; set; }

        public string[] CreateComment { get; set; }
        public string[] DeleteComment { get; set; }
        public string[] ReadComment { get; set; }
        public string[] UpdateComment { get; set; }

        public static Syntax GetSyntax()
        {
            var syntax = new Syntax()
            {
                //User basic syntax
                CreateUser = ["CREATE", "USER", "NICKNAME", "", "PASSWORD", ""],
                DeleteUser = ["DELETE", "ME"],
                ReadUser = ["READ", "USER", "WITH", "ID", ""],
                UpdateUser = ["UPDATE", "ME", "SET", "NICKNAME", "", "PASSWORD", ""],

                //Post basic syntax
                CreatePost = ["CREATE", "POST", "CONTENT", "", "ASCII", "", "KEYWORDS", "", "LINKS", ""],
                DeletePost = ["DELETE", "MY", "POST", "WITH", "ID", ""],
                ReadPost = ["READ", "POST", "WITH", "ID", ""],
                UpdatePost = ["UPDATE", "MY", "POST", "WITH", "ID", "", "CONTENT", "", "ASCII", "", "KEYWORDS", "", "LINKS", ""],
                LikePost = ["LIKE", "POST", "WITH", "ID", ""],

                //Comment basic syntax
                CreateComment = ["CREATE", "COMMENT", "ON", "POST", "", "CONTENT", ""],
                DeleteComment = ["DELETE", "MY", "COMMENT", "ON", "POST", ""],
                ReadComment = ["READ", "COMMENT", "ON", "POST", "", "DATE", "", "TOP", ""],
                UpdateComment = ["UPDATE", "MY", "COMMENT", "ON", "POST", ""],
            };

            return syntax;
        }
    }
}
