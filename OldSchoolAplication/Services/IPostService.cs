using OldSchoolDomain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OldSchoolAplication.Services
{
    public interface IPostService
    {
        Task<IEnumerable<PostDomain>> GetAllAsync();
        Task<PostDomain> GetByIdAsync(int id);
        Task<PostDomain> AddAsync(PostDomain entity);
        Task UpdateAsync(PostDomain entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<PostDomain>> FindAsync(Expression<Func<PostDomain, bool>> predicate);
    }
}
