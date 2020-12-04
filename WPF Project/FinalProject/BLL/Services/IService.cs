using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IService<T>
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        T CreateOrUpdate(T entity);
        void Remove(T entity);
    }
}
