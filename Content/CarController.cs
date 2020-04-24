using DatabaseTVP;
using FYP1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FYP1.Content
{
    public class CarController : Controller
    {
        // GET: Car



        //Get All
        public ActionResult Index()
        {
            return View(new Car().Car_Get_All());
        }

        //Search
        //Get By ID
        public ActionResult Search(int id)
        {
            return View(new Car().Car_Get_By_Id(id));
        }

        //Add
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Car obj)
        {
            obj.Car_Add();
            return View();
        }

        //Edit
        public ActionResult Edit(int id)
        {
            return View(new Car().Car_Get_By_Id(id));
        }
        [HttpPost]
        public ActionResult Edit(Car obj)
        {
            obj.Car_Edit();
            return View();
        }

        //Delete
        public ActionResult Delete(int id)
        {
            new Car().Car_Delete(id);
            return RedirectToAction("Index");
        }





    }
}