using OldSchoolDomain.Domain;
using OldSchoolInfrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldSchoolInfrastructure.Repository
{
    public class UserRepository : GenericRepository<UserDomain>, IUserRepository
    {
        public UserRepository(OldSchoolContext context) : base(context)
        {
        }
    }
}
