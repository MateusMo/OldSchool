using Microsoft.EntityFrameworkCore;
using OldSchoolDomain.Domain;
using OldSchoolInfrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OldSchoolInfrastructure.Repository
{
    public class CommentRepository : GenericRepository<CommentDomain>, ICommentRepository
    {
        public CommentRepository(OldSchoolContext context) : base(context)
        {
        }
    }
}
