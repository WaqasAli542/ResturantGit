
using Resturant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Resturant.DAL.Classes
{
    public class DALFoodItem_AddOn 
    {

        ResturantDatabase database = null;

        

        public bool addFoodItem_AddOns(FoodItem_AddOn _foodItem_AddOns)
        {
            database.FoodItem_AddOn.Add(_foodItem_AddOns);
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool updateFoodItem_AddOns(FoodItem_AddOn _foodItem_AddOns)
        {
            database.Entry(_foodItem_AddOns).State = System.Data.EntityState.Modified;
            return database.SaveChanges() != -1 ? true : false;
        }

        public bool deleteFoodItem_AddOns(FoodItem_AddOn _foodItem_AddOns)
        {
            database.Entry(_foodItem_AddOns).State = System.Data.EntityState.Modified;
            return database.SaveChanges() != -1 ? true : false;
        }

        public FoodItem_AddOn getFoodItem_AddOnsById(int _id)
        {
            return database.FoodItem_AddOn.FirstOrDefault(FoodItem_AddOn => FoodItem_AddOn.Id == _id);
        }

        public List<FoodItem_AddOn> getListOfFoodItem_AddOns()
        {
            return database.FoodItem_AddOn.ToList();
        }
    }
}