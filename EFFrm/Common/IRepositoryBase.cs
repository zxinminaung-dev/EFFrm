using System;
using System.Collections.Generic;
using System.Text;

namespace EFFrm.Common
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        List<TEntity> GetAll();
        int Save(TEntity entity);
        int Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
