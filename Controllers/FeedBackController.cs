using DatabaseTVP;
using FYP1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FYP1.Controllers
{
    public class FeedBackController : Controller
    {



        //Get All
        public ActionResult Index()
        {
            return View(new FeedBack().FeedBack_Get_All());
        }

        //Search
        //Get By ID
        public ActionResult Search(int id)
        {
            return View(new FeedBack().FeedBack_Get_By_Id(id));
        }

        //Add
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(FeedBack obj)
        {
           int id=   obj.FeedBack_Add();
            return RedirectToAction("Index");
        }

        //Edit
        public ActionResult Edit(int id)
        {
            return View(new FeedBack().FeedBack_Get_By_Id(id));
        }
        [HttpPost]
        public ActionResult Edit(FeedBack obj)
        {
            obj.FeedBack_Edit();
            return RedirectToAction("Index");
        }

        //Delete
        public ActionResult Delete(int id)
        {
            new FeedBack().FeedBack_Delete(id);
            return RedirectToAction("Index");
        }





    }
}