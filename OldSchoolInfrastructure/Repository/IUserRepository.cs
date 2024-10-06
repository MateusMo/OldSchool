using System.Collections.Generic;
using System.Threading.Tasks;
using OldSchoolDomain.Domain;

namespace OldSchoolInfrastructure.Repository
{
    public interface IUserRepository : IGenericRepository<UserDomain>
    {
    }
}
