using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U02B40_HFT_2021221.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.EntityFrameworkCore;

    public abstract class RepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
        
    {
       
        protected DbContext DbContext;

   
        protected RepositoryBase(DbContext dbContext)
        {
            this.DbContext = dbContext;
        }

       
        public TEntity Create(TEntity entity)
        {
            var result = DbContext.Add(entity);
            this.DbContext.SaveChanges();
            return result.Entity;
        }

        public TEntity Update(TEntity entity)
        {
            var result = DbContext.Update(entity);
            this.DbContext.SaveChanges();
            return result.Entity;
        }

       
        public void Delete(TKey id)
        {
            this.DbContext.Remove(Read(id));
            this.DbContext.SaveChanges();
        }



     
        public IQueryable<TEntity> ReadAll()
        {
            return this.DbContext.Set<TEntity>();
        }

    
        public abstract TEntity Read(TKey id);


        
    }
}

