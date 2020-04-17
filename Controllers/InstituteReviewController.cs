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
            return View(new InstituteReview().InstituteReview_Get_All());
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
            return View();
        }

        //Delete
        public ActionResult Delete(int id)
        {
            new InstituteReview().InstituteReview_Delete(id);
            return RedirectToAction("Index");
        }





    }
}