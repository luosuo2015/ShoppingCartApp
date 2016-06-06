using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using System.Data.Entity.Infrastructure;

using ShoppingCart.Components.Entities;

namespace ShoppingCart.Components.DataAccess
{
    public class ItemDetailsDataAccess : BaseDataAccess, IEntityDataService<ItemDetail>
    {
        public ItemDetailsDataAccess() : base() { }
        public List<ItemDetail> GetAll()
        {
            var itemDetails = from l in base.Ctx.ItemDetails
                                  select l;
            return itemDetails.ToList<ItemDetail>();
        }

        public ItemDetail Get(int entityId)
        {
            ValidateEntityId(entityId);
            ItemDetail item = null;
            try
            {
                item = (from l in base.Ctx.ItemDetails
                        where l.Item_ID == entityId
                        select l).First<ItemDetail>();
            } catch(InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
            return item;
        }

        public ItemDetail Get(string ItemName)
        {
            ItemDetail item = null;
            item = (from l in base.Ctx.ItemDetails
                    where l.Item_Name == ItemName
                    select l).FirstOrDefault<ItemDetail>();            
            return item;
        }

        public ItemDetail Update(ItemDetail entity)
        {
            ValidateNull(entity);
            ValidateEntityId(entity.Item_ID);
            ItemDetail item = Get(entity.Item_ID);
            item.Item_Name = entity.Item_Name;
            item.Description = entity.Description;
            item.Item_price = entity.Item_price;
            item.Image_Name = entity.Image_Name;
            item.AddedBy = entity.AddedBy;
            base.Ctx.SaveChanges();
            return Get(entity.Item_ID);
        }

        public ItemDetail Add(ItemDetail entity)
        {
            ItemDetail result = new ItemDetail();
            try
            {
                ValidateNull(entity);
                entity.Item_ID = 0;
                base.Ctx.ItemDetails.Add(entity);
                base.Ctx.SaveChanges();
                result = (from l in base.Ctx.ItemDetails
                    where l.Item_Name == entity.Item_Name
                              select l).First<ItemDetail>();
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException(ex.Message);
            }
            return result;
        }

        public void Delete(ItemDetail entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int entityId)
        {
            throw new NotImplementedException();
        }
    }
}
