using FYP1.Models;
using FYP1.Models.Department;
using FYP1.Models.Location;
using FYP1.Models.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FYP1.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult index()
        {
            return View();
        }

        // Registration
        public ActionResult AddStudent()
        {
            ViewBag.DegreeLevel_List = new SelectList(new DegreeLevel().DegreeLevel_Get_All(), "DegreeLevel_ID", "DegreeLevel_Name");
            ViewBag.State_List = new SelectList(new State().State_Get_All(), "State_ID ", "State_Name");
            ViewBag.Field_List = new SelectList(new DepartmentType().DepartmentType_Get_All(), "DepartmentType_ID", "DepartmentType_Name");
            ViewBag.Board_List = new SelectList(new Board().Board_Get_All(), "Board_ID", "Board_Name");
            ViewBag.Employment = new SelectList("Employe", "Self-Employe", "Unemploye");
            return View();
        }
        [HttpPost]
        public ActionResult AddStudent(Student s)
        {
            try
            {
                s.Student_ID = s.Student_Add();
                Mail m = new Mail();
                m.UserMail = s.Email;
                m.UserName = s.Student_Name;
                m.ConfimationLink = Url.Action("ConfirmEmail", "Student", new { Token = s.Student_ID, Email = s.Email }, Request.Url.Scheme);
                m.Sent();
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.DegreeLevel_List = new SelectList(new DegreeLevel().DegreeLevel_Get_All(), "DegreeLevel_ID", "DegreeLevel_Name");
                ViewBag.State_List = new SelectList(new State().State_Get_All(), "State_ID ", "State_Name");
                ViewBag.Field_List = new SelectList(new DepartmentType().DepartmentType_Get_All(), "DepartmentType_ID", "DepartmentType_Name");
                ViewBag.Board_List = new SelectList(new Board().Board_Get_All(), "Board_ID", "Board_Name");
                ViewBag.Employment = new SelectList("Employe", "Self-Employe", "Unemploye");
                return View();
            }
            return RedirectToAction("Confirmation");

            //return RedirectToAction("StudentLogin", "Login");
        }

        //Show All
        [HttpGet]
        public ActionResult ShowStudent()
        {
            return View(new Student().Student_Get_All());
        }

        [HttpGet]
        public ActionResult EditStudent(int id)
        {
            return View(new Student().Student_Get_By_Id(id));
        }

        [HttpPost]
        public ActionResult EditStudent(Student s)
        {
            //s.StudentUpdate();
            return View();
        }

        public ActionResult DeleteStudent(Student s)
        {
            //s.StudentDelete();
            return RedirectToAction("Index");
        }

        public ActionResult Confirmation()
        {
            return View();
        }
        public ActionResult ConfirmEmail(int token, string email)
        {
            new Student() { Student_ID = token, EmailConfirmation = true }.Student_EmailConfirm();
            return RedirectToAction("StudentLogin", "Login");
        }


        public ActionResult getdropdown(int a)
        {
            City c = new City();
            c.State_ID = a;

            return Json(c.City_Get_By_ID(), JsonRequestBehavior.AllowGet);
        }

        //yeh kya hai bhai ??
        public ActionResult show_All_Uni_selection()
        {
            Department d = new Department();
            List<Department> n = d.DepartmentAndType_Get_All().ToList();
            return View();
        }

    }
}