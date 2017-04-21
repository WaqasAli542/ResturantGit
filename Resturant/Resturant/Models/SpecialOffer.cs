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
    
    public partial class SpecialOffer
    {
        public SpecialOffer()
        {
            this.Order_SpecialOffer = new HashSet<Order_SpecialOffer>();
            this.Order_SpecialOffer_Item = new HashSet<Order_SpecialOffer_Item>();
            this.SpecialOffer_AddOn = new HashSet<SpecialOffer_AddOn>();
            this.SpecialOffer_Item = new HashSet<SpecialOffer_Item>();
        }
    
        public int Id { get; set; }
        public Nullable<System.DateTime> StartingDate { get; set; }
        public Nullable<System.DateTime> EndingDate { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public Nullable<System.TimeSpan> StartingTime { get; set; }
        public Nullable<System.TimeSpan> EndingTime { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Order_SpecialOffer> Order_SpecialOffer { get; set; }
        public virtual ICollection<Order_SpecialOffer_Item> Order_SpecialOffer_Item { get; set; }
        public virtual ICollection<SpecialOffer_AddOn> SpecialOffer_AddOn { get; set; }
        public virtual ICollection<SpecialOffer_Item> SpecialOffer_Item { get; set; }
    }
}