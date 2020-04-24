using DatabaseTVP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FYP1.Models
{
    public class InstituteReview
    {
      [TVP]
        public int R_ID { get; set; }
      [TVP]
        public int Inst_ID { get; set; }
        public string Institute_Name { get; set; }
        [TVP]
        public string Alumni_Name { get; set; }
      [TVP]
        public string Alumni_Email { get; set; }
      [TVP]
        public string Alumni_Review { get; set; }
      [TVP]
        public int Alumni_Rating { get; set; }
      [TVP]
        public DateTime Date { get; set; }





        //View Only Properties
        public string ReturnMessage { get; set; }


        public int InstituteReview_Add()
        {
            try
            {
                //place your Model Logic and DB Calls here:
                string Message = DataBase.ExecuteQuery<InstituteReview>(new { x = this }, Connection.Get()).FirstOrDefault().ReturnMessage;

                return int.Parse(Message);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public InstituteReview InstituteReview_Get_By_Id(int Id)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                InstituteReview ret = DataBase.ExecuteQuery<InstituteReview>(new { x = Id }, Connection.Get()).FirstOrDefault();
                return ret;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<InstituteReview> InstituteReview_Get_By_I_Id(int id)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                List<InstituteReview> ret = DataBase.ExecuteQuery<InstituteReview>(new { x1=id}, Connection.Get());
                return ret;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<InstituteReview> InstituteReview_Get_All()
        {
            try
            {
                //place your Model Logic and DB Calls here:
                List<InstituteReview> ret = DataBase.ExecuteQuery<InstituteReview>(new { }, Connection.Get());
                return ret;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string InstituteReview_Edit()
        {
            try
            {
                //place your Model Logic and DB Calls here:
                string Message = DataBase.ExecuteQuery<InstituteReview>(new { x = this }, Connection.Get()).FirstOrDefault().ReturnMessage;
                return Message;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string InstituteReview_Delete(int Id)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                string ret = DataBase.ExecuteQuery<InstituteReview>(new { x = Id }, Connection.Get()).FirstOrDefault().ReturnMessage;
                return ret;
            }
            catch (Exception ex)
            {
                return null;
            }
        }





    }
}