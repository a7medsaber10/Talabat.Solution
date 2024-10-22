using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Repositories.Contract;
using Talabat.Core.Specifications;
using Talabat.Repository.Data;

namespace Talabat.Repository.Repository.Contract
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _dbContext;

        public GenericRepository(StoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            if (typeof(T) == typeof(Product))
            {
                return (IReadOnlyList<T>)await _dbContext.Set<Product>().Include(P => P.Brand).Include(P => P.Category).ToListAsync();
            }
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            if (typeof(T) == typeof(Product))
            {
                return await _dbContext.Set<Product>().Where(P => P.Id == id).Include(P => P.Brand).Include(P => P.Category).FirstOrDefaultAsync() as T;
            }
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> specification)
        {
            return await ApplySpecifications(specification).ToListAsync();
        }

        public async Task<T> GetWithSpecAsync(ISpecification<T> specification)
        {
            return await ApplySpecifications(specification).FirstOrDefaultAsync();
        }


        public async Task<int> GetCountAsync(ISpecification<T> specification)
        {
            return await ApplySpecifications(specification).CountAsync();
        }

        private IQueryable<T> ApplySpecifications(ISpecification<T> specification)
        {
            return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>(), specification);
        }

    }
}
