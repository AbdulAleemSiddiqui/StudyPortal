using FYP1.Models.Institute;
using FYP1.Models.Location;
using FYP1.ViewModel;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FYP1.Controllers
{
    public class InstituteController : Controller
    {
        // GET: Institute
        public ActionResult ShowInstitute()
        {
            return View(new Institute().Institute_Get_All().ToList());
        }

        [HttpGet]
        public ActionResult AddInstitute()
        {
            InstituteType it = new InstituteType();
            State s = new State();
            List<InstituteType> IT = it.InstituteType_Get_All().ToList();
            ViewBag.InstituteType = new SelectList(IT, "InstituteType_ID", "InstituteType_Name");

            List<State> S = s.State_Get_All().ToList();
            ViewBag.StateList = new SelectList(S, "State_ID", "State_Name");


            return View();
        }
        [HttpPost]
        public ActionResult AddInstitute(AdminViewModel avm)
        {
            try
            {
                List<InstituteType> ls = avm.institutetype.InstituteType_Get_All().ToList();
                ViewBag.InstituteType = new SelectList(ls, "InstituteType_ID", "InstituteType_Name");
                 //Institute i = new Institute();
                avm.institute.InstituteType_ID = avm.institutetype.InstituteType_ID;
                avm.institute.Institute_img = imageupload(avm.institute.Prop, avm.institute.Institute_img);
                string filename = Path.GetFileNameWithoutExtension(avm.institute.Prop.FileName);
                string extension = Path.GetExtension(avm.institute.Prop.FileName);
                filename = filename + DateTime.Now.ToString("-yymmssffff") + extension;
                avm.institute.Institute_img = "/images/" + filename;
                filename = Path.Combine(Server.MapPath("/images/"), filename);
                avm.institute.Prop.SaveAs(filename);

                avm.institute.Institute_Add();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(avm);

        }
        public string imageupload(HttpPostedFileBase image, string imagepath)
        {
            string filename = Path.GetFileNameWithoutExtension(image.FileName);
            string extension = Path.GetExtension(image.FileName);
            filename = filename + DateTime.Now + "yymmssffff" + extension;
            imagepath = "~/images/" + filename;
            filename = Path.Combine(Server.MapPath("~/images/") + filename);
            image.SaveAs(filename);
            return imagepath;
        }

        //Extra actions for ajax call

        [HttpGet]
        public ActionResult UpdateInstitute(int id)
        {
            Institute i = new Institute();
            i.Institute_ID = id;
            Institute ins = i.Institute_Get_By_ID();
            return View(ins);
        }
        [HttpPost]
        public ActionResult UpdateInstitute(Institute obj)
        {
            obj.Query = 2; //for update we use 2
            obj.Institute_Update();
            return RedirectToAction("ShowInstitute");
        }


    }
}