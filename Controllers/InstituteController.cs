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
        public ActionResult AddInstitute(Institute avm)
        {
            try
            {
                List<InstituteType> ls = new InstituteType().InstituteType_Get_All().ToList();
                ViewBag.InstituteType = new SelectList(ls, "InstituteType_ID", "InstituteType_Name");
                if (avm.Institute_img != null)
                {
                    avm.Institute_img = imageupload(avm.Prop, avm.Institute_img);
                    string filename = Path.GetFileNameWithoutExtension(avm.Prop.FileName);
                    string extension = Path.GetExtension(avm.Prop.FileName);
                    filename = filename + DateTime.Now.ToString("-yymmssffff") + extension;
                    avm.Institute_img = "/images/" + filename;
                    filename = Path.Combine(Server.MapPath("/images/"), filename);
                    avm.Prop.SaveAs(filename);
                }
                if (avm.Advertisement_Img != null)
                {
                    avm.Advertisement_Img = imageupload(avm.Prop2, avm.Advertisement_Img);
                    string filename = Path.GetFileNameWithoutExtension(avm.Prop2.FileName);
                    string  extension = Path.GetExtension(avm.Prop2.FileName);
                    filename = filename + DateTime.Now.ToString("-yymmssffff") + extension;
                    avm.Advertisement_Img = "/images/" + filename;
                    filename = Path.Combine(Server.MapPath("/images/"), filename);
                    avm.Prop.SaveAs(filename);
                }
                avm.Institute_Add();
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
            filename = filename + DateTime.Now.ToString().Replace(':','-').Replace('/','_')+ extension;
            imagepath = "~/images/" + filename;
            filename = Path.Combine(Server.MapPath("~/images/") + filename);
            image.SaveAs(filename);
            return imagepath;
        }

        //Extra actions for ajax call

        [HttpGet]
        public ActionResult UpdateInstitute(int id)
        {
            Institute ins = new Institute() { Institute_ID = id }.Institute_Get_By_ID();
            ViewBag.InstituteType = new SelectList(new InstituteType().InstituteType_Get_All(), "InstituteType_ID", "InstituteType_Name");

            return View(ins);
        }
        [HttpPost]
        public ActionResult UpdateInstitute(Institute obj)
        {
            ViewBag.InstituteType = new SelectList(new InstituteType().InstituteType_Get_All(), "InstituteType_ID", "InstituteType_Name");
            obj.Institute_img = obj.Institute_img == null ? "NON" : obj.Institute_img;
            obj.Advertisement_Img = obj.Advertisement_Img == null ? "NON" : obj.Advertisement_Img;
            obj.Query = 2; //for update we use 2
            obj.Institute_Update();
            return View(obj);
        }




        //For Student
        public ActionResult ShowInstitute_For_Student()
        {
            return View(new Institute().Institute_Get_All().ToList());
        }

    }
}