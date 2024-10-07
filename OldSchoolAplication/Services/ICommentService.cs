using OldSchoolDomain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OldSchoolAplication.Services
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentDomain>> GetAllAsync();
        Task<CommentDomain> GetByIdAsync(int id);
        Task<CommentDomain> AddAsync(CommentDomain entity);
        Task UpdateAsync(CommentDomain entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<CommentDomain>> FindAsync(Expression<Func<CommentDomain, bool>> predicate);
    }
}
