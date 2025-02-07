using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TourismReserve.Core.Models.Commons;
using TourismReserve.Core.Repositories;
using TourismRserve.DAL.Context;

namespace TourismRserve.DAL.Repositories
{
    public class GenericRepository<T>(TourismDbContext _context) : IGenericRepository<T> where T : BaseEntity, new()
    {
        protected DbSet<T> Table= _context.Set <T>();
        public async Task AddAsync(T entity)
        => await Table.AddAsync(entity);
        

        public  void Delete(T entity)
        => Table.Remove(entity);
        

        public async Task DeleteAsync(int id)
        => await Table.Where(x=> x.Id==id).ExecuteDeleteAsync();

        public IQueryable<T> GetAll()
        =>Table.AsQueryable();

        public async Task<T?> GetByIdAsync(int id)
        => await Table.FindAsync(id);

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression)
        => Table.Where(expression).AsQueryable();

        public Task<bool> IsExistAsync(int id)
        => Table.AnyAsync(x=>x.Id==id);

        public async Task<bool> IsExistAsync(Expression<Func<T, bool>> expression)
        => await Table.AnyAsync(expression);

        public async Task<int> SaveAsync()
        => await _context.SaveChangesAsync();

        public  void Update(T entity)
        =>  Table.Update(entity);
        
    }
}
