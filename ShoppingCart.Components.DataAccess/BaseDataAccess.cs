using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using ShoppingCart.Components.Entities;

namespace ShoppingCart.Components.DataAccess
{
    public class BaseDataAccess
    {
        private ShoppingDBEntities _ctx;
        protected ShoppingDBEntities Ctx {
            get { return _ctx; }
            set { _ctx = value; }
        }

        public ShoppingDBEntities CreateDataContext()
        {
            var ctx = new ShoppingDBEntities();
            return ctx;
        }

        public BaseDataAccess()
        {
            _ctx = CreateDataContext();
        }

        public void ValidateEntityId(int entityId)
        {
            if (entityId < 1)
            {
                throw new ArgumentNullException ("entityID","EntityID must be greater than 0");
            }
        }
        public void ValidateNull<T>(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentException(typeof(T).ToString() + " entity"," entity should not be null.");
            }
        }
    }
}
