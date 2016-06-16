using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using ShoppingCart.Components.Business;
using ShoppingCart.Components.Entities;
using System.ServiceModel.Web;

namespace ShoppingCart.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IItemDetailsWCF" in both code and config file together.
    [ServiceContract]
    public interface IItemDetailsWCF
    {
        [OperationContract]
        [WebInvoke(
            Method = "GET",
            BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/getAll"
            )]
        //[return: MessageParameter(Name="ItemDetails")]
        List<ShoppingCartDataContract.ItemDetailDataContract> getAll();

        [OperationContract]
        [WebInvoke(
            Method="POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/addItemDetail"
            )]
        bool addItem(ShoppingCartDataContract.ItemDetailDataContract item);

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/editItemDetail"
            )]
        bool editItem(ShoppingCartDataContract.ItemDetailDataContract item);
    }

 
    public class ShoppingCartDataContract
    {
       [DataContract]
        public class ItemDetailDataContract
        {
            [DataMember(Name="itemID")]
            public string Item_ID { get; set; }
            [DataMember(Name="itemName")]
            public string Item_Name { get; set; }
            [DataMember(Name="description")]
            public string Description { get; set; }
            [DataMember(Name="itemPrice")]
            public string Item_Price { get; set; }
            [DataMember(Name="imageName")]
            public string Image_Name { get; set; }
            [DataMember(Name="addedBy")]
            public string AddedBy { get; set; }
        }
    }
    
}
