using FYP1.Models;
using FYP1.Models.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FYP1.Controllers
{
    public class DegreeController : Controller
    {
        // GET: Degree
        public ActionResult Index()
        {
            return View(new Degree().Degree_Get_All());
        }

        // GET: Degree/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Degree/Create
        public ActionResult Create()
        {
            ViewBag.deprtment = new Department().Department_Get_All();
            ViewBag.degreeLevel= new DegreeLevel().DegreeLevel_Get_All();
            return View();
        }

        // POST: Degree/Create
        [HttpPost]
        public ActionResult Create(Degree d)
        {
            try
            {
                // TODO: Add insert logic here
                d.Degree_Add();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Degree/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Degree/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Degree d)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Degree/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Degree/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Degree d)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
