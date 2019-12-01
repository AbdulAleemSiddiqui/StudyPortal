using FYP1.Models;
using FYP1.Models.Admin.AdmissionForm;
using FYP1.Models.Department;
using FYP1.Models.Institute;
using FYP1.Models.Student;
using FYP1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FYP1.Controllers
{
    public class AdmissionFormController : Controller
    {



        // GET: AdmissionForm

        [Student_Session]
        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.DegreeLevel = new DegreeLevel().DegreeLevel_Get_All();
            ViewBag.Department = new Department().DepartmentAndType_Get_All();
            ViewBag.Degree = new Degree().Degree_Get_All();
            if (Session["S_ID"] != null)
            {
                int id = (int)Session["S_ID"];
                AdmissionForm s = new AdmissionForm() { S_ID = id };
                return View(s);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Add(AdmissionForm obj)
        {
            obj.Inst_List = obj.Inst_List.FindAll(x => x.I_ID != 0);
            //AdminViewModel a = new AdminViewModel();
            //List<Institute> lis = a.institute.Institute_Get_All().ToList();
            //ViewBag.InstituteList = new SelectList(lis, "Institute_ID", "Institute_Name");
            //a.institute.Institute_ID = a.institute.Institute_ID;
            int A_ID = obj.Admission_Add();

            foreach (var item in obj.Inst_List)
            {
                item.A_ID = A_ID; // last admission ID
                item.Add();
            }
            return RedirectToAction("AdmissionStatus");
        }
        public ActionResult GetByDeprtment(int D_ID)
        {
            return Json(new Institute().Institute_Get_By_Deprt(D_ID), JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetByDegree(int Degree_ID)
        {
            return Json(new Institute().Institute_Get_By_Degree(Degree_ID), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDegreeByDeprtment(int D_ID)
        {
            return Json(new Degree().Degree_Get_By_Deprtment(D_ID), JsonRequestBehavior.AllowGet);
        }
     

        [Admin_Session]
        //Admin
        public ActionResult Get_Unpaid_Admission()
        {
            return View(new AdmissionViewModel().Get_Admission_For_Admin());
        }
        [Admin_Session]
        [HttpGet]
        public ActionResult PayAdmission(int AI_ID)
        {
            new Admission_Institute() { AI_ID = AI_ID }.Pay();
            return RedirectToAction("Get_Unpaid_Admission");
        }

        [Institute_Session]

        public ActionResult Get_Paid_Admission()
        {
            return View(new AdmissionViewModel().Get_Admission_For_Institute((int)Session["I_ID"]));
        }
        [Institute_Session]
        [HttpGet]
        public ActionResult AdmissionResponse(int AI_ID, int Status_ID)
        {
            new Admission_Institute() { AI_ID = AI_ID, Status_ID = Status_ID }.Response();
            return RedirectToAction("Get_paid_Admission");
        }
        [Student_Session]

        public ActionResult AdmissionStatus()
        {
            return View(new AdmissionViewModel() { S_ID=(int)Session["S_ID"]}.Get_Student_Admission());
        }




        [HttpPost]
        public ActionResult UpdateAdmissionform(AdmissionForm obj)
        {
            obj.Query = 2; //for update we use 2
            //obj.Admission_Update();
            return RedirectToAction("ShowAdmissionForm");


        }






    }
}