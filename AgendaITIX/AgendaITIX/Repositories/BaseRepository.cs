using AgendaITIX.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AgendaITIX.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseModel
    {
        internal ApplicationContext context;
        internal DbSet<T> dbSet;

        public BaseRepository(ApplicationContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual T GetById(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(T obj)
        {
            dbSet.Add(obj);
        }

        public void Update(T obj)
        {
            dbSet.Attach(obj);
            context.Entry(obj).State = EntityState.Modified;
        }

        public virtual void Delete(object id)
        {
            T entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }
    }
}
