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
    
    public partial class Tax
    {
        public Tax()
        {
            this.Order_Taxes = new HashSet<Order_Taxes>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public double Percentage { get; set; }
    
        public virtual ICollection<Order_Taxes> Order_Taxes { get; set; }
    }
}
