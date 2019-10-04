using AgendaITIX.Models;
using System.Collections.Generic;

namespace AgendaITIX.Repositories
{
    public interface IRepository<T> where T : BaseModel
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
    }
}