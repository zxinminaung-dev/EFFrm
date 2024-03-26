using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFFrm.Common
{
    public class RepositoryBase<TEntity> : IDisposable , IRepositoryBase<TEntity> where TEntity : class, new() 
    {
        private readonly DatabaseContext _dbContext;
        private bool _disposed = false;
        public RepositoryBase(DatabaseContext dbContext) 
        {
            this._dbContext = dbContext;
        }
        public void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.Entry(entity).State = EntityState.Deleted;
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }
        public TEntity Get(int id)
        {
            return _dbContext.Set<TEntity>().Where(x=>x.Equals(id)).FirstOrDefault();
        }

        public List<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public int Save(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.Entry(entity).State = EntityState.Added;
            _dbContext.SaveChanges();
            return (int)entity.GetType().GetProperty("id").GetValue(entity);
        }

        public int Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return (int)entity.GetType().GetProperty("id").GetValue(entity);
        }
    }
}
