﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace CompanyApi.Persistence.Data.Abstraction
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        internal DbContext _context;
        public GenericRepository(DbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entity)
        {
            _context.Set<T>().AddRange(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entity)
        {
            _context.Set<T>().RemoveRange(entity);
        }

        public void Detach(T entity)
        {
            _context.Entry(entity).State = EntityState.Detached;
           
        }
        
        public void Edit(T entity)
        {
           
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void EditRange(IEnumerable<T> entity)
        {
            _context.Set<T>().UpdateRange(entity);
        }
        public IQueryable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _context.Set<T>().Where(predicate);
            return query;
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            IQueryable<T> query = _context.Set<T>();
            return query;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
          return await _context.SaveChangesAsync();
        }
    }
}
