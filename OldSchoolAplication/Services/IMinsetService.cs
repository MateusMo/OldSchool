using OldSchoolDomain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OldSchoolAplication.Services
{
    public interface IMinsetService
    {
        Task<IEnumerable<MindsetDomain>> GetAllAsync();
        Task<MindsetDomain> GetByIdAsync(int id);
        Task<MindsetDomain> AddAsync(MindsetDomain entity);
        Task UpdateAsync(MindsetDomain entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<MindsetDomain>> FindAsync(Expression<Func<MindsetDomain, bool>> predicate);
    }
}
