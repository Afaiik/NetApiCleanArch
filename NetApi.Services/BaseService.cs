using FluentValidation;
using NetApi.Core.Interfaces.Repositories;
using NetApi.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NetApi.Services
{
    public class BaseService<TEntity/*, TValidator*/> : IBaseService<TEntity> where TEntity : class /*where TValidator : AbstractValidator<TEntity>, new()*/
    {
        private readonly IBaseRepository<TEntity> _tRepository;
        public BaseService(IBaseRepository<TEntity> tRepository)
        {
            _tRepository = tRepository;
        }

        public async Task AddAsync(TEntity entity)
        {
            //TValidator validator = new TValidator();
            //var validationResult = validator.Validate(entity);
            await _tRepository.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _tRepository.AddRangeAsync(entities);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _tRepository.GetAllAsync();
        }

        public Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, 
                                                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, 
                                                    string includeProperties = "")
        {
            return _tRepository.GetAsync(filter, orderBy, includeProperties);
        }

        public async ValueTask<TEntity> GetByIdAsync(int id)
        {
            return await _tRepository.GetByIdAsync(id);
        }

        public void Remove(TEntity entity)
        {
            _tRepository.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _tRepository.RemoveRange(entities);
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _tRepository.SingleOrDefaultAsync(predicate);
        }

        public async Task Update(int id, TEntity entityToUpdate)
        {
            await _tRepository.Update(entityToUpdate);
        }

        public async Task UpdateRange(IEnumerable<TEntity> entitiesToUpdate)
        {
            await _tRepository.UpdateRange(entitiesToUpdate);
        }
    }
}
