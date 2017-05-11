using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Resturant.Models.DTO
{
    public class FoodDTO
    {        public FoodDTO(Food food)
        {

            this.Id = food.Id;
            this.Name = food.Name;
            this.Tageline = food.Name;
            this.Image = food.Name;
            this.CategoryId = food.CategoryId;
        }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Tageline { get; set; }
    public string Image { get; set; }
    public int CategoryId { get; set; }

    public virtual Category Category { get; set; }
    public virtual ICollection<Food_AddOn> Food_AddOn { get; set; }
    public virtual ICollection<Food_Ingredients> Food_Ingredients { get; set; }
    public virtual ICollection<FoodItemDTO> FoodItems { get; set; }
    }
}