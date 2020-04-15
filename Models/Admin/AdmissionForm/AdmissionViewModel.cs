using DatabaseTVP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FYP1.Models.Admin.AdmissionForm
{
    public class AdmissionViewModel
    {
        public int A_ID { get; set; }
        public int AI_ID { get; set; }
        public int S_ID { get; set; }
        [DisplayName("Student Name")]
        public string Student_Name { get; set; }
        [DisplayName("CNIC")]
        public string CNIC_No { get; set; }
        public int Institute_ID { get; set; }
        [DisplayName("Father Name")]
        public string Father_Name { get; set; }
        [DisplayName("Institute Name")]
        public string Institute_Name { get; set; }

        [DisplayName("Degree Name")]
        public string Degree_Name { get; set; }
        public int Status_ID { get; set; }
        public string Status { get; set; }
        public List<AdmissionViewModel> Get_Admission_For_Admin()
        {
            try
            {
                //place your Model Logic and DB Calls here:
                List<AdmissionViewModel> ret = DataBase.ExecuteQuery<AdmissionViewModel>(new { }, Connection.Get());
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except 1), PageName, Module (for Multiple Areas), Connection to Log DB, 1
                Logger.Logging.DB_Log(Logger.eLogType.Log_Positive, "", new { x = 1 }, "", "", Connection.GetLogConnection(), 1);
                return ret;
            }
            catch (Exception ex)
            {
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except 1), PageName, Module (for Multiple Areas), Connection to Log DB, 1
                Logger.Logging.DB_Log(Logger.eLogType.Log_Negative, ex.Message, new { x = 1 }, "", "", Connection.GetLogConnection(), 1);
                return null;
            }
        }
        public List<AdmissionViewModel> Get_Admission_For_Institute(int I_ID)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                List<AdmissionViewModel> ret = DataBase.ExecuteQuery<AdmissionViewModel>(new { x=I_ID}, Connection.Get());
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except 1), PageName, Module (for Multiple Areas), Connection to Log DB, 1
                Logger.Logging.DB_Log(Logger.eLogType.Log_Positive, "", new { x = 1 }, "", "", Connection.GetLogConnection(), 1);
                return ret;
            }
            catch (Exception ex)
            {
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except 1), PageName, Module (for Multiple Areas), Connection to Log DB, 1
                Logger.Logging.DB_Log(Logger.eLogType.Log_Negative, ex.Message, new { x = 1 }, "", "", Connection.GetLogConnection(), 1);
                return null;
            }
        }
        public List<AdmissionViewModel> Get_Student_Admission()
        {
            try
            {
                //place your Model Logic and DB Calls here:
                List<AdmissionViewModel> ret = DataBase.ExecuteQuery<AdmissionViewModel>(new {x=this.S_ID }, Connection.Get());
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except 1), PageName, Module (for Multiple Areas), Connection to Log DB, 1
                Logger.Logging.DB_Log(Logger.eLogType.Log_Positive, "", new { x = 1 }, "", "", Connection.GetLogConnection(), 1);
                return ret;
            }
            catch (Exception ex)
            {
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except 1), PageName, Module (for Multiple Areas), Connection to Log DB, 1
                Logger.Logging.DB_Log(Logger.eLogType.Log_Negative, ex.Message, new { x = 1 }, "", "", Connection.GetLogConnection(), 1);
                return null;
            }
        }
    }
}