//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Resturant.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SpecialOffer_AddOn
    {
        public SpecialOffer_AddOn()
        {
            this.Order_SpecialOffer_AddOn = new HashSet<Order_SpecialOffer_AddOn>();
        }
    
        public int Id { get; set; }
        public int SpecialOfferID { get; set; }
        public int AddonID { get; set; }
        public int Quantity { get; set; }
    
        public virtual AddOn AddOn { get; set; }
        public virtual ICollection<Order_SpecialOffer_AddOn> Order_SpecialOffer_AddOn { get; set; }
        public virtual SpecialOffer SpecialOffer { get; set; }
    }
}
