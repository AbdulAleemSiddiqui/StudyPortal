using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FYP1.Models
{
    public class University
    {
        public int University_ID { get; set; }

        public string University_Name { get; set; }
        public int City_ID { get; set; }


        public List<University> University_Get_All()
        {
            List<University> lst = new List<University>();
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_University", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            //sc.Parameters.AddWithValue("@City_ID", 0);
            //sc.Parameters.AddWithValue("@City_Name", null);
            //  sc.Parameters.AddWithValue("@State_ID",0);

            sc.Parameters.AddWithValue("@Query", 4);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                University c = new University();
                c.University_ID = (int)sdr["University_ID"];
                c.University_Name = (string)sdr["University_Name"];
                c.City_ID = (int)sdr["City_ID"];
                lst.Add(c);
            }
            sdr.Close();
            return lst;
        }
        public List<University> University_Get_By_ID()
        {


            List<University> lst = new List<University>();
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_University", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            //sc.Parameters.AddWithValue("@City_ID", 0);
            //sc.Parameters.AddWithValue("@City_Name", null);

            sc.Parameters.AddWithValue("@City_ID", this.City_ID);
            sc.Parameters.AddWithValue("@Query", 5);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                University cc = new University();
                cc.University_ID = (int)sdr["University_ID"];
                cc.University_Name = (string)sdr["University_Name"];
                cc.City_ID = (int)sdr["City_ID"];
                lst.Add(cc);
            }
            sdr.Close();

            return lst;
        }
        public void University_Add()
        {
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_University", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@University_Name", University_Name);
            sc.ExecuteNonQuery();

        }
        public void University_Update()
        {
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_University", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@University_ID", University_ID);
            sc.Parameters.AddWithValue("@University_Name", University_Name);
            sc.Parameters.AddWithValue("@City_ID", City_ID);
            sc.ExecuteNonQuery();
        }
        public void University_Delete()
        {
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_University", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@University_ID", University_ID);
            sc.ExecuteNonQuery();
        }
    }
}