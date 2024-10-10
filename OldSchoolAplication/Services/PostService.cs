using OldSchoolDomain.Domain;
using OldSchoolInfrastructure.Repository;
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
        private readonly IPostRepository _postRepository;
        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task<PostDomain> AddAsync(PostDomain entity)
        {
            return await _postRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _postRepository.DeleteAsync(id);
        }

        public Task<IEnumerable<PostDomain>> FindAsync(Expression<Func<PostDomain, bool>> predicate)
        {
            return _postRepository.FindAsync(predicate);
        }

        public Task<IEnumerable<PostDomain>> GetAllAsync()
        {
            return _postRepository.GetAllAsync();
        }

        public Task<PostDomain> GetByIdAsync(int id)
        {
            return _postRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(PostDomain entity)
        {
            await _postRepository.UpdateAsync(entity);
        }
    }
}
