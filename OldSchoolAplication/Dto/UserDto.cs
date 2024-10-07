using OldSchoolDomain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldSchoolAplication.Dto
{
    public class UserDto
    {
        public static UserDomain CommandAddToDomain(string[] command)
        {
            return new UserDomain()
            {
                LastLogin = DateTime.Now,
                Nickname = command[3],
                PasswordHash = command[5]
            };
        }
        public static int[] CommandReadToDomain(string[] command)
        {
            return command.Skip(4).Select(int.Parse).ToArray();
        }
        public static UserDomain CommandUpdateToDomain(UserDomain user, string[] command)
        {
            user.PasswordHash = command[6];
            user.Nickname = command[4];
            return user;
        }
    }
}
