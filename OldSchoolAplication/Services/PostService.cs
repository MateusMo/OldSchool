using OldSchoolDomain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OldSchoolAplication.Services
{
    public class PostService : IPostService
    {
        public Task<PostDomain> AddAsync(PostDomain entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PostDomain>> FindAsync(Expression<Func<PostDomain, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PostDomain>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PostDomain> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(PostDomain entity)
        {
            throw new NotImplementedException();
        }
    }
}
