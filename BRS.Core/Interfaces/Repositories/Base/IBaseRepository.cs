﻿using BRS.Core.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BRS.Core.Interfaces.Repositories.Base
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        IQueryable<T> All();
        IQueryable<T> All(Expression<Func<T, bool>> where);
        T Find(Guid id);
        Task<T> FindAsync(Guid id);
        void Add(T entity);
        Task AddAsync(T entity);
        void AddRange(List<T> entities);
        Task AddAsyncRange(List<T> entites);
        void Delete(T entity);      
        void DeleteRange(List<T> entites);
        Task DeleteAsyncRange(List<T> entites);
        void Update(T entity);
        void UpdateRange(List<T> entites);
        void SaveChanges();
        Task SaveChangesAsync();
        void Reload(T entity);

    }
}
