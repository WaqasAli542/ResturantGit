using Newtonsoft.Json;
using Resturant.BAL;
using Resturant.Models;
using Resturant.UtilityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Resturant.Controllers
{
public class AdminFoodController : Controller
{
    //
    // GET: /AdminFood/

    public ActionResult Index()
    {
        return View();
    }


    #region Cousine Methods
    /// <summary>
    /// Gets an object of cousine and add it into database.
    /// </summary>
    /// <param name="_cousine">Object which is to be added in the database</param>
    /// <returns> Add cousine view</returns>
    public ActionResult addCousine(Cousine _cousine)
    {
        BLFood blFood = new BLFood();
        blFood.addCousine(_cousine);
        var cousineList = blFood.getListOfCousine();
        ViewBag.cousineList = cousineList;
        return View("AddCousine");
    }
    /// <summary>
    /// Display Cousine Page. This page display the form to add cousine and list of all cousines
    /// </summary>
    /// <returns></returns>
    public ActionResult displayCousine()
    {
        var cousineList = new BLFood().getListOfCousine();
        ViewBag.cousineList = cousineList;
        return View("AddCousine");
    }

   /// <summary>
   /// This method is to display page for update cousine. It takes id of the object and then gets that object from
   /// database and then display it on the html page
   /// </summary>
   /// <param name="_id">ID of the object which is to be displayed to be edited</param>
   /// <returns>Page with the data to be edited</returns>

    public ActionResult displayUpdateCousine(int _id)
    {
        BLFood blfood = new BLFood();

        Category category = blfood.getCategoryById(_id);
        Cousine cousine = blfood.getCousineById(_id);
        ViewBag.Cousine = cousine;
        var cousineList = blfood.getListOfCousine();
        ViewBag.cousineList = cousineList;
        return View("UpdateCousine");

    }
    /// <summary>
    /// Updates the object in database.
    /// </summary>
    /// <param name="cousine">Object to be updated.</param>
    /// <returns>Main cousine page</returns>

    public ActionResult updateCousine(Cousine cousine)
    {
        new BLFood().updateCousine(cousine);
        return RedirectToAction("displayCousine");
    }

    /// <summary>
    /// Delte the object which is selected
    /// </summary>
    /// <param name="_id">id of the object to be deleted</param>
    /// <returns>Add cousine page</returns>
    public ActionResult deleteCousine(int _id)
    {
        BLFood blFood = new BLFood();
        blFood.deleteCousine(_id);
        var cousineList = blFood.getListOfCousine();
        ViewBag.cousineList = cousineList;
        return View("AddCousine");
    }

    #endregion

    #region Category
       

    /// <summary>
    /// Gets an object of Category and add it into database.
    /// </summary>
    /// <param name="_Category">Object which is to be added in the database</param>
    /// <returns> Add Category view</returns>
    public ActionResult AddCategory(Category _category)
    {
        BLFood blfood = new BLFood();
        blfood.addCategory(_category);
        List<Cousine> cousines = blfood.getListOfCousine();
        List<Category> category = blfood.getListOfCategory();
        ViewBag.Cousines = cousines;
        return View("AddCategory", category);

    }
    /// <summary>
    /// Display Category Page. This page display the form to add Category and list of all Categorys
    /// </summary>
    /// <returns></returns>
    public ActionResult DisplayAddCategory()
    {
        BLFood blfood = new BLFood();
        List<Cousine> cousines = blfood.getListOfCousine();
        List<Category> category = blfood.getListOfCategory();
        ViewBag.Cousines = cousines;
        return View("AddCategory", category);
    }

    public ActionResult DeleteCategory(int _id)
    {
        BLFood blFood = new BLFood();
        blFood.deleteCategory(_id);
        return RedirectToAction("DisplayAddCategory");
    }
    public ActionResult DisplayUpdateCategory(int _id)
    {
        BLFood blfood = new BLFood();

        Category category = blfood.getCategoryById(_id);
        List<Cousine> cousines = blfood.getListOfCousine();
        List<Category> categories = blfood.getListOfCategory();

        ViewBag.Cousines = cousines;
        ViewBag.Category = category;
        return View("UpdateCategory", categories);
    }
       
    public ActionResult UpdateCategory(Category _category)
    {
        new BLFood().updateCategory(_category);
        return RedirectToAction("DisplayAddCategory");
    }
    #endregion

    #region food

    /// <summary>
    /// Gets an object of Food and add it into database.
    /// </summary>
    /// <param name="_Food">Object which is to be added in the database. We store those images in database</param>
    /// <returns> Add Food view</returns>

    public ActionResult addFood(Food food)
    {
        BLFood blfood = new BLFood();
        if (Request.Files.Count > 0)
        {
            var file = Request.Files[0];

            if (file != null && file.ContentLength > 0)
            {
                file.SaveAs(Server.MapPath("~") + ProjectVaraiables.SERVERPATH + "\\" + file.FileName);
                food.Image = @"..\" + ProjectVaraiables.SERVERPATH + "\\" + file.FileName;

            }



        }

        blfood.addFood(food);
        return RedirectToAction("DisplayAddFood");
    }
    /// <summary>
    /// Display AddFood Page. This page display the form to add AddFood and list of all AddFoods
    /// </summary>
    /// <returns></returns>
    public ActionResult DisplayAddFood()
    {
        BLFood blfood = new BLFood();
        List<Cousine> cousines = blfood.getListOfCousine();
        ViewBag.Cousines = cousines;
        List<Food> food = blfood.getListOfFood();
        return View("AddFood",food);

    }

    public ActionResult DisplayFoodList(int id)
    {
        BLFood blfood = new BLFood();
        Food food = blfood.getFoodById(id);
        ViewBag.Food_Size = blfood.getListOfFood_Sizes();
        ViewBag.Ingredients = blfood.getListOfIngredients();
        ViewBag.AddOn = blfood.getListOfAddon();
        return View("DisplayFood", food);
    }


    public ActionResult deleteFood(int _id)
    {
        BLFood blFood = new BLFood();
        blFood.deleteFood(_id);
        return RedirectToAction("DisplayAddFood");
    }
    public ActionResult displayUpdateFood(int _id)
    {
        BLFood blfood = new BLFood();

        List<Cousine> cousines = blfood.getListOfCousine();
        ViewBag.Cousines = cousines;
        List<Food> foods = blfood.getListOfFood();

        Food food = blfood.getFoodById(_id);
        ViewBag.food = food;

        return View("UpdateFood", foods);
    }
    public ActionResult UpdateFood(Food _food)
    {
        string isChecked = Request.Form["ImgBox"];
            if (isChecked !=null)
            {
                if (isChecked.Equals("on"))
                    _food.Image = string.Empty;
            }
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    file.SaveAs(Server.MapPath("~") + ProjectVaraiables.SERVERPATH + "\\" + file.FileName);
                    _food.Image = @"..\" + ProjectVaraiables.SERVERPATH + "\\" + file.FileName;

                }
            }
        new BLFood().updateFood(_food);
        return RedirectToAction("DisplayAddFood");
    }


  
    #region food_Ingredients
    public ActionResult deleteFoodIngredients(int _id)
    {
        BLFood blfood = new BLFood();
        Food_Ingredients fi = blfood.getFood_IngredientById(_id);
        blfood.deleteFood_Ingredient(_id);
        return RedirectToAction("DisplayFoodList", new { id = fi.FoodID });
    }


    public ActionResult AddFoodIngredients(int id, int FoodId)
    {

        Food_Ingredients foodIngredients = new Food_Ingredients { FoodID = FoodId, IngredientsID = id };
        BLFood blfood = new BLFood();

        blfood.addFood_Ingredient(foodIngredients);
        return RedirectToAction("DisplayFoodList", new { id = FoodId });
    }

    #endregion

    #region Addon
    public ActionResult AddFoodAddOn(int AddOnID, int FoodId)
    {
        Food_AddOn foodAddOn = new Food_AddOn { FoodId = FoodId, AddOnId = AddOnID };
        BLFood blfood = new BLFood();
        blfood.addFood_AddOn(foodAddOn);
        return RedirectToAction("DisplayFoodList", new { id = FoodId });
    }

    // delete food AddOn
    public ActionResult deleteFoodAddOn(int _id)
    {
        BLFood blfood = new BLFood();
        Food_AddOn fi = blfood.getFood_AddOnById(_id);
        blfood.deleteFood_AddOn(_id);
        return RedirectToAction("DisplayFoodList", new { id = fi.FoodId });
    }
    #endregion

    #endregion

    #region FoodItem
    /// <summary>
    /// Gets an object of FoodItem and add it into database.
    /// </summary>
    /// <param name="_FoodItem">Object which is to be added in the database</param>
    /// <returns> Add FoodItem view</returns>
    public ActionResult AddFoodItem(FoodItem _foodItem)
    {
        BLFood blfood = new BLFood();
        blfood.addFoodItem(_foodItem);
        return RedirectToAction("DisplayFoodList", new { id = _foodItem.FoodId });


    }

    /// <summary>
    /// Display FoodItems Page. This page display the form to add FoodItems and list of all FoodItemss
    /// </summary>
    /// <returns></returns>
    public ActionResult DisplayAddFoodItem()
    {
        BLFood blfood = new BLFood();
        List<Food> food = blfood.getListOfFood();
        List<FoodItem> foodItem = blfood.getListOfFoodItem();
        List<Food_Size> sizes = blfood.getListOfFood_Sizes();
        ViewBag.Food_Size = sizes;
        ViewBag.Food = food;
        return View("AddFoodItem", foodItem);
    }



    public ActionResult deleteFoodItem(int _Id, int _foodId)
    {
        BLFood blFood = new BLFood();
        blFood.deleteFoodItem(_Id);
        return RedirectToAction("DisplayFoodList", new { id = _foodId });

    }

    public ActionResult DisplayUpdateFoodItem(int _id)
    {
        BLFood blfood = new BLFood();
        List<Food> food = blfood.getListOfFood();
        ViewBag.Food = food;
        FoodItem foodItem = blfood.getFoodItemById(_id);
        ViewBag.FoodItem = foodItem;
        return View("UpdateFoodItem", blfood.getListOfFoodItem());
    }

    public ActionResult UpdateFoodItem(FoodItem _foodItem)
    {
        new BLFood().updateFoodItem(_foodItem);
        return RedirectToAction("DisplayFoodList", new { id = _foodItem.FoodId });
    }
    #endregion


    #region Addon

    /// <summary>
    /// Gets an object of AddOn and add it into database.
    /// </summary>
    /// <param name="_AddOn">Object which is to be added in the database</param>
    /// <returns> Add AddOn view</returns>
    public ActionResult addAddon(AddOn _addOn)
    {
        BLFood blfood = new BLFood();
        blfood.addAddOn(_addOn);
        return RedirectToAction("DisplayAddOn");
    }

    /// <summary>
    /// Display AddOns Page. This page display the form to add AddOns and list of all AddOnss
    /// </summary>
    /// <returns></returns>

    public ActionResult DisplayAddOn()
    {
        BLFood blfood = new BLFood();
   
        return View("AddAddon",  blfood.getListOfAddon());

    }
 

    public ActionResult deleteAddOn(int _addOnId)
        {
            BLFood blFood = new BLFood();
            blFood.deleteAddon(_addOnId);
            return RedirectToAction("DisplayAddOn");
        }

    public ActionResult DisplayUpdateAddOn(int _id)
    {
        BLFood blfood = new BLFood();

        AddOn addOn = blfood.getAddOnById(_id);
        ViewBag.addOn = addOn;

        return View("UpdateAddOn", blfood.getListOfAddon());
    }

    public ActionResult UpdateAddOn(AddOn _addOn)
    {
        new BLFood().UpdateAddOn(_addOn);
        return RedirectToAction("DisplayAddOn");
    }
        
    #endregion

    #region Ingredients
    /// <summary>
    /// Gets an object of Ingredient and add it into database.
    /// </summary>
    /// <param name="_Ingredient">Object which is to be added in the database</param>
    /// <returns> Add Ingredient view</returns>
    public ActionResult addIngredients(Ingredient _IngredientOn)
    {
        BLFood blfood = new BLFood();
        blfood.addIngredient(_IngredientOn);
        return RedirectToAction("DisplayIngredients");
    }
    /// <summary>
    /// Display Ingredients Page. This page display the form to add Ingredients and list of all Ingredientss
    /// </summary>
    /// <returns></returns>
    public ActionResult DisplayIngredients()
    {
        BLFood blfood = new BLFood();
        return View("AddIngredients", blfood.getListOfIngredients());

    }

       

    public ActionResult deleteIngredients(int _Id)
    {
        BLFood blFood = new BLFood();
        blFood.deleteIngredient(_Id);
        return RedirectToAction("DisplayIngredients");
    }

    public ActionResult DisplayUpdateIngredients(int _id)
    {
        BLFood blfood = new BLFood();

        Ingredient ingredient = blfood.getIngredientById(_id);
        ViewBag.ingredient = ingredient;

        return View("UpdateIngredient", blfood.getListOfIngredients());
    }

    public ActionResult UpdateIngredients(Ingredient _ingredient)
    {
        new BLFood().UpdateIngredient(_ingredient);
        return RedirectToAction("DisplayIngredients");
    }
    #endregion


    #region Tax

    /// <summary>
    /// Gets an object of Tax and add it into database.
    /// </summary>
    /// <param name="_Tax">Object which is to be added in the database</param>
    /// <returns> Add Tax view</returns>
    public ActionResult AddTax(Tax _Tax)
    {
        BLTax blTax = new BLTax();
        blTax.addTax(_Tax);

        return RedirectToAction("DisplayAddTax");

    }
    /// <summary>
    /// Display Tax Page. This page display the form to add Tax and list of all Taxs
    /// </summary>
    /// <returns></returns>
    public ActionResult DisplayAddTax()
    {
        BLTax blTax = new BLTax();
        return View("AddTaxes", blTax.getListOfTax());
    }
    public ActionResult DisplayUpdateTax(int _id)
    {
        BLTax blTax = new BLTax();
        Tax Tax = blTax.getTaxById(_id);
        ViewBag.Tax = Tax;
        return View("UpdateTax", blTax.getListOfTax());
    }

    public ActionResult UpdateTax(Tax _tax)
    {
        BLTax blTax = new BLTax();
        blTax.UpdateTax(_tax);
        return RedirectToAction("DisplayAddTax");
    }
       

    public ActionResult deleteTax(int _Id)
    {
        BLTax blTax = new BLTax();
        blTax.deleteTax(_Id);
        return RedirectToAction("DisplayAddTax");
    }

       
    #endregion

    #region ExtraCharges
    /// <summary>
    /// Gets an object of ExtraCharges and add it into database.
    /// </summary>
    /// <param name="_ExtraCharges">Object which is to be added in the database</param>
    /// <returns> Add ExtraCharges view</returns>
    public ActionResult AddExtraCharges(ExtraCharge _extraCharge)
    {
        BLExtraCharges blExtracharges = new BLExtraCharges();
        blExtracharges.addExtraCharges(_extraCharge);

        return RedirectToAction("DisplayAddExtraCharges");

    }
    /// <summary>
    /// Display ExtraCharges Page. This page display the form to add ExtraCharges and list of all ExtraChargess
    /// </summary>
    /// <returns></returns>

    public ActionResult DisplayAddExtraCharges()
    {
        BLExtraCharges blExtracharges = new BLExtraCharges();
        return View("AddExtraCharges", blExtracharges.getListOfExtraCharges());
    }
    public ActionResult DisplayUpdateExtraCharges(int _id)
    {
        BLExtraCharges blExtracharges = new BLExtraCharges();
        ExtraCharge extraCharge = blExtracharges.getExtraChargesById(_id);
        ViewBag.ExtraCharge = extraCharge;
        return View("UpdateExtraCharges", blExtracharges.getListOfExtraCharges());
    }

    public ActionResult UpdateExtraCharges(ExtraCharge _extraCharge)
    {
        BLExtraCharges blExtracharges = new BLExtraCharges();
        blExtracharges.UpdateExtraCharges(_extraCharge);
        return RedirectToAction("DisplayAddExtraCharges");
    }

       
    public ActionResult deleteExtraCharges(int _Id)
    {
        BLExtraCharges blExtracharges = new BLExtraCharges();
        blExtracharges.deleteExtraCharges(_Id);
        return RedirectToAction("DisplayAddExtraCharges");
    }

      
    #endregion

    #region Special Offer
    /// <summary>
    /// Gets an object of SpecialOffer and add it into database.
    /// </summary>
    /// <param name="_SpecialOffer">Object which is to be added in the database</param>
    /// <returns> Add SpecialOffer view</returns>
    public ActionResult addSpecialOffer(SpecialOffer _specialOffer)
    {
        BLSpecialOffer blspecialOffer = new BLSpecialOffer();
        if (Request.Files.Count > 0)
        {
            var file = Request.Files[0];

            if (file != null && file.ContentLength > 0)
            {
                file.SaveAs(Server.MapPath("~") + ProjectVaraiables.SERVERPATH + "\\" + file.FileName);
                _specialOffer.Image = @"..\" + ProjectVaraiables.SERVERPATH + "\\" + file.FileName;

            }
        }

        blspecialOffer.addSpecialOffer(_specialOffer);
        return RedirectToAction("DisplayAddSpecialOffer");
    }
    /// <summary>
    /// Display AddSpecialOffer Page. This page display the form to add AddSpecialOffer and list of all AddSpecialOffers
    /// </summary>
    /// <returns></returns>
    public ActionResult DisplayAddSpecialOffer()
    {
        BLSpecialOffer blspecialOffer = new BLSpecialOffer();
        return View("AddSpecialOffer", blspecialOffer.getListOfSpecialOffer());

    }
    public ActionResult displayUpdateSpecialOffer(int _id)
    {
        BLSpecialOffer blspecialOffer = new BLSpecialOffer();
        SpecialOffer specialOffer = blspecialOffer.getSpecialOfferById(_id);
        ViewBag.SpecialOffer = specialOffer;
        return View("UpdateSpecialOffer", blspecialOffer.getListOfSpecialOffer());
    }

    public ActionResult UpdateSpecialOffer(SpecialOffer _specialOffer)
    {
        string isChecked = Request.Form["ImgBox"];
        if (isChecked != null)
        {
            if (isChecked.Equals("on"))
                _specialOffer.Image = string.Empty;
        }
        if (Request.Files.Count > 0)
        {
            var file = Request.Files[0];

            if (file != null && file.ContentLength > 0)
            {
                file.SaveAs(Server.MapPath("~") + ProjectVaraiables.SERVERPATH + "\\" + file.FileName);
                _specialOffer.Image = @"..\" + ProjectVaraiables.SERVERPATH + "\\" + file.FileName;
            }



        }
        new BLSpecialOffer().UpdateSpecialOffer(_specialOffer);
        return RedirectToAction("DisplayAddSpecialOffer");
    }

      

    public ActionResult deleteSpecialOffer(int _id)
    {
        BLSpecialOffer blspecialOffer = new BLSpecialOffer();
        blspecialOffer.deleteSpecialOffer(_id);
        return RedirectToAction("DisplayAddSpecialOffer");
    }
       
    # region Special offer Item
    public ActionResult deleteSpecialOfferItem(int _Itemid, int _OfferId)
    {
        BLFood blfood = new BLFood();
        blfood.deleteSpecialOffer_Item(_Itemid);
        return RedirectToAction("displaySpecialOfferPage", new { _id = _OfferId });
        
    }
    public ActionResult addSpecialOfferItem(SpecialOffer_Item specialOffer_Item, string flexible)
    {
        specialOffer_Item.isFlexible = Convert.ToInt32(flexible);
        BLFood blfood = new BLFood();
        blfood.addSpecialOffer_Item(specialOffer_Item);
        return RedirectToAction("displaySpecialOfferPage", new { _id = specialOffer_Item.SpecialOfferID });
    }
    //Testing
    public ActionResult DisplayUpdateSpecialOffer_Item(int _id)
    {
        BLFood blfood = new BLFood();

        SpecialOffer_AddOn SpecialOffer_AddOn = blfood.getSpecialOffer_AddOnById(_id);
        ViewBag.SpecialOffer_AddOn = SpecialOffer_AddOn;

        return View("UpdateSpecialOffer_AddOn", blfood.getListOfSpecialOffer_AddOn());
    }

    public ActionResult UpdateSpecialOffer_AddOn(SpecialOffer_AddOn _SpecialOffer_AddOn)
    {
        new BLFood().UpdateSpecialOffer_AddOn(_SpecialOffer_AddOn);
        return RedirectToAction("DisplaySpecialOffer_AddOn");
    }
       
    #endregion

    # region Special offer Addon
    public ActionResult deleteSpecialOfferAddOn(int _Itemid, int _OfferId)
    {
        BLFood blfood = new BLFood();
        blfood.deleteSpecialOffer_AddOn(_Itemid);
        return RedirectToAction("displaySpecialOfferPage", new { _id = _OfferId });

    }

    public ActionResult addSpecialOfferAddOn(SpecialOffer_AddOn specialoAddOn)
    {
        BLFood blfood = new BLFood();
        blfood.addSpecialOffer_AddOn(specialoAddOn);
        return RedirectToAction("displaySpecialOfferPage", new { _id = specialoAddOn.SpecialOfferID });
    }
    //Testing
    //public ActionResult DisplayUpdateSpecialOffer_Item(int _id)
    //{
    //    BLFood blfood = new BLFood();

    //    SpecialOffer_Item SpecialOffer_Item = blfood.getSpecialOffer_ItemById(_id);
    //    ViewBag.SpecialOffer_Item = SpecialOffer_Item;

    //    return View("UpdateSpecialOffer_Item", blfood.getListOfSpecialOffer_Item());
    //}

    public ActionResult UpdateSpecialOffer_Item(SpecialOffer_Item _SpecialOffer_Item)
    {
        new BLFood().UpdateSpecialOffer_Item(_SpecialOffer_Item);
        return RedirectToAction("DisplaySpecialOffer_Item");
    }
    #endregion

    /// <summary>
    /// Addition of AddOn
    /// </summary>
    /// <param name="specialOffer_Item"></param>
    /// <param name="flexible"></param>
    /// <returns></returns>
        

    public ActionResult displaySpecialOfferPage(int _id)
    {
        BLFood blfood = new BLFood();
        SpecialOffer so = blfood.getSpecialOffersById(_id);
        ViewBag.Sizes = blfood.getListOfFood_Sizes();
        ViewBag.Cousines = blfood.getListOfCousine();
        ViewBag.AddOn = blfood.getListOfSpecialOffer_AddOn().Where(offer => offer.SpecialOfferID == _id);
        ViewBag.Items = blfood.getListOfSpecialOffer_Item().Where(offer => offer.SpecialOfferID == _id);
        return View("SpecialOfferItem", so);
    }


    #endregion

    # region Ajax Method

    [HttpGet]
   
    /// <summary>
    /// Ajax call
    /// </summary>
    /// <param name="AddOncategoryId"></param>
    /// <param name="specialOfferId"></param>
    /// <returns></returns>
    /// 
    public string getSpecialOfferAddOn(int AddOncategoryId, int specialOfferId)
    {
        List<AddOn> addOnList = new BLFood().getListOfCategoryOfAddon(AddOncategoryId);
        List<SpecialOffer_AddOn> soao = new BLFood().getListOfSpecialOffer_AddOn_OfSpecificValues(specialOfferId);
        List<AddOn> truncatedAddons = new List<AddOn>();

        foreach (AddOn addon in addOnList)
        {
            bool check = true;
            foreach (SpecialOffer_AddOn offerAddon in soao)
            {
                if (offerAddon.AddonID == addon.Id)
                {
                    check = false;
                    break;
                }
            }
            if (check)
                truncatedAddons.Add(addon);
        }
        return JsonConvert.SerializeObject(truncatedAddons, Formatting.Indented,
            new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            }
        );
    }
    public string getCategory(int cousineId)
    {
        List<Category> cats = new BLFood().getListOfCategoryByCousineId(cousineId);
        return JsonConvert.SerializeObject(cats, Formatting.Indented,
            new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            }
        );
    }
    #endregion

    #region Discount
    /// <summary>
    /// Gets an object of Discount and add it into database.
    /// </summary>
    /// <param name="_Discount">Object which is to be added in the database</param>
    /// <returns> Add Discount view</returns>
    public ActionResult AddDiscount(Discount discount)
    {
        new BLDiscount().addDiscount(discount);
        return RedirectToAction("DisplayAddDiscount");
    }
    /// <summary>
    /// Display Discount Page. This page display the form to add Discount and list of all Discounts
    /// </summary>
    /// <returns></returns>
    public ActionResult DisplayAddDiscount()
    {
        BLDiscount blDiscount = new BLDiscount();
        BLFood blfood = new BLFood();
        List<Cousine> cousines = blfood.getListOfCousine();
        ViewBag.Cousines = cousines;
        List<Discount> Discount = blDiscount.getListOfDiscount();
        return View("AddDiscount", Discount);
    }
  

    public ActionResult DisplayUpdateDiscount(int _id)
    {
        BLDiscount bldiscount = new BLDiscount();
        ViewBag.DiscountList = bldiscount.getListOfDiscount();
        Discount obj= bldiscount.getDiscountById(_id);
        ViewBag.Cousines = new BLFood().getListOfCousine();
        return View("UpdateDiscount", obj);
    }

    public ActionResult UpdateDiscount(Discount discount)
    {
        new BLDiscount().UpdateDiscount(discount);
        return RedirectToAction("DisplayAddDiscount");

    }

    public ActionResult DeleteDiscount(int _id)
    {
        BLDiscount bldiscount = new BLDiscount();
        bldiscount.deleteDiscount(_id);
        return RedirectToAction("DisplayAddDiscount");
    }




    #endregion
}
}
