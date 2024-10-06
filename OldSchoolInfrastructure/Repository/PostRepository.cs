using Microsoft.EntityFrameworkCore;
using OldSchoolDomain.Domain;
using OldSchoolInfrastructure.Data;
using System.Threading.Tasks;

namespace OldSchoolInfrastructure.Repository
{
    public class PostRepository : GenericRepository<PostDomain>, IPostRepository
    {
        public PostRepository(OldSchoolContext context) : base(context)
        {
        }
    }
}
