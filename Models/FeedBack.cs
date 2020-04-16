using DatabaseTVP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FYP1.Models
{
    public class FeedBack
    {
        [TVP]
        public int FB_ID { get; set; }
        [TVP]
        public bool is_Student { get; set; }
        [TVP]
        public bool is_Institute { get; set; }
        [TVP]
        public string User_Name { get; set; }
        [TVP]
        public string User_Email { get; set; }
        [TVP]
        public string Message { get; set; }
        [TVP]
        public string Response { get; set; }
        public DateTime FB_Date { get; set; }





        //View Only Properties
        public string ReturnMessage { get; set; }


        public int FeedBack_Add()
        {
            try
            {
                //place your Model Logic and DB Calls here:
                string Message = DataBase.ExecuteQuery<FeedBack>(new { x = this }, Connection.Get()).FirstOrDefault().ReturnMessage;

                return int.Parse(Message);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public FeedBack FeedBack_Get_By_Id(int Id)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                FeedBack ret = DataBase.ExecuteQuery<FeedBack>(new { x = Id }, Connection.Get()).FirstOrDefault();
                return ret;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public List<FeedBack> FeedBack_Get_All()
        {
            try
            {
                //place your Model Logic and DB Calls here:
                List<FeedBack> ret = DataBase.ExecuteQuery<FeedBack>(new { }, Connection.Get());
                return ret;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string FeedBack_Edit()
        {
            try
            {
                //place your Model Logic and DB Calls here:
                string Message = DataBase.ExecuteQuery<FeedBack>(new { x = this }, Connection.Get()).FirstOrDefault().ReturnMessage;
                return Message;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string FeedBack_Delete(int Id)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                string ret = DataBase.ExecuteQuery<Pre_Req_Course>(new { x = Id }, Connection.Get()).FirstOrDefault().ReturnMessage;
                return ret;
            }
            catch (Exception ex)
            {
                return null;
            }
        }




    }
}