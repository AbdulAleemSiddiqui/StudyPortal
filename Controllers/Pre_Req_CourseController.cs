using DatabaseTVP;
using FYP1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FYP1.Controllers
{
    public class Pre_Req_CourseController : Controller
    {



        //Get All
        public ActionResult Index()
        {
            return View(new Pre_Req_Course().Pre_Req_Course_Get_All());
        }

        //Search
        //Get By ID
        public ActionResult Search(int id)
        {
            return View(new Pre_Req_Course().Pre_Req_Course_Get_By_Id(id));
        }

        //Add
        public ActionResult Add()
        {
            ViewBag.Degrees = new Degree().Degree_Get_All();
            return View();
        }
        [HttpPost]
        public ActionResult Add(Pre_Req_Course obj)
        {
            obj.Pre_Req_Course_Add();
            return RedirectToAction("Index");
        }

        //Edit
        public ActionResult Edit(int id)
        {
            ViewBag.Degrees = new Degree().Degree_Get_All();
            return View(new Pre_Req_Course().Pre_Req_Course_Get_By_Id(id));
        }
        [HttpPost]
        public ActionResult Edit(Pre_Req_Course obj)
        {
            obj.Pre_Req_Course_Edit();
            return RedirectToAction("Index");
        }

        //Delete
        public ActionResult Delete(int id)
        {
            new Pre_Req_Course().Pre_Req_Course_Delete(id);
            return RedirectToAction("Index");
        }





    }
}