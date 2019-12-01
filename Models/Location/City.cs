using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using FYP1.ViewModel;
using System.Web;

namespace FYP1.Models.Location
{
    public class City
    {

        public int City_ID { get; set; }

        public string City_Name { get; set; }
        public int State_ID { get; set; }

       
        public List<City> City_Get_All()
        {
            List<City> lst = new List<City>();
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_City", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            //sc.Parameters.AddWithValue("@City_ID", 0);
            //sc.Parameters.AddWithValue("@City_Name", null);
          //  sc.Parameters.AddWithValue("@State_ID",0);

            sc.Parameters.AddWithValue("@Query", 4);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                City c = new City();
                c.City_ID = (int)sdr["City_ID"];
                c.City_Name = (string)sdr["City_Name"];
                c.State_ID = (int)sdr["State_ID"];
                lst.Add(c);
            }
            sdr.Close();
            return lst;
        }
        public List<City> City_Get_By_ID()
        {

            
            List<City> lst = new List<City>();
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_City", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            //sc.Parameters.AddWithValue("@City_ID", 0);
            //sc.Parameters.AddWithValue("@City_Name", null);
           
            sc.Parameters.AddWithValue("@State_ID", this.State_ID);
            sc.Parameters.AddWithValue("@Query",5);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                City cc = new City();
                cc.City_ID = (int)sdr["City_ID"];
                cc.City_Name = (string)sdr["City_Name"];
                cc.State_ID = (int)sdr["State_ID"];
                lst.Add(cc);
            }
            sdr.Close();

            return lst;
        }
        public void City_Add()
        {
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_City", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@City_Name", City_Name);
            sc.ExecuteNonQuery();

        }
        public void State_Update()
        {
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_City", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@City_ID", City_ID);
            sc.Parameters.AddWithValue("@City_Name", City_Name);
            sc.Parameters.AddWithValue("@State_ID", State_ID);
            sc.ExecuteNonQuery();
        }
        public void State_Delete()
        {
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_City", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@City_ID", City_ID);
            sc.ExecuteNonQuery();
        }
    }
}