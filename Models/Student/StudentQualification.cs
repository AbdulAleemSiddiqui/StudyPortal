using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FYP1.Models;
using System.Data.SqlClient;
using DatabaseTVP;
using System.ComponentModel;

namespace FYP1.Models.Student
{
    public class StudentQualification
    {
        [TVP]
        public int SQ_ID { get; set; }
        [TVP]
        public int Student_ID { get; set; }
        [DisplayName("Degree Level")]
        [TVP]
        public int DegreeLevel_ID { get; set; }
        [TVP]
        [DisplayName("Field")]
        public int Field_ID { get; set; }
        [TVP]
        [DisplayName("Board")]
        public int Board_ID { get; set; }
        [TVP]
        [DisplayName("Start Year")]
        public int Start_Year { get; set; }
        [TVP]
        [DisplayName("End Year")]
        public int End_Year { get; set; }
        [TVP]
        public decimal CGPA { get; set; }
        [TVP]
        public decimal Percentage { get; set; }
        [TVP]
        public string Grades { get; set; }




       

    }

}