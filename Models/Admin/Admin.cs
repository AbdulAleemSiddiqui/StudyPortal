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
        public string Payment_Info { get;  set; }
        public string Terms_And_Conditions { get;  set; }

        public int Admin_Login()
        {
            try
            {
                int A_ID = DataBase.ExecuteQuery<Admin>(new { x = this.Email,x1=this.Password }, Connection.Get()).FirstOrDefault().Admin_ID;
                return A_ID;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        
        public Admin Admin_Get()
        {
            return DataBase.ExecuteQuery<Admin>(new { }, Connection.Get()).FirstOrDefault();

        }
        public string Admin_Edit()
        {
            return DataBase.ExecuteQuery<Admin>(new { x= this.Name,x1 = this.Email, x2 = this.Password ,x3=this.Payment_Info,x4=this.Terms_And_Conditions}, Connection.Get()).FirstOrDefault().Name;

            return "";
        }
    }
}