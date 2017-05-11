using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Resturant.Models.DTO
{
    public class FoodItemDTO
    {   public FoodItemDTO(FoodItem fi)
        {
            this.Id = fi.Id;
            this.Size = fi.Size;
            this.Price = fi.Price;
            this.FoodId = fi.FoodId;
        }

    public int Id { get; set; }
    public string Size { get; set; }
    public double Price { get; set; }
    public int FoodId { get; set; }
    public Nullable<int> Food_Size_Id { get; set; }

    public virtual Food Food { get; set; }
    public virtual Food_Size Food_Size { get; set; }
    public virtual ICollection<Order_Item> Order_Item { get; set; }
    public virtual ICollection<FoodItem_AddOn> FoodItem_AddOn { get; set; }
    }
}