using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ShoppingCart.Components.Entities;
using System.Data.Entity.Infrastructure;

namespace ShoppingCart.Components.DataAccess
{
    public class CartDetailsDataAccess : BaseDataAccess, IEntityDataService<CartDetail>
    {
        public List<CartDetail> GetAll()
        {
            var cartDetails = from l in base.Ctx.CartDetails
                                  select l;
            return cartDetails.ToList();
        }

        public CartDetail Get(int entityId)
        {
            throw new NotImplementedException();
        }

        public CartDetail Update(CartDetail entity)
        {
            throw new NotImplementedException();
        }

        public CartDetail Add(CartDetail entity)
        {
            CartDetail result = new CartDetail();
            try
            {
                ValidateNull<CartDetail>(entity);
                entity.Cart_ID = 0;
                base.Ctx.CartDetails.Add(entity);
                base.Ctx.SaveChanges();
                 result = (from l in base.Ctx.CartDetails
                             where l.Item_ID == entity.Item_ID
                                  select l).FirstOrDefault<CartDetail>();
            }
            catch (DbUpdateException e)
            {
                throw new DbUpdateException(e.Message);
            }
            return result;
        }

        public void Delete(CartDetail entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int entityId)
        {
            throw new NotImplementedException();
        }
    }
}
