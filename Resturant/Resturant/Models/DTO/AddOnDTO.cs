using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Resturant.Models.DTO
{
    public class AddOnDTO
    {
        public AddOnDTO(Resturant.Models.AddOn addon)
        {
            this.Id = addon.Id;
            this.Name = addon.Name;
            this.Price = addon.Price;
            this.Category = addon.Category;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Category { get; set; }

        public virtual ICollection<Food_AddOn> Food_AddOn { get; set; }
        public virtual ICollection<OrderItem_AddOn> OrderItem_AddOn { get; set; }
        public virtual ICollection<SpecialOffer_AddOn> SpecialOffer_AddOn { get; set; }
        public virtual ICollection<FoodItem_AddOn> FoodItem_AddOn { get; set; }
    }
}