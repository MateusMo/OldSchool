using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldSchoolAplication.Enum
{
    public enum CommandContextEnum
    {
        CurrentUserWantToDeleteAccount = 1,
        CurrentUserWantToDeleteHisPost = 2,
        CurrentUserWantToDeleteHisComment = 3,

        CurrentUserWantToUpdateAccount = 4,
        CurrentUserWantToUpdatePost = 5,
        CurrentUserWantToUpdateComment = 6,

        CreateUser = 7,
        CreatePost = 8,
        CreateComment = 9,
        
        ReadUser = 10,
        ReadPost = 11,
        ReadComment = 12,

        LikePost = 13,

        CommandNotFound = 14,
    }
}
