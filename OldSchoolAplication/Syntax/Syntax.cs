﻿using OldSchoolAplication.Dto;
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
                //Login basic syntax
                Login = ["MAY", "I","COME","IN","?","NICKNAME","","PASSWORD",""],

                //User basic syntax
                CreateUser = ["CREATE", "USER", "NICKNAME", "", "PASSWORD", ""],
                DeleteUser = ["DELETE", "ME"],
                ReadUser = ["READ", "USER", "ID", ""],
                UpdateUser = ["UPDATE", "ME", "NICKNAME", "", "PASSWORD", ""],

                //Post basic syntax
                CreatePost = ["CREATE", "POST", "CONTENT", "", "ASCII", "", "KEYWORDS", "", "LINKS", ""],
                DeletePost = ["DELETE", "POST", "ID", ""],
                ReadPost = ["READ", "POST", "ID", ""],
                UpdatePost = ["UPDATE", "POST", "ID", "", "CONTENT", "", "ASCII", "", "KEYWORDS", "", "LINKS", ""],
                LikePost = ["LIKE", "POST", "ID", ""],

                //Comment basic syntax
                CreateComment = ["CREATE", "COMMENT", "CONTENT", "", "POST", ""],
                DeleteComment = ["DELETE", "COMMENT", "ID", ""],
                ReadComment = ["READ", "COMMENT", "POST", "", "DATE", "", "TOP", ""],
                UpdateComment = ["UPDATE", "COMMENT", "ID", "", "CONTENT", ""],
            };

            return syntax;
        }
    }
}
