using System;
using System.Collections.Generic;
using System.Linq;
using FYP1.Models.Student;
using FYP1.Models;
using FYP1.Models.Location;
using System.Web;

namespace FYP1.ViewModel
{
    public class StudentViewModel
    {
        public Student student { get; set; }
        public Board board { get; set; }
        public Student_Detail qualification { get; set; }
        public DegreeLevel degreelevel { get; set; }

        public Student_Detail studentqualification { get; set; }
        public State state { get; set; }
        public City city { get; set; }
    }
}