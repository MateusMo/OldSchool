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
    public class MinsetService : IMinsetService
    {
        private readonly IMindsetRepository _minsetRepo;
        public MinsetService(IMindsetRepository minsetRepo)
        {
            _minsetRepo = minsetRepo;
        }
        public async Task<MindsetDomain> AddAsync(MindsetDomain entity)
        {
            return await _minsetRepo.AddAsync(entity);  
        }

        public async Task DeleteAsync(int id)
        {
            await _minsetRepo.DeleteAsync(id);
        }

        public async Task<IEnumerable<MindsetDomain>> FindAsync(Expression<Func<MindsetDomain, bool>> predicate)
        {
            return await _minsetRepo.FindAsync(predicate);
        }

        public async Task<IEnumerable<MindsetDomain>> GetAllAsync()
        {
            return await _minsetRepo.GetAllAsync();
        }

        public async Task<MindsetDomain> GetByIdAsync(int id)
        {
            return await _minsetRepo.GetByIdAsync(id);
        }

        public async Task UpdateAsync(MindsetDomain entity)
        {
           await _minsetRepo.UpdateAsync(entity);
        }
    }
}
