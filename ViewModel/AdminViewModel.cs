using System;
using System.Collections.Generic;
using System.Linq;
using FYP1.Models.Department;
using FYP1.Models.Student;
using FYP1.Models.Institute;
using FYP1.Models.Location;
using FYP1.Models.Admin;
using FYP1.Models;
using System.Web;

namespace FYP1.ViewModel
{
    public class AdminViewModel
    {
        public DegreeLevel degreelevel { get; set; }
        public Department department { get; set; }
        public DepartmentType departmenttype { get; set; }

        public Institute institute { get; set; }
        public InstituteType institutetype { get; set; }
        public InstituteCampus institutecampus { get; set; }

        public State state { get; set; }

        public City city { get; set; }

        public University university { get; set; }

        public DegreeDuration degreeduration { get; set; }
        public InstituteDepartment institutedepartment { get; set; }


    }
}