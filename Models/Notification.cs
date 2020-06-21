using DatabaseTVP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FYP1.Models
{
    public class Notification
    {
        public int N_ID { get; set; }
        public string Name { get; set; }
        public int Fk_Id { get; set; }
        public string Message { get; set; }
        public bool isSeen { get; set; }
        public bool isCommon { get; set; }

        public string ReturnMessage { get; set; }

        public string Notification_Update(int Id)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                string message= DataBase.ExecuteQuery<Pre_Req_Course>(new { x = Id }, Connection.Get()).FirstOrDefault().ReturnMessage;
                return message;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<Notification> Notification_Admin()
        {
            try
            {
                //place your Model Logic and DB Calls here:
                List<Notification> lst = DataBase.ExecuteQuery<Notification>(new {   }, Connection.Get());
                return lst;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<Notification> Notification_Student()
        {
            try
            {
                //place your Model Logic and DB Calls here:
                List<Notification> lst = DataBase.ExecuteQuery<Notification>(new { x=this.Fk_Id}, Connection.Get());
                return lst;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<Notification> Notification_Institute()
        {
            try
            {
                //place your Model Logic and DB Calls here:
                List<Notification> lst = DataBase.ExecuteQuery<Notification>(new { x = this.Fk_Id }, Connection.Get());
                return lst;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}