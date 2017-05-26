using Newtonsoft.Json;
using Resturant.BAL;
using Resturant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Resturant.Controllers
{
    public class FoodAPIController : ApiController
    {

        // Cousine List
           [HttpGet]
        public List<Cousine> GetCousineList()
        {
            List<Cousine> cousines = new BLFood().getListOfCousine();
            List<Cousine> listOfCousines = new List<Cousine>();
            foreach (Cousine c in cousines)
            {
                Cousine cat = new Cousine { Id = c.Id, Name = c.Name };
                listOfCousines.Add(cat);
            }


            return listOfCousines;
        }

        //Category List
        public List<Category> GetCategoryListByCousineId(int CousineId)
        {
            List<Category> categories = new BLFood().getListOfCategoryByCousineId(CousineId);
            List<Category> listOfCategories = new List<Category>();
            foreach (Category c in categories)
            {
                Category cat = new Category { Id = c.Id, Name = c.Name };
                listOfCategories.Add(cat);
            }
            return listOfCategories;
        }
        //Food by id
    [HttpGet]
        public Food GetFoodById(int _Id)
        {
            Food f = new BLFood().getFoodById(_Id);
            if (f == null)
                return null;
            List<FoodItem> fooditems = new List<FoodItem>();
            Food food = new Food { Id = f.Id, Image = f.Image, Name = f.Name, IsAvailable = f.IsAvailable, Tageline = f.Tageline };

            foreach (FoodItem fi in f.FoodItems)
            {
                if (fi.IsAvailable == 1)
                {
                    Food_Size fs = new Food_Size { Id = fi.Food_Size.Id, SizeDescription = fi.Food_Size.SizeDescription };
                    FoodItem tempfi = new FoodItem { Id = fi.Id, Size = fi.Size, Price = fi.Price, IsAvailable = fi.IsAvailable, TagLine = fi.TagLine, Food_Size = fs };
                    fooditems.Add(tempfi);
                }
            }
            food.FoodItems = fooditems;

            List<Food_AddOn> foodaddons = new List<Food_AddOn>();
            foreach (Food_AddOn fa in f.Food_AddOn)
            {
                if (fa.AddOn.IsAvailable == 1)
                {
                    AddOn addon = new AddOn { Id = fa.AddOn.Id, Name = fa.AddOn.Name, Price = fa.AddOn.Price, IsAvailable = fa.AddOn.IsAvailable };
                    Food_Size fs = new Food_Size { Id = fa.Food_Size.Id, SizeDescription = fa.Food_Size.SizeDescription };
                    Food_AddOn faddon = new Food_AddOn { Id = fa.Id, FoodId = f.Id, AddOn = addon, Food_Size = fs };
                    foodaddons.Add(faddon);
                }
            }
            food.Food_AddOn = foodaddons;
            return food;
        }

       //http://localhost:11632/api/FoodAPI/GetFoodAddOnListByFoodId?_FoodId=57
            public List<Food_AddOn> GetFoodAddOnListByFoodId(int _FoodId)
            {
                Food f = new BLFood().getFoodById(_FoodId);
                List<Food_AddOn> foodaddons = new List<Food_AddOn>();
                foreach (Food_AddOn fa in f.Food_AddOn)
                {
                    if (fa.AddOn.IsAvailable == 1)
                    {
                        AddOn addon = new AddOn { Id = fa.AddOn.Id, Name = fa.AddOn.Name, Price = fa.AddOn.Price, IsAvailable = fa.AddOn.IsAvailable };
                        Food_Size fs = new Food_Size { Id = fa.Food_Size.Id, SizeDescription = fa.Food_Size.SizeDescription };
                        Food_AddOn faddon = new Food_AddOn { Id = fa.Id, FoodId = f.Id, AddOn = addon, Food_Size = fs };
                        foodaddons.Add(faddon);
                    }
                }
                return foodaddons;
            }
        //Food list by category id
        //http://localhost:11632/api/FoodAPI/FoodListByCategoryId?_CategoryId=18
        public List<Food> GetFoodListByCategoryId(int _CategoryId)
        {
            List <Food> flist= new BLFood().getListOfFoodByCategoryId(_CategoryId);
            if (flist == null)
                return null;
            List<Food> food = new List<Food>();
            foreach(Food f in flist)
            {
                if (f.IsAvailable == 1)
                {
                    Food tempf = new Food { Id = f.Id, Image = f.Image, Name = f.Name, IsAvailable = f.IsAvailable, Tageline = f.Tageline };
                    List<FoodItem> fooditems = new List<FoodItem>();

                    foreach (FoodItem fi in f.FoodItems)
                    {
                        if (fi.IsAvailable == 1)
                        {
                            Food_Size fs = new Food_Size { Id = fi.Food_Size.Id, SizeDescription = fi.Food_Size.SizeDescription };
                            FoodItem tempfi = new FoodItem { Id = fi.Id, Size = fi.Size, Price = fi.Price, IsAvailable = fi.IsAvailable, TagLine = fi.TagLine, Food_Size = fs };
                            fooditems.Add(tempfi);
                        }
                    }
                    tempf.FoodItems = fooditems;

                    //List<Food_AddOn> foodaddons = new List<Food_AddOn>();
                    //foreach (Food_AddOn fa in f.Food_AddOn)
                    //{
                    //    if (fa.AddOn.IsAvailable == 1)
                    //    {
                          
                    //        AddOn addon = new AddOn { Id = fa.AddOn.Id, Name = fa.AddOn.Name, Price = fa.AddOn.Price, IsAvailable = fa.AddOn.IsAvailable };
                    //        Food_Size fs = new Food_Size { Id = fa.Food_Size.Id, SizeDescription = fa.Food_Size.SizeDescription };
                    //        Food_AddOn faddon = new Food_AddOn { Id = fa.Id, FoodId = f.Id, AddOn = addon, Food_Size = fs };
                    //        foodaddons.Add(faddon);
                    //    }
                    //}

                    //tempf.Food_AddOn = foodaddons;
                    food.Add(tempf);
                }
            }
            return food;
        }
    }
}