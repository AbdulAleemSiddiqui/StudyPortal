using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DatabaseTVP;

namespace FYP1.Models.Student
{
    public class Student
    {
        [TVP]
        public int Student_ID { get; set; }
        [TVP]
        public string Student_Name { get; set; }
        [TVP]
        public string Father_Name { get; set; }
        [TVP]
        public string CNIC_No { get; set; }
        [TVP]
        public string Email { get; set; }
        [TVP]
        public bool EmailConfirmation { get; set; }
        [TVP]
        public string Contact_No { get; set; }
        [TVP]
        public DateTime DOB { get; set; }
        [TVP]
        [DisplayName("City")]
        public int City_ID { get; set; }
        [TVP]
        public string Nationality { get; set; }
        [TVP]
        public string Password { get; set; }
        public Student_Detail detail { get; set; } = new Student_Detail();



        private const string Module = "Module";

        //Your Properties for Model Here




        //View Only Properties
        public string ReturnMessage { get; set; }


        public int Student_Add()
        {
            try
            {
                //place your Model Logic and DB Calls here:
                return DataBase.ExecuteQuery<Student>(new { x = this ,x1=detail}, Connection.Get()).FirstOrDefault().Student_ID;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public Student Student_Get_By_Id(int Id)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                Student ret = DataBase.ExecuteQuery<Student>(new { x = Id }, Connection.Get()).FirstOrDefault();
                return ret;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public List<Student> Student_Get_All()
        {
            try
            {
                //place your Model Logic and DB Calls here:
                List<Student> ret = DataBase.ExecuteQuery<Student>(new { }, Connection.Get());
                return ret;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string Student_Edit()
        {
            try
            {
                //place your Model Logic and DB Calls here:
                string Message = DataBase.ExecuteQuery<Student>(new { x = this,x1=detail }, Connection.Get()).FirstOrDefault().ReturnMessage;
                return Message;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string Student_Delete(int Id)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                string ret = DataBase.ExecuteQuery<Student>(new { x = Id }, Connection.Get()).FirstOrDefault().ReturnMessage;
                return ret;
            }
            catch (Exception ex)
            {
                return null;
            }
        }





        public int Student_Login()
        {
            try
            {
                //place your Model Logic and DB Calls here:
                int Student_ID = DataBase.ExecuteQuery<Student>(new { x = this.Email, x1 = this.Password }, Connection.Get()).FirstOrDefault().Student_ID;
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except 1), PageName, Module (for Multiple Areas), Connection to Log DB, 1
                Logger.Logging.DB_Log(Logger.eLogType.Log_Positive, "", new { x = this }, "", Module, Connection.GetLogConnection(), 1);
                return Student_ID;
            }
            catch (Exception ex)
            {
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except 1), PageName, Module (for Multiple Areas), Connection to Log DB, 1
                Logger.Logging.DB_Log(Logger.eLogType.Log_Negative, ex.Message, new { x = this }, "", Module, Connection.GetLogConnection(), 1);
                return 0;
            }
        }
        public string Student_EmailConfirm()
        {
            try
            {
                //place your Model Logic and DB Calls here:
                string Message = DataBase.ExecuteQuery<Student>(new { x = this.Student_ID }, Connection.Get()).FirstOrDefault().ReturnMessage;
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except 1), PageName, Module (for Multiple Areas), Connection to Log DB, 1
                Logger.Logging.DB_Log(Logger.eLogType.Log_Positive, "", new { x = this }, "", Module, Connection.GetLogConnection(), 1);
                return Message;
            }
            catch (Exception ex)
            {
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except 1), PageName, Module (for Multiple Areas), Connection to Log DB, 1
                Logger.Logging.DB_Log(Logger.eLogType.Log_Negative, ex.Message, new { x = this }, "", Module, Connection.GetLogConnection(), 1);
                return null;
            }
        }



    }

}