using Assignment1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Linq.Expressions;

namespace Assignment1.Repository
{
    public class EfCoreRepository<T> : IRepository<T> where T : BaseEntity
    {

        #region Fields

        protected ApplicationDbContext Context;

        #endregion

        public EfCoreRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        #region Public Methods

        public async Task<T> GetById(int id)
        {
            return await Context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate)
            => Context.Set<T>().FirstOrDefaultAsync(predicate);

        public async Task<int> Add(T entity)
        {
            await Context.Set<T>().AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity.Id;
        }

        public Task Update(T entity)
        {
            // In case AsNoTracking is used
            Context.Entry(entity).State = EntityState.Modified;
            return Context.SaveChangesAsync();
        }

        public Task Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
            return Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().Where(predicate).ToListAsync();
        }

        public Task<int> CountAll() => Context.Set<T>().CountAsync();

        public Task<int> CountWhere(Expression<Func<T, bool>> predicate)
            => Context.Set<T>().CountAsync(predicate);

        #endregion

    }
}
