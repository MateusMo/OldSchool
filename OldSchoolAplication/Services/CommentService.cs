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
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public async Task<CommentDomain> AddAsync(CommentDomain entity)
        {
            return await _commentRepository.AddAsync(entity);
        }
        public async Task DeleteAsync(int id)
        {
            await _commentRepository.DeleteAsync(id);
        }
        public Task<IEnumerable<CommentDomain>> FindAsync(Expression<Func<CommentDomain, bool>> predicate)
        {
            return _commentRepository.FindAsync(predicate);
        }
        public Task<IEnumerable<CommentDomain>> GetAllAsync()
        {
            return _commentRepository.GetAllAsync();
        }
        public Task<CommentDomain> GetByIdAsync(int id)
        {
            return _commentRepository.GetByIdAsync(id);
        }
        public async Task UpdateAsync(CommentDomain entity)
        {
            await _commentRepository.UpdateAsync(entity);
        }
    }
}
