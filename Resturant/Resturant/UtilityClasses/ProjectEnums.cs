using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Resturant.UtilityClasses
{
    public class ProjectEnums
    {
        public enum IdType { SpecialOffer = 1, FoodItem = 2, AddOn = 3, SpecialOfferFoodItem = 4, SpecialOfferAddOn = 5 };
        public enum AddOnCategories
        {
            Drinks = 1,
            Sauce = 2,
            Dessert = 3,
            Crust = 4,
            Topping = 5



        }

    }
}