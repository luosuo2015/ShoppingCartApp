using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ShoppingCart.Components.DataAccess;
using ShoppingCart.Components.Entities;

namespace ShoppingCart.Components.Business
{
    public class ItemDetailsProvider
    {
        private ItemDetailsDataAccess _da;
        public ItemDetailsProvider(){
            _da = new ItemDetailsDataAccess();
        }
        public List<ItemDetail> GetAll()
        {
            return _da.GetAll();
        }

        public ItemDetail Add(ItemDetail entity)
        {
            ItemDetail result = null;
            var item = _da.Get(entity.Item_Name);
            if (item != null)
            {
                throw new ArgumentOutOfRangeException("This Item Name '", entity.Item_Name, "' has existed. please change another item Name");
            }
            else
            {
               result = _da.Add(entity);
            }
            return result;
        }

        public ItemDetail Get(int entityId)
        {
            return _da.Get(entityId);
        }
        public ItemDetail Get(string ItemName)
        {
            return _da.Get(ItemName);
        }

        public ItemDetail Update(ItemDetail entity)
        {
            return _da.Update(entity);
        }
    }
}
