//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShoppingCart.Components.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class CartDetail
    {
        public int Cart_ID { get; set; }
        public Nullable<int> Item_ID { get; set; }
        public Nullable<int> qty { get; set; }
        public Nullable<System.DateTime> Added_Date { get; set; }
        public string AddedBy { get; set; }
    
        public virtual ItemDetail ItemDetail { get; set; }
    }
}
