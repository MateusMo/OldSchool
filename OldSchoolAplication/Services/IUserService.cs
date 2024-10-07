using OldSchoolAplication.Dto;
using OldSchoolDomain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OldSchoolAplication.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDomain>> GetAllAsync();
        Task<UserDomain> GetByIdAsync(int id);
        Task<UserDomain> AddAsync(UserDomain entity);
        Task UpdateAsync(UserDomain entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<UserDomain>> FindAsync(Expression<Func<UserDomain, bool>> predicate);
    }
}
