using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CursovaApp.DAL.IRepositories
{
    public interface IGenericKeyRepository<in TKey, TEntity>
    {
        bool Add(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(TEntity entity);
        TEntity GetById(TKey id);
    
    }
}
