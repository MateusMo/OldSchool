using OldSchoolDomain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldSchoolAplication.Jwt
{
    public interface IGetToken
    {
        public Task<string> GenerateToken(UserDomain user);
    }
}
