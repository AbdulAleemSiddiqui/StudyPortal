﻿using FYP1.Models.Admin;
using FYP1.Models.Institute;
using FYP1.Models.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FYP1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult StudentLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult StudentLogin(Student s)
        {
            int id=s.Student_Login();
            if(id >0)
            {
                Session["S_ID"] = id;
                return RedirectToAction("Add", "AdmissionForm");
            }
            return View();
        }
        public ActionResult InstituteLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InstituteLogin(Institute  s)
        {
            int id = s.Institute_Login();
            if (id > 0)
            {
                Session["I_ID"] = id;
                return RedirectToAction("Get_paid_Admission", "AdmissionForm");
            }
            return View();
        }
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin s)
        {
            int id = s.Admin_Login();
            if (id > 0)
            {
                Session["A_ID"] = id;
                return RedirectToAction("Get_Unpaid_Admission", "AdmissionForm");
            }
            return View();
        }
    }
}