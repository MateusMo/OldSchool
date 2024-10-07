using OldSchoolDomain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OldSchoolAplication.Services
{
    public class CommentService : ICommentService
    {
        public Task<CommentDomain> AddAsync(CommentDomain entity)
        {
            throw new NotImplementedException();
        }
        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<CommentDomain>> FindAsync(Expression<Func<CommentDomain, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<CommentDomain>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        public Task<CommentDomain> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task UpdateAsync(CommentDomain entity)
        {
            throw new NotImplementedException();
        }
    }
}
