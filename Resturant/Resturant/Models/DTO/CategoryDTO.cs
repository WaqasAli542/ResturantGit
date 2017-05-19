using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Resturant.Models.DTO
{
    public class CategoryDTO
    {
           public CategoryDTO(Category category)
        {

            this.CousineId = category.CousineId;
            this.Name = category.Name;
            this.Id = category.Id;
         
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int CousineId { get; set; }
    
    
    
        public virtual Cousine Cousine { get; set; }
        public virtual ICollection<Discount> Discounts { get; set; }
        public virtual ICollection<SpecialOffer_Item> SpecialOffer_Item { get; set; }
        public virtual ICollection<FoodDTO> Foods { get; set; }
    }
}