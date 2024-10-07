using OldSchoolAplication.Dto;
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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDomain> AddAsync(UserDomain entity)
        {
            return await _userRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<UserDomain>> FindAsync(Expression<Func<UserDomain, bool>> predicate)
        {
            return await _userRepository.FindAsync(predicate);
        }

        public async Task<IEnumerable<UserDomain>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<UserDomain> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(UserDomain entity)
        {
            await _userRepository.UpdateAsync(entity);
        }
    }
}
