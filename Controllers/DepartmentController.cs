using FYP1.Models.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FYP1.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            return View(new Department().Department_Get_All());
        }

        // GET: Department/Details/5
        public ActionResult Details(int id)
        {
            return View(new Department() { Department_ID=id}.Department_Get_By_ID());
        }

        // GET: Department/Create
        public ActionResult Create()
        {
            ViewBag.Deprtment_Type = new DepartmentType().DepartmentType_Get_All();
            return View();
        }

        // POST: Department/Create
        [HttpPost]
        public ActionResult Create(Department d)
        {
            try
            {
                // TODO: Add insert logic here
                d.Department_Add();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Department/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Deprtment_Type = new DepartmentType().DepartmentType_Get_All();
            return View(new Department() { Department_ID=id}.Department_Get_By_ID());
        }

        // POST: Department/Edit/5
        [HttpPost]
        public ActionResult Edit(Department d)
        {
            try
            {
                // TODO: Add update logic here
                d.Department_Update();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Department/Delete/5
        public ActionResult Delete(int id)
        {
             try
            {
                // TODO: Add delete logic here
                new Department() { Department_ID=id}.Department_Delete();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
