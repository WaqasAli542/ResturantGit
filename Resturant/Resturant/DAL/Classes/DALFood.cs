
using Resturant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Resturant.DAL.Classes
{
    public class DALFood 
    {
         ResturantDatabase database = null;

        public DALFood()
        {
            database = new ResturantDatabase();
        }
        #region Food
        public bool addFood(Food _food)
        {
            database.Foods.Add(_food);
            return database.SaveChanges() != -1? true : false;
        }

        public bool updateFood(Food _food)
        {
            database.Entry(_food).State = System.Data.EntityState.Modified;
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool deleteFood(int _id)
        {
            Food food = getFoodById(_id);
            if(food != null)
            database.Foods.Remove(food);
            return database.SaveChanges() != -1 ? true : false;
        }

        public Food getFoodById(int _id)
        {
            return database.Foods.FirstOrDefault(Food => Food.Id == _id);
        }

        public List<Food> getListOfFood()
        {
            return database.Foods.ToList();
        }
        public List<Food> getListOfFoodByCategoryId(int _Id)
        {
            return database.Foods.Where(food => food.CategoryId == _Id).ToList();
        }
        #endregion

        #region FoodItem
        public bool addFoodItem(FoodItem FoodItem)
        {
            database.FoodItems.Add(FoodItem);
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool updateFoodItem(FoodItem FoodItem)
        {
            database.Entry(FoodItem).State = System.Data.EntityState.Modified;
            return database.SaveChanges() != -1 ? true : false;
        }
        public bool deleteFoodItem(int _Id)
        {
            FoodItem foodItem = getFoodItemById(_Id);
            database.FoodItems.Remove(foodItem);
            return database.SaveChanges() != -1 ? true : false;
        }

        public FoodItem getFoodItemById(int id)
        {
            return database.FoodItems.FirstOrDefault(FoodItem => FoodItem.Id == id);
        }

        public List<FoodItem> getListOfFoodItem()
        {
            return database.FoodItems.ToList();
        }
       
        public List<FoodItem> getListOfFoodItemByFoodId(int _FoodId)
        {
            return database.FoodItems.Where(foodItem => foodItem.FoodId == _FoodId).ToList();
        }
        #endregion

        #region Cousine
        public bool addCousine(Cousine _cousine)
        {
            database.Cousines.Add(_cousine);
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool updateCousine(Cousine _cousine)
        {
            database.Entry(_cousine).State = System.Data.EntityState.Modified;
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool deleteCousine(int _id)
        {
            Cousine cousine = getCousineById(_id);
            if(cousine != null)
            database.Cousines.Remove(cousine);
            return database.SaveChanges() != -1 ? true : false;
        }

        public Cousine getCousineById(int id)
        {
            return database.Cousines.FirstOrDefault(cousine => cousine.Id == id);
        }

        public List<Cousine> getListOfCousine()
        {
            return database.Cousines.ToList();
        }
        #endregion

        #region Category
        public bool addCategory(Category _category)
        {
            database.Categories.Add(_category);
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool updateCategory(Category _category)
        {
            database.Entry(_category).State = System.Data.EntityState.Modified;
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool deleteCategory(int _id)
        {
            Category _category = getCategoryById(_id);
            if(_category != null)
            database.Categories.Remove(_category);
            return database.SaveChanges() != -1 ? true : false;
        }

        public Category getCategoryById(int _id)
        {
            return database.Categories.FirstOrDefault(Category => Category.Id == _id);
        }

        public List<Category> getListOfCategory()
        {
            return database.Categories.ToList();
        }
        public List<Category> getListOfCategoryByCousineId(int cousineId)
        {
            return database.Categories.Where(category => category.CousineId == cousineId).ToList();
        }

        #endregion

        #region AddOn
        public List<AddOn> getListOfAddon()
        {
            return database.AddOns.ToList();
        }
        public AddOn getAddOnById(int _addOnId)
        {
            return database.AddOns.FirstOrDefault(add => add.Id == _addOnId);
        }


        public bool addAddOn(AddOn _addOn)
        {
            database.AddOns.Add(_addOn);
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool deleteAddon(int _addOnId)
        {
            AddOn _addOn = getAddOnById(_addOnId);
            database.AddOns.Remove(_addOn);
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool updateAddOnItem(AddOn _addOn)
        {
            database.Entry(_addOn).State = System.Data.EntityState.Modified;
            return database.SaveChanges() != -1 ? true : false;
        }
        #endregion


        #region Ingredients
        public List<Ingredient> getListOfIngredients()
        {
            return database.Ingredients.ToList();
        }
        public bool UpdateIngredient(Ingredient _ingredients)
        {
            database.Entry(_ingredients).State = System.Data.EntityState.Modified;
            return database.SaveChanges() != -1 ? true : false;
        }

        public Ingredient getIngredientById(int _id)
        {
            return database.Ingredients.FirstOrDefault(add => add.Id == _id);
        }

        public bool deleteIngredient(int _IngredientId)
        {
            Ingredient _addOn = getIngredientById(_IngredientId);
            database.Ingredients.Remove(_addOn);
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool addIngredient(Ingredient _IngredientOn)
        {
            database.Ingredients.Add(_IngredientOn);
            return database.SaveChanges() != -1 ? true : false; 
        }
        #endregion

        #region Food_Ingredients
        public bool addFood_Ingredients(Food_Ingredients _Food_Ingredients)
        {
            database.Food_Ingredients.Add(_Food_Ingredients);
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool updateFood_Ingredients(Food_Ingredients _Food_Ingredients)
        {
            database.Entry(_Food_Ingredients).State = System.Data.EntityState.Modified;
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool deleteFood_Ingredients(int _id)
        {
            Food_Ingredients _Food_Ingredients = getFood_IngredientsById(_id);
            if (_Food_Ingredients != null)
                database.Food_Ingredients.Remove(_Food_Ingredients);
            return database.SaveChanges() != -1 ? true : false;
        }

        public Food_Ingredients getFood_IngredientsById(int _id)
        {
            return database.Food_Ingredients.FirstOrDefault(Food_Ingredients => Food_Ingredients.Id == _id);
        }

        public List<Food_Ingredients> getListOfFood_Ingredients()
        {
            return database.Food_Ingredients.ToList();
        }
     
        #endregion

        #region Food_AddOn
        public bool addFood_AddOn(Food_AddOn _Food_AddOn)
        {
            database.Food_AddOn.Add(_Food_AddOn);
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool updateFood_AddOn(Food_AddOn _Food_AddOn)
        {
            database.Entry(_Food_AddOn).State = System.Data.EntityState.Modified;
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool deleteFood_AddOn(int _id)
        {
            Food_AddOn _Food_AddOn = getFood_AddOnById(_id);
            if (_Food_AddOn != null)
                database.Food_AddOn.Remove(_Food_AddOn);
            return database.SaveChanges() != -1 ? true : false;
        }

        public Food_AddOn getFood_AddOnById(int _id)
        {
            return database.Food_AddOn.FirstOrDefault(Food_AddOn => Food_AddOn.Id == _id);
        }

        public List<Food_AddOn> getListOfFood_AddOn()
        {
            return database.Food_AddOn.ToList();
        }

        #endregion


        #region Food_Sizes
        public List<Food_Size> getListOfFood_Size()
        {
            return database.Food_Size.ToList();
        }

        public Food_Size getFood_SizeById(int _id)
        {
            return database.Food_Size.FirstOrDefault(x => x.Id == _id);
        }

        public bool addFood_Size(Food_Size _Food_Size)
        {
            database.Food_Size.Add(_Food_Size);
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool updateFood_Size(Food_Size _Food_Size)
        {
            database.Entry(_Food_Size).State = System.Data.EntityState.Modified;
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool deleteFood_Size(int _id)
        {
            Food_Size _Food_Size = getFood_SizeById(_id);
            if (_Food_Size != null)
                database.Food_Size.Remove(_Food_Size);
            return database.SaveChanges() != -1 ? true : false;
        }


      
        #endregion


        #region SpecialOffers
        public List<SpecialOffer> getListOfSpecialOffer()
        {
            return database.SpecialOffers.ToList();
        }

        public SpecialOffer getSpecialOfferById(int _id)
        {
            return database.SpecialOffers.FirstOrDefault(x => x.Id == _id);
        }

        public bool addSpecialOffer(SpecialOffer _SpecialOffer)
        {
            database.SpecialOffers.Add(_SpecialOffer);
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool updateSpecialOffer(SpecialOffer _SpecialOffer)
        {
            database.Entry(_SpecialOffer).State = System.Data.EntityState.Modified;
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool deleteSpecialOffer(int _id)
        {
            SpecialOffer _SpecialOffer = getSpecialOfferById(_id);
            if (_SpecialOffer != null)
                database.SpecialOffers.Remove(_SpecialOffer);
            return database.SaveChanges() != -1 ? true : false;
        }



        #endregion

        #region SpecialOffer_Items
        public List<SpecialOffer_Item> getListOfSpecialOffer_Item()
        {
            return database.SpecialOffer_Item.ToList();
        }

        public SpecialOffer_Item getSpecialOffer_ItemById(int _id)
        {
            return database.SpecialOffer_Item.FirstOrDefault(x => x.Id == _id);
        }

        public bool addSpecialOffer_Item(SpecialOffer_Item _SpecialOffer_Item)
        {
            database.SpecialOffer_Item.Add(_SpecialOffer_Item);
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool updateSpecialOffer_Item(SpecialOffer_Item _SpecialOffer_Item)
        {
            database.Entry(_SpecialOffer_Item).State = System.Data.EntityState.Modified;
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool deleteSpecialOffer_Item(int _id)
        {
            SpecialOffer_Item _SpecialOffer_Item = getSpecialOffer_ItemById(_id);
            if (_SpecialOffer_Item != null)
                database.SpecialOffer_Item.Remove(_SpecialOffer_Item);
            return database.SaveChanges() != -1 ? true : false;
        }
        public List<SpecialOffer_AddOn> getListOfSpecialOffer_AddOn_OfSpecificValues(int specialofferId)
        {
            return database.SpecialOffer_AddOn.Where(x => x.SpecialOfferID == specialofferId).ToList();
        }

        #endregion


        #region SpecialOffer_AddOns
        public List<SpecialOffer_AddOn> getListOfSpecialOffer_AddOn()
        {
            return database.SpecialOffer_AddOn.ToList();
        }

        public SpecialOffer_AddOn getSpecialOffer_AddOnById(int _id)
        {
            return database.SpecialOffer_AddOn.FirstOrDefault(x => x.Id == _id);
        }

        public bool addSpecialOffer_AddOn(SpecialOffer_AddOn _SpecialOffer_AddOn)
        {
            database.SpecialOffer_AddOn.Add(_SpecialOffer_AddOn);
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool updateSpecialOffer_AddOn(SpecialOffer_AddOn _SpecialOffer_AddOn)
        {
            database.Entry(_SpecialOffer_AddOn).State = System.Data.EntityState.Modified;
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool deleteSpecialOffer_AddOn(int _id)
        {
            SpecialOffer_AddOn _SpecialOffer_AddOn = getSpecialOffer_AddOnById(_id);
            if (_SpecialOffer_AddOn != null)
                database.SpecialOffer_AddOn.Remove(_SpecialOffer_AddOn);
            return database.SaveChanges() != -1 ? true : false;
        }

        public List<AddOn> getListOfCategoryOfAddon(int _categoryId)
        {
            return database.AddOns.Where(x => x.Category == _categoryId).ToList();
        }
        public List<SpecialOffer_Item> getListOfSpecialOffer_Item_OfSpecificValues(int specialofferId)
        {
            return database.SpecialOffer_Item.Where(x => x.SpecialOfferID == specialofferId).ToList();
        }

        #endregion








       
    }
 }
