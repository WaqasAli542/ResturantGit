using Resturant.BAL;
using Resturant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Resturant.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View("Login");
        }

        public ActionResult authenticateUser(string email, string password)
        {
            Admin admin = new BLAdmin().authenticateAdmin(email, password);
            if (admin != null)
            {
                //hardcoded data
                BLFood blFood = new BLFood();
          
                var cousineList = blFood.getListOfCousine();
                ViewBag.cousineList = cousineList;
                return RedirectToAction("displayCousine","AdminFood");
            }
            return View("Login");
        }

        #region Cousine Methods
        public ActionResult addCousine(Cousine _cousine)
        {
            BLFood blFood=new BLFood();
            blFood.addCousine(_cousine);
            var cousineList = blFood.getListOfCousine();
            ViewBag.cousineList = cousineList;
            return View("Cousine");
        }

        public ActionResult deleteCousine(int _id)
        {
            BLFood blFood = new BLFood();
            blFood.deleteCousine(_id);
            var cousineList = blFood.getListOfCousine();
            ViewBag.cousineList = cousineList;
            return View("Cousine");
        }

        public ActionResult displayCousine()
        {
            var cousineList = new BLFood().getListOfCousine();
            ViewBag.cousineList = cousineList;
            return View("Cousine");
        }
        #endregion


    }
}
