﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TourismReserve.Core.Models.Commons;

namespace TourismReserve.Core.Repositories
{
    public interface IGenericRepository<T> where T :BaseEntity , new()
    {
        Task<IEnumerable<U>> GetAllAsync<U>(Expression<Func<T, U>> select);
        Task<T?> GetByIdAsync(int id);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task DeleteAsync(int id);
        Task<int> SaveAsync();
        Task<bool> IsExistAsync(int id);
        Task<bool> IsExistAsync(Expression<Func<T, bool>> expression);
    }
}
