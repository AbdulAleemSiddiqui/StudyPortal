using DatabaseTVP;
using FYP1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FYP1.Models
{
    public class Degree
    {
        private const string Module = "";
        [TVP]
        public int D_ID { get; set; }
        [TVP]
        public string Name { get; set; }
        [TVP]
        public int Deprt_ID { get; set; }
        public string Deprt_Name { get; set; }
        [TVP]
        public int DL_ID { get; set; }
        public string DL_Name { get; set; }

        public string ReturnMessage { get; set; }
        public string Degree_Add()
        {
            try
            {
                //place your Model Logic and DB Calls here:
                
                string Message = DataBase.ExecuteQuery<Degree>(new { x = this }, Connection.Get()).FirstOrDefault().ReturnMessage;
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
        public Degree Degree_Get_By_Id(int Id)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                Degree ret = DataBase.ExecuteQuery<Degree>(new { x = Id }, Connection.Get()).FirstOrDefault();
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except 1), PageName, Module (for Multiple Areas), Connection to Log DB, 1
                Logger.Logging.DB_Log(Logger.eLogType.Log_Positive, "", new { x = Id }, "", Module, Connection.GetLogConnection(), 1);
                return ret;
            }
            catch (Exception ex)
            {
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except 1), PageName, Module (for Multiple Areas), Connection to Log DB, 1
                Logger.Logging.DB_Log(Logger.eLogType.Log_Negative, ex.Message, new { x = Id }, "", Module, Connection.GetLogConnection(), 1);
                return null;
            }
        }
        public List<Degree> Degree_Get_All()
        {
            try
            {
                //place your Model Logic and DB Calls here:
                List<Degree> ret = DataBase.ExecuteQuery<Degree>(new {  }, Connection.Get());
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except 1), PageName, Module (for Multiple Areas), Connection to Log DB, 1
                Logger.Logging.DB_Log(Logger.eLogType.Log_Positive, "", new { x = 1 }, "", Module, Connection.GetLogConnection(), 1);
                return ret;
            }
            catch (Exception ex)
            {
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except 1), PageName, Module (for Multiple Areas), Connection to Log DB, 1
                Logger.Logging.DB_Log(Logger.eLogType.Log_Negative, ex.Message, new { x = 1 }, "", Module, Connection.GetLogConnection(), 1);
                return null;
            }
        }
        public List<Degree> Degree_Get_By_Deprtment(int D_ID)
        {
            try
            {
                List<Degree> ret = DataBase.ExecuteQuery<Degree>(new {x1=D_ID }, Connection.Get());
                Logger.Logging.DB_Log(Logger.eLogType.Log_Positive, "", new { x = 1 }, "", Module, Connection.GetLogConnection(), 1);
                return ret;
            }
            catch (Exception ex)
            {
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except 1), PageName, Module (for Multiple Areas), Connection to Log DB, 1
                Logger.Logging.DB_Log(Logger.eLogType.Log_Negative, ex.Message, new { x = 1 }, "", Module, Connection.GetLogConnection(), 1);
                return null;
            }
        }
        public string Degree_Update()
        {
            try
            {
                //place your Model Logic and DB Calls here:
                string Message = DataBase.ExecuteQuery<Degree>(new { x = this }, Connection.Get()).FirstOrDefault().ReturnMessage;
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