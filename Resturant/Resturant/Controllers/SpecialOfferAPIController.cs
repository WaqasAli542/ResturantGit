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
    public class SpecialOfferAPIController : ApiController
    {
        public IEnumerable<SpecialOffer> GetSpecialOfferList()
        {
            List<SpecialOffer> soffers = new BLFood().getListOfSpecialOffers();
            List<SpecialOffer> specialoffers = new List<SpecialOffer>();

            foreach (SpecialOffer so in soffers)
            {
                SpecialOffer specialoffer = new SpecialOffer { Id = so.Id, StartingDate = so.StartingDate, EndingDate = so.EndingDate, StartingTime = so.StartingTime, EndingTime = so.StartingTime, Price = so.Price, Image = so.Image, Description = so.Description, Name = so.Name };
                List<SpecialOffer_AddOn> saddons = new List<SpecialOffer_AddOn>();
                foreach (SpecialOffer_AddOn saddon in so.SpecialOffer_AddOn)
                {
                    if (saddon.AddOn.IsAvailable == 1)
                    {
                        AddOn addon = new AddOn { Id = saddon.AddOn.Id, Name = saddon.AddOn.Name, Price = saddon.AddOn.Price, IsAvailable = 1 };
                        SpecialOffer_AddOn spa = new SpecialOffer_AddOn { Id = saddon.Id, AddOn = addon, Quantity = saddon.Quantity };
                        saddons.Add(spa);
                    }
                }
                specialoffer.SpecialOffer_AddOn = saddons;

                List<SpecialOffer_Item> sitems = new List<SpecialOffer_Item>();
                foreach (SpecialOffer_Item si in so.SpecialOffer_Item)
                {
                    List<Food> foods = FoodListByCategoryId(si.CategoryId, si.Food_Size.Id);
                    Category category = new Category { Id = si.CategoryId, Name = si.Category.Name, CousineId = si.Category.CousineId, Foods = foods };
                    SpecialOffer_Item sitem = new SpecialOffer_Item { Id = si.Id, Category = category, SizeId = si.SizeId, Quantity = si.Quantity, isFlexible = si.isFlexible };
                    sitems.Add(sitem);
                }
                specialoffer.SpecialOffer_Item = sitems;

                specialoffers.Add(specialoffer);
            }

            return specialoffers;
        }
        public SpecialOffer GetSpecialOfferById(int _Id)
        {
            SpecialOffer so = new BLFood().getSpecialOffersById(_Id);
            if (so == null)
                return null;
            SpecialOffer specialoffer = new SpecialOffer { Id = so.Id, StartingDate = so.StartingDate, EndingDate = so.EndingDate, StartingTime = so.StartingTime, EndingTime = so.StartingTime, Price = so.Price, Image = so.Image, Description = so.Description, Name = so.Name };

            List<SpecialOffer_AddOn> saddons = new List<SpecialOffer_AddOn>();
            foreach (SpecialOffer_AddOn saddon in so.SpecialOffer_AddOn)
            {
                if (saddon.AddOn.IsAvailable == 1)
                {
                    AddOn addon = new AddOn { Id = saddon.AddOn.Id, Name = saddon.AddOn.Name, Price = saddon.AddOn.Price, IsAvailable = 1 };
                    SpecialOffer_AddOn spa = new SpecialOffer_AddOn { Id = saddon.Id, AddOn = addon, Quantity = saddon.Quantity };
                    saddons.Add(spa);
                }
            }
            specialoffer.SpecialOffer_AddOn = saddons;

            List<SpecialOffer_Item> sitems = new List<SpecialOffer_Item>();
            foreach (SpecialOffer_Item si in so.SpecialOffer_Item)
            {
                List<Food> foods = FoodListByCategoryId(si.CategoryId, si.Food_Size.Id);
                Category category = new Category { Id = si.CategoryId, Name = si.Category.Name, CousineId = si.Category.CousineId, Foods = foods };
                SpecialOffer_Item sitem = new SpecialOffer_Item { Id = si.Id, Category = category, SizeId = si.SizeId, Quantity = si.Quantity, isFlexible = si.isFlexible };
                sitems.Add(sitem);
            }
            specialoffer.SpecialOffer_Item = sitems;

            return specialoffer;
        }
        //api/<controller>
       
        private List<Food> FoodListByCategoryId(int _CategoryId,int sizeid)
        {
            List<Food> flist = new BLFood().getListOfFoodByCategoryId(_CategoryId);
            if (flist == null)
                return null;
            List<Food> food = new List<Food>();
            foreach (Food f in flist)
            {
                if (f.IsAvailable == 1)
                {
                    Food tempf = new Food { Id = f.Id, Image = f.Image, Name = f.Name, IsAvailable = f.IsAvailable, Tageline = f.Tageline };
                    List<FoodItem> fooditems = new List<FoodItem>();

                    int check=0;
                    foreach (FoodItem fi in f.FoodItems)
                    {
                        if (fi.IsAvailable == 1 && fi.Food_Size.Id==sizeid)
                        {
                            check++;
                            Food_Size fs = new Food_Size { Id = fi.Food_Size.Id, SizeDescription = fi.Food_Size.SizeDescription };
                            FoodItem tempfi = new FoodItem { Id = fi.Id, Size = fi.Size, Price = fi.Price, IsAvailable = fi.IsAvailable, TagLine = fi.TagLine, Food_Size = fs };
                            fooditems.Add(tempfi);
                        }
                    }
                 
                    tempf.FoodItems = fooditems;
                    if (check != 0)
                    food.Add(tempf);
                }
            }

            return food;
        }
    }
}