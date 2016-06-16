using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using ShoppingCart.Components.Business;
using ShoppingCart.Components.DataAccess;
using ShoppingCart.Components.Entities;

namespace ShoppingCart.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ItemDetailsWCF" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ItemDetailsWCF.svc or ItemDetailsWCF.svc.cs at the Solution Explorer and start debugging.
    public class ItemDetailsWCF : IItemDetailsWCF
    {

        private ItemDetailsProvider _provider;

        public ItemDetailsWCF()
        {
            _provider = new ItemDetailsProvider();
        }
        public List<ShoppingCartDataContract.ItemDetailDataContract> getAll()
        {
            List<ShoppingCartDataContract.ItemDetailDataContract> ItemDetailList = new List<ShoppingCartDataContract.ItemDetailDataContract>();
            _provider.GetAll().ForEach(rec =>
            {
                ItemDetailList.Add(new ShoppingCartDataContract.ItemDetailDataContract
                {
                    Item_ID = Convert.ToString(rec.Item_ID),
                    Item_Name = rec.Item_Name,
                    Description = rec.Description,
                    Item_Price = Convert.ToString(rec.Item_price),
                    Image_Name = rec.Image_Name,
                    AddedBy = rec.AddedBy
                });
            }
                );
            return ItemDetailList;
        }

        public bool addItem(ShoppingCartDataContract.ItemDetailDataContract item)
        {
            ItemDetail result = new ItemDetail();
            try 
            {
                ItemDetail itm = new ItemDetail();
                itm.Item_Name = item.Item_Name;
                itm.Description = item.Description;
                itm.Image_Name = item.Image_Name;
                itm.Item_price = Convert.ToDecimal(item.Item_Price);
                itm.AddedBy = item.AddedBy;
               result = _provider.Add(itm); 
            }  catch( Exception ex)
            {
                throw new Exception(ex.Message);
            }
            if (result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public bool editItem(ShoppingCartDataContract.ItemDetailDataContract item)
        {
            ItemDetail result = new ItemDetail();
            try
            {
                ItemDetail editeditem = new ItemDetail();
                editeditem.Item_ID = Convert.ToInt32(item.Item_ID);
                editeditem.Item_Name = item.Item_Name;
                editeditem.Description = item.Description;
                editeditem.Item_price = Convert.ToDecimal(item.Item_Price);
                editeditem.Image_Name = item.Image_Name;
                editeditem.AddedBy = item.AddedBy;
                result = _provider.Update(editeditem);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            if (result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
