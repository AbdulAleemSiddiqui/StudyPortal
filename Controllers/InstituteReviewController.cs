using DatabaseTVP;
using FYP1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FYP1.Controllers
{
    public class InstituteReviewController : Controller
    {



        //Get All
        public ActionResult Index()
        {
            return View(new InstituteReview().InstituteReview_Get_By_I_Id((int)Session["I_ID"]));
        }

        //Search
        //Get By ID
        public ActionResult Search(int id)
        {
            return View(new InstituteReview().InstituteReview_Get_By_Id(id));
        }

        //Add
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(InstituteReview obj)
        {
            if (Session["I_ID"] != null)
            {
                obj.Inst_ID = (int)Session["I_ID"];
                obj.InstituteReview_Add();
                return RedirectToAction("Index");
            }
            obj.InstituteReview_Add();
            return View();
        }

        //Edit
        public ActionResult Edit(int id)
        {
            return View(new InstituteReview().InstituteReview_Get_By_Id(id));
        }
        [HttpPost]
        public ActionResult Edit(InstituteReview obj)
        {
            obj.InstituteReview_Edit();
            return RedirectToAction("Index");
        }

        //Delete
        public ActionResult Delete(int id)
        {
            new InstituteReview().InstituteReview_Delete(id);
            return RedirectToAction("Index");
        }





    }
}