using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSupplier.Repositories
{
    public interface IRepository<T>
    {
        int Add(T entity);
        IList<T> Get();
        T GetBy(int id);
        int GetCount();
    }
}
