using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Resturant.Models.DTO
{
    public class SpecialOffer_ItemDTO
    {
        public SpecialOffer_ItemDTO(SpecialOffer_Item soi)
        {
            this.Id = soi.Id;
            this.SizeId = soi.SizeId;
            this.SpecialOfferID = soi.SpecialOfferID;
            this.CategoryId = soi.CategoryId;
            this.Quantity = soi.Quantity;
            this.isFlexible = soi.isFlexible;
        }
        public int Id { get; set; }
        public int SpecialOfferID { get; set; }
        public int CategoryId { get; set; }
        public int SizeId { get; set; }
        public int Quantity { get; set; }
        public int isFlexible { get; set; }

        public virtual CategoryDTO Category { get; set; }
        public virtual Food_Size Food_Size { get; set; }
        public virtual SpecialOffer SpecialOffer { get; set; }
    }
}