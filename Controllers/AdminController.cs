using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FYP1.Models.Admin;
using FYP1.Models;
using FYP1.Models.Institute;
using FYP1.Models.Location;
using FYP1.ViewModel;
using FYP1.Models.Department;
using System.IO;

namespace FYP1.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult index()
        {


            return View();
        }
        // GET: Admin
        [HttpGet]
        public ActionResult AddDepartment()
        {
            DepartmentType dt = new DepartmentType();
            List<DepartmentType> lis = dt.DepartmentType_Get_All().ToList();
            ViewBag.DepartmentTypeList = new SelectList(lis, "DepartmentType_ID", "DepartmentType_Name");

            return View();
        }
        [HttpPost]

        public ActionResult AddDepartment(AdminViewModel avm)

        {
            try
            {
                List<DepartmentType> lis = avm.departmenttype.DepartmentType_Get_All().ToList();
                ViewBag.DepartmentTypeList = new SelectList(lis, "DepartmentType_ID", "DepartmentType_Name");
                avm.department.DepartmentType_ID = avm.departmenttype.DepartmentType_ID;
                avm.department.Department_Add();




            }
            catch (Exception ex)
            {
                throw ex;

            }
            return View(avm);

        }
        [HttpGet]
        public ActionResult ShowDepartment()
        {
            return View(new Department().DepartmentAndType_Get_All().ToList());
        }
        [HttpGet]

        public ActionResult UpdateDepartment(int id) //update mei phir bc list aagai? seedha seedha yahan query aati update ki phir department ka ek dafa phir se obj call hota jo getbyid se id utha k dept k obj k variable mei save hota or usay return mei call karwadete!
        {
            DepartmentType dt = new DepartmentType();
            List<DepartmentType> lis = dt.DepartmentType_Get_All().ToList();
            ViewBag.DepartmentTypeList = new SelectList(lis, "DepartmentType_ID", "DepartmentType_Name");
            Department dp = new Department();
            dp.Department_ID = id;
            Department D=dp.Department_Get_By_ID();
            return View(D);

        }
        [HttpPost]
        public ActionResult UpdateDepartment(Department d) // bc phir se dept ka obj? direct update ka method call hota bas 
        {
            DepartmentType dt = new DepartmentType();
            List<DepartmentType> lis = dt.DepartmentType_Get_All().ToList();
            ViewBag.DepartmentTypeList = new SelectList(lis, "DepartmentType_ID", "DepartmentType_Name");

            d.Department_Update();
            return RedirectToAction("ShowDepartment");   
        }
        //public ActionResult GetAllInstitute()
        //{
        //    return View(new AdminInstitute().AdminInstitute_Get_All());
        //}
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
              //  Institute i = new Institute();
                avm.institute.InstituteType_ID = avm.institutetype.InstituteType_ID;
                //avm.institute.Institute_img = imageupload(i.prop,i.Institute_img);
                string filename = Path.GetFileNameWithoutExtension(avm.institute.Prop.FileName);
                string extension = Path.GetExtension(avm.institute.Prop.FileName);
                filename = filename + DateTime.Now.ToString( "-yymmssffff") + extension;
                avm.institute.Institute_img = "/images/" + filename;
                filename = Path.Combine(Server.MapPath("/images/") , filename);
                avm.institute.Prop.SaveAs(filename);
              
                avm.institute.Institute_Add();



            }
            catch (Exception ex)
            {

                throw ex;
            }
            return View(avm);

        }
        public ActionResult getcitydropdown(int a)
        {

            City c = new City();
            c.State_ID = a;

            return Json(c.City_Get_By_ID(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult get_universitydropdown(int a)
        {

            //University u = new University();
            //u.City_ID = a;
            return View();
            //return Json(u.University_Get_By_ID(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult ShowInstitute()
        {
            return View(new Institute().Institute_Get_All().ToList());
        }
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
        public ActionResult GetCampusByIntitute(int I_ID)
        {
            return Json(new InstituteCampus().InstituteCampus_Get_All().FindAll(x=> x.Institute_ID == I_ID), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ShowInstituteCampus()
        {
            return View(new InstituteCampus().InstituteCampus_Get_All().ToList());
        }
        public ActionResult SearchInstituteCampus(int id)
        {
            return View(new InstituteCampus().InstituteCampus_Get_All().FindAll(x=>x.Institute_ID==id).ToList());
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





        [HttpGet]
        public ActionResult AddInstituteCampuse()
        {
            Institute i = new Institute();
            List<Institute> list = i.Institute_Get_All().ToList();
            ViewBag.InstituteList = new SelectList(list, "Institute_ID", "Institute_Name");




            return View();


        }
        [HttpPost]
        public ActionResult AddInstituteCampuse(AdminViewModel avm)
        {

            List<Institute> list = avm.institute.Institute_Get_All().ToList();
            ViewBag.Institutelist = new SelectList(list, "institute_id", "institute_name");
            avm.institutecampus.Institute_ID = avm.institute.Institute_ID;
            avm.institutecampus.InstituteCampus_Add();



            return View(avm);


        }
        [HttpGet]
        public ActionResult AddInstituteDepartment() // ye kya kia hai? Add k post k kam mei 
        {
            InstituteCampus ic = new InstituteCampus();
            Institute i = new Institute();
            Department d = new Department();
            DegreeLevel DL = new DegreeLevel();
          //  DegreeDuration DD = new DegreeDuration();
            List<Institute> lis = i.Institute_Get_All().ToList();
            ViewBag.InstituteList = new SelectList(lis, "Institute_ID", "Institute_Name");

           
            List<InstituteCampus> il = ic.InstituteCampus_Get_All().ToList();
            ViewBag.InstituteCampusList = new SelectList(il, "InsCampus_ID", "InsCampus_Address");

            List<Department> dl = d.Department_Get_All().ToList();
            ViewBag.DepartmentList = new SelectList(dl, "Department_ID", "Department_Name");

            List<DegreeLevel> dll = DL.DegreeLevel_Get_All().ToList();
            ViewBag.DegreeLevelList = new SelectList(dll, "DegreeLevel_ID", "DegreeLevel_Name");

            //List<DegreeDuration> ddl = DD.DegreeDuration_Get_All().ToList();
            //ViewBag.DegreeDurationList = new SelectList(ddl, "DegreeDuration_ID", "DegreeDuration_Name");
            return View();
        }

        [HttpPost]

        public ActionResult AddInstituteDepartment(AdminViewModel avm) // ek hi dafa se add() ka method call karkay redirect karwadetay showall pe :s 
                                                                    // ye acha kia k ek model mei alag alag classes ko call karwalia
        {
            List<Institute> lis = avm.institute.Institute_Get_All().ToList();
            ViewBag.InstituteList = new SelectList(lis, "Institute_ID", "Institute_Name");
            InstituteDepartment i = new InstituteDepartment();
            i.InsCampus_ID = avm.institutecampus.InsCampus_ID;
            i.Department_ID = avm.department.Department_ID;
            i.DegreeLevel_ID = avm.degreelevel.DegreeLevel_ID;
            i.InstituteDepartment_Add();


            List<InstituteCampus> il = avm.institutecampus.InstituteCampus_Get_All().ToList();
            ViewBag.InstituteCampusList = new SelectList(il, "InsCampus_ID", "InsCampus_Address");

            List<Department> dl = avm.department.Department_Get_All().ToList();
            ViewBag.DepartmentList = new SelectList(dl, "Department_ID", "Department_Name");

             List<DegreeLevel> dll = avm.degreelevel.DegreeLevel_Get_All().ToList();
              ViewBag.DegreeLevelList = new SelectList(dll, "DegreeLevel_ID", "DegreeLevel_Name");
            //  //List<DegreeDuration> ddl = avm.degreeduration.DegreeDuration_Get_All().ToList();
            //  //ViewBag.DegreeDurationList = new SelectList(ddl, "DegreeDuration_ID", "DegreeDuration_Name");

            //  avm.institutedepartment.InsCampus_ID = avm.institutecampus.InsCampus_ID;
            //  avm.institutedepartment.Department_ID = avm.department.Department_ID;
            //  avm.institutedepartment.DegreeLevel_ID = avm.degreelevel.DegreeLevel_ID;


            ////  avm.institutedepartment.DegreeDuration_ID = avm.degreeduration.DegreeDuration_ID;
            //  avm.institutedepartment.InstituteDepartment_Add();

            return View(avm);
        }
        //public string imageupload(HttpPostedFileBase image,string imagepath)
        //{
        //    string filename = Path.GetFileNameWithoutExtension(image.FileName);
        //    string extension = Path.GetExtension(image.FileName);
        //    filename = filename + DateTime.Now + "yymmssffff" + extension;
        //    imagepath = "~/images/" + filename;
        //    filename = Path.Combine(Server.MapPath("~/images/") + filename);
        //    image.SaveAs(filename);
        //    return imagepath;
        //}
    }
}