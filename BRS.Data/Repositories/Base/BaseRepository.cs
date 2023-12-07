using BRS.Core.Entity;
using BRS.Core.Entity.Base;
using BRS.Core.Exception;
using BRS.Core.Interfaces.Repositories.Base;
using Inventory.Data.InventoryContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BRS.Business.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        private readonly BRSDbContext context;
        private DbSet<T> entities;

        public BaseRepository(BRSDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public void Add(T entity)
        {
            entity.CreateDate = DateTime.Now;
            context.Add(entity);
        }

        public async Task AddAsync(T entity)
        {
            entity.CreateDate = DateTime.Now;
            await context.AddAsync(entity);
        }

        public async Task AddAsyncRange(List<T> entites)
        {
            await context.AddRangeAsync(entities);
        }

        public void AddRange(List<T> entities)
        {
            context.AddRange(entities);
        }

        public IQueryable<T> All()
        {
            return entities.Where(x => !x.IsDelete).OrderBy(o => o.CreateDate);
        }

        public IQueryable<T> All(Expression<Func<T, bool>> where)
        {
            IQueryable<T> queryable = entities.Where(where).AsQueryable().OrderBy(o => o.CreateDate); 

            return queryable.AsQueryable();
        }

        public T Find(Guid id)
        {
            return All(x => x.Id.Equals(id) && !x.IsDelete).FirstOrDefault();
        }

        public async Task<T> FindAsync(Guid id)
        {
            return await entities.FirstOrDefaultAsync(x => x.Id.Equals(id) && !x.IsDelete);
        }

        public void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.UpdateDate = DateTime.Now;
            context.Update(entity);
        }

        public void UpdateRange(List<T> entites)
        {
            context.UpdateRange(entities);
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Remove(entity);
        }

        public Task DeleteAsyncRange(List<T> entites)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(List<T> entites)
        {
            if (entites == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.RemoveRange(entites);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Reload(T entity)
        {
            context.Entry(entity).Reload();
        }
    }
}
