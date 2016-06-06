using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Components.DataAccess
{
    public interface IEntityDataService<T>
    {
        List<T> GetAll();
        T Get(int entityId);
        T Update(T entity);
        T Add(T entity);
        void Delete(T entity);
        void Delete(int entityId);
    }
}
