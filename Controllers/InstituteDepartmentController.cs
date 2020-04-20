using FYP1.Models;
using FYP1.Models.Admin;
using FYP1.Models.Department;
using FYP1.Models.Institute;
using FYP1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FYP1.Controllers
{
    public class InstituteDepartmentController : Controller
    {
        // GET: InstituteDepartment
        public ActionResult Index()
        {
            return View();
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
        {
            // ye acha kia k ek model mei alag alag classes ko call karwalia

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

    }
}