using Resturant.DAL.Classes;
using Resturant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Resturant.BAL
{
    public class BLFood
    {

        #region Food
        public bool addFood(Food _food)
        {
            return new DALFood().addFood(_food);
        }
         public bool updateFood(Food _food)
         {
             return new DALFood().updateFood(_food);
         }

         public bool deleteFood(int _id)
         {
             return new DALFood().deleteFood(_id);
         }

         public Food getFoodById(int _id)
         {
             return new DALFood().getFoodById(_id);
         }
         public List<Food> getListOfFood()
         {
             return new DALFood().getListOfFood();
         }
         public List<Food> getListOfFoodByCategoryId(int _Id)
         {
             return new DALFood().getListOfFoodByCategoryId(_Id);
         }
        #endregion
        
        #region FoodItem
         public bool addFoodItem(FoodItem _FoodItem)
         {
             return new DALFood().addFoodItem(_FoodItem);
         }
         public bool updateFoodItem(FoodItem _FoodItem)
         {
             return new DALFood().updateFoodItem(_FoodItem);
         }

         public bool deleteFoodItem(int _Id)
         {
             return new DALFood().deleteFoodItem(_Id);
         }
        
         public FoodItem getFoodItemById(int _id)
         {
             return new DALFood().getFoodItemById(_id);
         }
         public List<FoodItem> getListOfFoodItem()
         {
             return new DALFood().getListOfFoodItem();
         }
         public List<FoodItem> getListOfFoodItemByFoodId(int _FoodId)
         {
             return new DALFood().getListOfFoodItemByFoodId(_FoodId);
         }
     #endregion
        
        #region Cousine

         public bool addCousine(Cousine _Cousine)
         {
             return new DALFood().addCousine(_Cousine);
         }
         public bool updateCousine(Cousine _Cousine)
         {
             return new DALFood().updateCousine(_Cousine);
         }

         public bool deleteCousine(int _id)
         {
             return new DALFood().deleteCousine(_id);
         }

         public Cousine getCousineById(int _id)
         {
             return new DALFood().getCousineById(_id);
         }
         public List<Cousine> getListOfCousine()
         {
             return new DALFood().getListOfCousine();
         }
#endregion

        #region Category

         public bool addCategory(Category _Category)
         {
             return new DALFood().addCategory(_Category);
         }
         public bool updateCategory(Category _Category)
         {
             return new DALFood().updateCategory(_Category);
         }

         public bool deleteCategory(int _id)
         {
             return new DALFood().deleteCategory(_id);
         }

         public Category getCategoryById(int _id)
         {
             return new DALFood().getCategoryById(_id);
         }
         public List<Category> getListOfCategory()
         {
             return new DALFood().getListOfCategory();
         }
         public List<Category> getListOfCategoryByCousineId(int cousineId)
         {
             return new DALFood().getListOfCategoryByCousineId(cousineId);
         }

         #endregion

      
         #region AddOn
         public List<AddOn> getListOfAddon()
         {
             return new DALFood().getListOfAddon();
         }

        public bool addAddOn(AddOn _addOn)
         {
             return new DALFood().addAddOn(_addOn);
         }

        public bool deleteAddon(int _addOnId)
        {
            return new DALFood().deleteAddon(_addOnId);
        }

        public AddOn getAddOnById(int _id)
        {
            return new DALFood().getAddOnById(_id);
        }
        public bool UpdateAddOn(AddOn _addOn)
        {
            return new DALFood().updateAddOnItem(_addOn);
        }
         #endregion

        #region Ingredients
        public List<Ingredient> getListOfIngredients()
        {
            return new DALFood().getListOfIngredients();
        }
        //Error
        public bool addIngredient(Ingredient _IngredientOn)
        {
            return new DALFood().addIngredient(_IngredientOn);
        }

        public bool deleteIngredient(int _IngredientId)
        {
            return new DALFood().deleteIngredient(_IngredientId);
        }

        public Ingredient getIngredientById(int _id)
        {
            return new DALFood().getIngredientById(_id);
        }

        public bool UpdateIngredient(Ingredient _ingredient)
        {
            return new DALFood().UpdateIngredient(_ingredient);
        }
        #endregion

        #region Food_Ingredients
        public List<Food_Ingredients> getListOfFood_Ingredients()
        {
            return new DALFood().getListOfFood_Ingredients();
        }
        //Error
        public bool addFood_Ingredient(Food_Ingredients _Food_IngredientOn)
        {
            return new DALFood().addFood_Ingredients(_Food_IngredientOn);
        }

        public bool deleteFood_Ingredient(int _Food_IngredientId)
        {
            return new DALFood().deleteFood_Ingredients(_Food_IngredientId);
        }

        public Food_Ingredients getFood_IngredientById(int _id)
        {
            return new DALFood().getFood_IngredientsById(_id);
        }

        public bool UpdateFood_Ingredient(Food_Ingredients _Food_Ingredient)
        {
            return new DALFood().updateFood_Ingredients(_Food_Ingredient);
        }
        #endregion

        #region Food_AddOns
        public List<Food_AddOn> getListOfFood_AddOn()
        {
            return new DALFood().getListOfFood_AddOn();
        }
        //Error
        public bool addFood_AddOn(Food_AddOn _Food_AddOn)
        {
            return new DALFood().addFood_AddOn(_Food_AddOn);
        }

        public bool deleteFood_AddOn(int _Food_AddOnId)
        {
            return new DALFood().deleteFood_AddOn(_Food_AddOnId);
        }

        public Food_AddOn getFood_AddOnById(int _id)
        {
            return new DALFood().getFood_AddOnById(_id);
        }

        public bool UpdateFood_AddOn(Food_AddOn _Food_AddOn)
        {
            return new DALFood().updateFood_AddOn(_Food_AddOn);
        }
        #endregion

        #region SpecialOffers
        public List<SpecialOffer> getListOfSpecialOffers()
        {
            return new DALFood().getListOfSpecialOffer();
        }
        public SpecialOffer getSpecialOffersById(int _id)
        {
            return new DALFood().getSpecialOfferById(_id);
        }


        public bool addSpecialOffers(SpecialOffer _SpecialOffers)
        {
            return new DALFood().addSpecialOffer(_SpecialOffers);
        }

        public bool deleteSpecialOffers(int _SpecialOffersId)
        {
            return new DALFood().deleteSpecialOffer(_SpecialOffersId);
        }

        public bool UpdateSpecialOffers(SpecialOffer _SpecialOffers)
        {
            return new DALFood().updateSpecialOffer(_SpecialOffers);
        }
        #endregion

        #region SpecialOffer_AddOns
        public List<SpecialOffer_AddOn> getListOfSpecialOffer_AddOn()
        {
            return new DALFood().getListOfSpecialOffer_AddOn();
        }
        public SpecialOffer_AddOn getSpecialOffer_AddOnById(int _id)
        {
            return new DALFood().getSpecialOffer_AddOnById(_id);
        }

        public List<AddOn> getListOfCategoryOfAddon(int _categoryId)
        {
            return new DALFood().getListOfCategoryOfAddon(_categoryId);
        }

        public List<SpecialOffer_Item> getListOfSpecialOffer_Item_OfSpecificValues(int specialOfferId)
        {
            return new DALFood().getListOfSpecialOffer_Item_OfSpecificValues(specialOfferId);
        }
        public bool addSpecialOffer_AddOn(SpecialOffer_AddOn _SpecialOffer_AddOn)
        {
            return new DALFood().addSpecialOffer_AddOn(_SpecialOffer_AddOn);
        }

        public bool deleteSpecialOffer_AddOn(int _SpecialOffer_AddOnId)
        {
            return new DALFood().deleteSpecialOffer_AddOn(_SpecialOffer_AddOnId);
        } 

        public bool UpdateSpecialOffer_AddOn(SpecialOffer_AddOn _SpecialOffer_AddOn)
        {
            return new DALFood().updateSpecialOffer_AddOn(_SpecialOffer_AddOn);
        }
        #endregion

        #region SpecialOffer_Items
        public List<SpecialOffer_Item> getListOfSpecialOffer_Item()
        {
            return new DALFood().getListOfSpecialOffer_Item();
        }
        public SpecialOffer_Item getSpecialOffer_ItemById(int _id)
        {
            return new DALFood().getSpecialOffer_ItemById(_id);
        }
        public List<SpecialOffer_AddOn> getListOfSpecialOffer_AddOn_OfSpecificValues(int _specialofferId)
        {
            return new DALFood().getListOfSpecialOffer_AddOn_OfSpecificValues(_specialofferId);
        }

        public bool addSpecialOffer_Item(SpecialOffer_Item _SpecialOffer_Item)
        {
            return new DALFood().addSpecialOffer_Item(_SpecialOffer_Item);
        }

        public bool deleteSpecialOffer_Item(int _SpecialOffer_ItemId)
        {
            return new DALFood().deleteSpecialOffer_Item(_SpecialOffer_ItemId);
        }

        public bool UpdateSpecialOffer_Item(SpecialOffer_Item _SpecialOffer_Item)
        {
            return new DALFood().updateSpecialOffer_Item(_SpecialOffer_Item);
        }
        #endregion

        #region Food_Sizes
        public List<Food_Size> getListOfFood_Sizes()
        {
            return new DALFood().getListOfFood_Size();
        }
        public Food_Size getFood_SizesById(int _id)
        {
            return new DALFood().getFood_SizeById(_id);
        }


        public bool addFood_Sizes(Food_Size _Food_Sizes)
        {
            return new DALFood().addFood_Size(_Food_Sizes);
        }

        public bool deleteFood_Sizes(int _Food_SizesId)
        {
            return new DALFood().deleteFood_Size(_Food_SizesId);
        }

        public bool UpdateFood_Sizes(Food_Size _Food_Sizes)
        {
            return new DALFood().updateFood_Size(_Food_Sizes);
        }
        #endregion









       
    }
  }
