using DatabaseTVP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FYP1.Models
{
    public class Car
    {
        public int id { get; set; }
        public string name { get; set; }





        //View Only Properties
        public string ReturnMessage { get; set; }


        public int Car_Add()
        {
            try
            {
                //place your Model Logic and DB Calls here:
                string Message = DataBase.ExecuteQuery<Car>(new { x = this }, Connection.Get()).FirstOrDefault().ReturnMessage;

                return int.Parse(Message);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public Car Car_Get_By_Id(int Id)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                Car ret = DataBase.ExecuteQuery<Car>(new { x = Id }, Connection.Get()).FirstOrDefault();
                return ret;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public List<Car> Car_Get_All()
        {
            try
            {
                //place your Model Logic and DB Calls here:
                List<Car> ret = DataBase.ExecuteQuery<Car>(new { }, Connection.Get());
                return ret;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string Car_Edit()
        {
            try
            {
                //place your Model Logic and DB Calls here:
                string Message = DataBase.ExecuteQuery<Car>(new { x = this }, Connection.Get()).FirstOrDefault().ReturnMessage;
                return Message;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string Car_Delete(int Id)
        {
            try
            {
                //place your Model Logic and DB Calls here:
                string ret = DataBase.ExecuteQuery<Car>(new { x = Id }, Connection.Get()).FirstOrDefault().ReturnMessage;
                return ret;
            }
            catch (Exception ex)
            {
                return null;
            }
        }




    }
}