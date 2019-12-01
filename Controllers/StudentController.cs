﻿using System;
using System.Collections.Generic;
using System.Linq;
using FYP1.Models.Student;
using FYP1.Models.Location;
using FYP1.Models;
using FYP1.ViewModel;
using System.Web;
using System.Web.Mvc;
using FYP1.Models.Department;

namespace FYP1.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult StudentInfo()
        {
            ViewBag.DegreeLevel_List = new SelectList(new DegreeLevel().DegreeLevel_Get_All(), "DegreeLevel_ID", "DegreeLevel_Name");
            ViewBag.State_List= new SelectList(new State().State_Get_All(), "State_ID ", "State_Name");
            ViewBag.Field_List= new SelectList(new DepartmentType().DepartmentType_Get_All(), "DepartmentType_ID", "DepartmentType_Name");
            ViewBag.Board_List= new SelectList(new Board().Board_Get_All(), "Board_ID", "Board_Name");
            return View();
        }
        [HttpPost]
        public ActionResult StudentInfo(Student s)
        {
            int id = 0;
            try
            {
                s.Student_Add();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("StudentLogin", "Login");
        }

        public ActionResult getdropdown(int a)
                {
                City c = new City();
            c.State_ID = a;

            return Json(c.City_Get_By_ID(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult show_All_Uni_selection()
        {

            Department d = new Department();
            List<Department> n = d.DepartmentAndType_Get_All().ToList();




            return View();
        }

    }
}