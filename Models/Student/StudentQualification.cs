﻿using System;
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
        public string DegreeLevel_Name { get; set; }
        [TVP]
        [DisplayName("Field")]
        public int Field_ID { get; set; }
        public string Field_Name{ get; set; }
        [TVP]
        [DisplayName("Board")]
        public int Board_ID { get; set; }
        public string Board_Name{ get; set; }
        [TVP]
        [DisplayName("Start Year")]
        public int Start_Year { get; set; }
        [TVP]
        [DisplayName("End Year")]
        public int End_Year { get; set; }
        [TVP]
        public decimal CGPA     { get; set; }
        [TVP]
        public decimal Percentage { get; set; }
        [TVP]
        public string Grades { get; set; }

        public StudentQualification Student_Qualification_GetById(int student_ID)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                StudentQualification ret = DataBase.ExecuteQuery<StudentQualification>(new { x = student_ID }, Connection.Get()).FirstOrDefault();
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except 1), PageName, Module (for Multiple Areas), Connection to Log DB, 1
                Logger.Logging.DB_Log(Logger.eLogType.Log_Positive, "", new { x = student_ID }, "", "", Connection.GetLogConnection(), 1);
                return ret;
            }
            catch (Exception ex)
            {
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except 1), PageName, Module (for Multiple Areas), Connection to Log DB, 1
                Logger.Logging.DB_Log(Logger.eLogType.Log_Negative, ex.Message, new { x = student_ID }, "", "", Connection.GetLogConnection(), 1);
                return null;
            }
        }
    }

}