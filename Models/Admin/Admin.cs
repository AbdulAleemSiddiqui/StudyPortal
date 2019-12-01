using DatabaseTVP;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FYP1.Models.Admin
{
    public class Admin
    {
        public int Admin_ID { get; set; }
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]

        public string Password { get; set; }
        public int Admin_Login()
        {
            try
            {
                //place your Model Logic and DB Calls here:
                int A_ID = DataBase.ExecuteQuery<Admin>(new { x = this.Email,x1=this.Password }, Connection.Get()).FirstOrDefault().Admin_ID;
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except 1), PageName, Module (for Multiple Areas), Connection to Log DB, 1
                Logger.Logging.DB_Log(Logger.eLogType.Log_Positive, "", new { x = this }, "", "", Connection.GetLogConnection(), 1);
                return A_ID;
            }
            catch (Exception ex)
            {
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except 1), PageName, Module (for Multiple Areas), Connection to Log DB, 1
                Logger.Logging.DB_Log(Logger.eLogType.Log_Negative, ex.Message, new { x = this }, "", "", Connection.GetLogConnection(), 1);
                return 0;
            }
        }
    }
}