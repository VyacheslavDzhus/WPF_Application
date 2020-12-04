using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        DbContext context;
        IDbSet<T> table;
        public GenericRepository(DbContext context)
        {
            this.context = context;
            table = context.Set<T>();
        }
        public void CreateOrUpdate(T entity)
        {
            table.AddOrUpdate(entity);
        }

        public T Get(int id)
        {
            return table.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return table;
        }

        public void Remove(T entity)
        {
            table.Remove(entity);
        }
    }
}
