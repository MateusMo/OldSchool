using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldSchoolAplication.Enum
{
    public enum CommandContextEnum
    {
        Login = 1,

        CurrentUserWantToDeleteAccount = 2,
        CurrentUserWantToDeleteHisPost = 3,
        CurrentUserWantToDeleteHisComment = 4,
        CurrentUserWantToDeleteHisMindset = 5,
        ReadMe = 6,

        CurrentUserWantToUpdateAccount = 7,
        CurrentUserWantToUpdatePost = 8,
        CurrentUserWantToUpdateComment = 9,
        CurrentUserWantToUpdateMindset = 10,

        CreateUser = 11,
        CreatePost = 12,
        CreateComment = 13,
        CreateMindset = 14,
        
        ReadUser = 15,
        ReadPost = 16,
        ReadComment = 17,
        ReadCommentById = 18,
        ReadMindset = 19,

        LikePost = 20,
        LikeMindset = 21,

        CommandNotFound = 22,
    }
}
