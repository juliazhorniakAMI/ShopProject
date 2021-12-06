using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CursovaApp.DAL.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CursovaApp.DAL.Repositories
{
    public class GenericKeyRepository<TKey, TEntity, TContext> : IGenericKeyRepository<TKey, TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        protected readonly TContext Context;

        public GenericKeyRepository(TContext context)
        {
            Context = context;
        }

      
        public bool Add(TEntity entity)
        {
            var item =  Context.Set<TEntity>().Add(entity);
             Context.SaveChanges();
            return true;
        }

        public bool Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
             Context.SaveChanges();
            return true;
        }

        public bool Delete(TEntity entity)
        {
            var result = Context.Set<TEntity>().Remove(entity).Entity;
             Context.SaveChanges();

            return true;
        }

        public TEntity GetById(TKey id)
        {
            return  Context.Set<TEntity>()
                .Find(id);
        }
    }
}
