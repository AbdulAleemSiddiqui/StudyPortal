using FYP1.Models.Institute;
using FYP1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FYP1.Controllers
{
    public class InstituteCampusController : Controller
    {
        // GET: InstituteCampus
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddInstituteCampus()
        {
            Institute i = new Institute();
            List<Institute> list = i.Institute_Get_All().ToList();
            ViewBag.InstituteList = new SelectList(list, "Institute_ID", "Institute_Name");
            return View();
        }
        [HttpPost]
        public ActionResult AddInstituteCampus(AdminViewModel avm)
        {
            List<Institute> list = avm.institute.Institute_Get_All().ToList();
            ViewBag.Institutelist = new SelectList(list, "institute_id", "institute_name");
            avm.institutecampus.Institute_ID = avm.institute.Institute_ID;
            avm.institutecampus.InstituteCampus_Add();
            return View(avm);
        }

        public ActionResult SearchInstituteCampus(int id)
        {
            return View(new InstituteCampus().InstituteCampus_Get_All().FindAll(x => x.Institute_ID == id).ToList());
        }

        public ActionResult ShowInstituteCampus()
        {
            return View(new InstituteCampus().InstituteCampus_Get_All().ToList());
        }

        [HttpGet]
        public ActionResult UpdateInstituteCampus(int id)
        {
            InstituteCampus i = new InstituteCampus();
            i.InsCampus_ID = id;
            i.Query = 5;
            InstituteCampus ins = i.InstituteCampus_Get_By_ID();
            return View(ins);
        }
        [HttpPost]
        public ActionResult UpdateInstituteCampus(InstituteCampus obj)
        {
            obj.Query = 2; //for update we use 2
            obj.InstituteCampus_Update();
            return RedirectToAction("ShowInstituteCampus");
        }

        //For Ajax call
        public ActionResult GetCampusByIntitute(int I_ID)
        {
            return Json(new InstituteCampus().InstituteCampus_Get_All().FindAll(x => x.Institute_ID == I_ID), JsonRequestBehavior.AllowGet);
        }
        

        public ActionResult CampusForStudent(int id)
        {
            return View(new InstituteCampus().InstituteCampus_Get_All().FindAll(x => x.Institute_ID == id).ToList());
        }
    }
}