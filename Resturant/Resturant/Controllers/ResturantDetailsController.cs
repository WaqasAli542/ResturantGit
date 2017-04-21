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
    public class ResturantDetailController : Controller
    {
        //
        // GET: /ResturantDetail/

       
        #region ResturantDetail Methods
        /// <summary>
        /// Gets an object of ResturantDetail and add it into database.
        /// </summary>
        /// <param name="_ResturantDetail">Object which is to be added in the database</param>
        /// <returns> Add ResturantDetail view</returns>
        public ActionResult addResturantDetail(ResturantDetail _ResturantDetail)
        {
            BLResturantDetails BLResturantDetails = new BLResturantDetails();
            BLResturantDetails.addResturantDetail(_ResturantDetail);
            return RedirectToAction("displayResturantDetail");
        }
        /// <summary>
        /// Display ResturantDetail Page. This page display the form to add ResturantDetail and list of all ResturantDetails
        /// </summary>
        /// <returns></returns>
        public ActionResult displayResturantDetail()
        {
            var ResturantDetailList = new BLResturantDetails().getListOfResturantDetail();
            ViewBag.ResturantDetailList = ResturantDetailList;
            return View("AddResturantDetails");
        }

        /// <summary>
        /// This method is to display page for update ResturantDetail. It takes id of the object and then gets that object from
        /// database and then display it on the html page
        /// </summary>
        /// <param name="_id">ID of the object which is to be displayed to be edited</param>
        /// <returns>Page with the data to be edited</returns>

        public ActionResult displayUpdateResturantDetail(int _id)
        {
            BLResturantDetails BLResturantDetails = new BLResturantDetails();

          //  Category category = BLResturantDetails.getCategoryById(_id);
            ResturantDetail ResturantDetail = BLResturantDetails.getResturantDetailById(_id);
           // ViewBag.ResturantDetail = ResturantDetail;
            var ResturantDetailList = BLResturantDetails.getListOfResturantDetail();
            ViewBag.ResturantDetailList = ResturantDetailList;
            return View("UpdateResturantDetail");

        }
        /// <summary>
        /// Updates the object in database.
        /// </summary>
        /// <param name="ResturantDetail">Object to be updated.</param>
        /// <returns>Main ResturantDetail page</returns>

        public ActionResult updateResturantDetail(ResturantDetail ResturantDetail)
        {
            new BLResturantDetails().UpdateResturantDetail(ResturantDetail);
            return RedirectToAction("displayResturantDetail");
        }

        /// <summary>
        /// Delte the object which is selected
        /// </summary>
        /// <param name="_id">id of the object to be deleted</param>
        /// <returns>Add ResturantDetail page</returns>
        public ActionResult deleteResturantDetail(int _id)
        {
            BLResturantDetails BLResturantDetails = new BLResturantDetails();
            BLResturantDetails.deleteResturantDetail(_id);
            return RedirectToAction("displayResturantDetail");
        }

        #endregion

        #region Branch Methods
        /// <summary>
        /// Gets an object of Branch and add it into database.
        /// </summary>
        /// <param name="_Branch">Object which is to be added in the database</param>
        /// <returns> Add Branch view</returns>
        public ActionResult addBranch(Branch _Branch)
        {
            BLResturantDetails BLResturantDetails = new BLResturantDetails();
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];
                if (file != null && file.ContentLength > 0)
                {
                    file.SaveAs(Server.MapPath("~") + ProjectVaraiables.SERVERPATH + "\\" + file.FileName);
                    _Branch.Image = @"..\" + ProjectVaraiables.SERVERPATH + "\\" + file.FileName;

                }
            }
            BLResturantDetails.addBranch(_Branch);
            return RedirectToAction("displayBranch");
        }
        /// <summary>
        /// Display Branch Page. This page display the form to add Branch and list of all Branchs
        /// </summary>
        /// <returns></returns>
        public ActionResult displayBranch()
        {
            var resturants = new BLResturantDetails().getListOfResturantDetail();
            ViewBag.Resturants = resturants;
            var BranchList = new BLResturantDetails().getListOfBranch();
            ViewBag.Branch = BranchList;
            return View("AddBranch");
        }

        /// <summary>
        /// This method is to display page for update Branch. It takes id of the object and then gets that object from
        /// database and then display it on the html page
        /// </summary>
        /// <param name="_id">ID of the object which is to be displayed to be edited</param>
        /// <returns>Page with the data to be edited</returns>

        public ActionResult displayUpdateBranch(int _id)
        {
            BLResturantDetails BLResturantDetails = new BLResturantDetails();

            //  Category category = BLResturantDetails.getCategoryById(_id);
            Branch Branch = BLResturantDetails.getBranchById(_id);
             ViewBag.Branch = Branch;
             var resturants = new BLResturantDetails().getListOfResturantDetail();
             ViewBag.Resturants = resturants;
            return View("UpdateBranch");

        }
        /// <summary>
        /// Updates the object in database.
        /// </summary>
        /// <param name="Branch">Object to be updated.</param>
        /// <returns>Main Branch page</returns>

        public ActionResult updateBranch(Branch _Branch)
        {
              string isChecked = Request.Form["ImgBox"];
            if (isChecked !=null)
            {
                if (isChecked.Equals("on"))
                    _Branch.Image = string.Empty;
            }
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    file.SaveAs(Server.MapPath("~") + ProjectVaraiables.SERVERPATH + "\\" + file.FileName);
                    _Branch.Image = @"..\" + ProjectVaraiables.SERVERPATH + "\\" + file.FileName;
                }
            }   
            new BLResturantDetails().UpdateBranch(_Branch);
            return RedirectToAction("displayBranch");
        }

        /// <summary>
        /// Delte the object which is selected
        /// </summary>
        /// <param name="_id">id of the object to be deleted</param>
        /// <returns>Add Branch page</returns>
        public ActionResult deleteBranch(int _id)
        {
            BLResturantDetails BLResturantDetails = new BLResturantDetails();
            BLResturantDetails.deleteBranch(_id);
            return RedirectToAction("displayBranch");
        }

        #endregion
    }
}
