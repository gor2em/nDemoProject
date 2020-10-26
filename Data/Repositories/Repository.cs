using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _context;
        public readonly DbSet<T> _dbset;
        public Repository(Demo2DbContext demo2DbContext)
        {
            _context = demo2DbContext;
            _dbset = demo2DbContext.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
             await _dbset.AddAsync(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }

        public void Remove(T entity)
        {
            _dbset.Remove(entity);
        }

        public T Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbset.FindAsync(id);
        }
    }
}
