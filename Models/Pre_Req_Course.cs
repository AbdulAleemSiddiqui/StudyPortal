using DatabaseTVP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FYP1.Models
{
    public class Pre_Req_Course
    {
        [TVP]
        public int PR_Course_ID { get; set; }
        [TVP]
        public string PR_Course_Name{ get; set; }
        [TVP]
        public string PR_Course_Duration{ get; set; }
        [TVP]
        public int Degree_ID{ get; set; }
        public string Degree_Name { get; set; }






        //View Only Properties
        public string ReturnMessage { get; set; }


        public int Pre_Req_Course_Add()
        {
            try
            {
                //place your Model Logic and DB Calls here:
                string Message = DataBase.ExecuteQuery<Pre_Req_Course>(new { x = this }, Connection.Get()).FirstOrDefault().ReturnMessage;

                return int.Parse(Message);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public Pre_Req_Course Pre_Req_Course_Get_By_Id(int Id)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                Pre_Req_Course ret = DataBase.ExecuteQuery<Pre_Req_Course>(new { x = Id }, Connection.Get()).FirstOrDefault();
                return ret;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public List<Pre_Req_Course> Pre_Req_Course_Get_All()
        {
            try
            {
                //place your Model Logic and DB Calls here:
                List<Pre_Req_Course> ret = DataBase.ExecuteQuery<Pre_Req_Course>(new { }, Connection.Get());
                return ret;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string Pre_Req_Course_Edit()
        {
            try
            {
                //place your Model Logic and DB Calls here:
                string Message = DataBase.ExecuteQuery<Pre_Req_Course>(new { x = this }, Connection.Get()).FirstOrDefault().ReturnMessage;
                return Message;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string Pre_Req_Course_Delete(int Id)
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