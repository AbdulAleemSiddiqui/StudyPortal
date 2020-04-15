using FYP1.Models.Department;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FYP1.Controllers
{
    public class Department_TypeController : Controller
    {
        // GET: Department_Type
        public ActionResult Index()
        {
            return View(new DepartmentType().DepartmentType_Get_All());
        }

        // GET: Department_Type/Details/5
        public ActionResult Details(int id)
        {
            return View(new DepartmentType() { DepartmentType_ID = id }.DepartmentType_Get_By_ID());
        }

        // GET: Department_Type/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Department_Type/Create
        [HttpPost]
        public ActionResult Create(DepartmentType d)
        {
            try
            {
                // TODO: Add insert logic here
                d.DepartmentType_Add();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
        }

        // GET: Department_Type/Edit/5
        public ActionResult Edit(int id)
        {
            return View(new DepartmentType() { DepartmentType_ID = id }.DepartmentType_Get_By_ID());
        }

        // POST: Department_Type/Edit/5
        [HttpPost]
        public ActionResult Edit( DepartmentType d)
        {
            try
            {
                // TODO: Add update logic here
                d.DepartmentType_Update();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Department_Type/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                new DepartmentType() { DepartmentType_ID = id }.DepartmentType_Delete();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Department_Type/Delete/5
        
    }
}
