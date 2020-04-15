using System;
using System.Collections.Generic;
using FYP1.Models;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FYP1.Models
{
    public class DegreeLevel
    {


        public int DegreeLevel_ID { get; set; }
        public string DegreeLevel_Name { get; set; }




        public List<DegreeLevel> DegreeLevel_Get_All()
        {
            List<DegreeLevel> lst = new List<DegreeLevel>();
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_DegreeLevel", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@Query", 4);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                DegreeLevel u = new DegreeLevel();
                u.DegreeLevel_ID = (int)sdr["DegreeLevel_ID"];
                u.DegreeLevel_Name = (string)sdr["DegreeLevel_Name"];


                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }
        public DegreeLevel DegreeLevel_Get_By_ID()
        {
                        DegreeLevel u = new DegreeLevel();
                        SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_DegreeLevel", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
                        sc.Parameters.AddWithValue("@DegreeLevel_ID", DegreeLevel_ID);
                        sc.Parameters.AddWithValue("@Query",5);
                        SqlDataReader sdr = sc.ExecuteReader();
                        while (sdr.Read())
                        {
                            u.DegreeLevel_ID = (int)sdr["DegreeLevel_ID"];
                            u.DegreeLevel_Name = (string)sdr["DegreeLevel_Name"];


                        }
                        sdr.Close();
                        return u;
        }

        public void DegreeLevel_Add()
        {
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_DegreeLevel", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@DegreeLevel_Name", DegreeLevel_Name);

            sc.Parameters.AddWithValue("@Query", 1);

            sc.ExecuteNonQuery();

        }
        public void DegreeLevel_Update()
        {
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_DegreeLevel", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@DegreeLevel_ID", DegreeLevel_ID);
            sc.Parameters.AddWithValue("@DegreeLevel_Name", DegreeLevel_Name);

            sc.Parameters.AddWithValue("@Query", 2);

            sc.ExecuteNonQuery();
        }
        public void DegreeLevel_Delete()
        {
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_DegreeLevel", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@Query", 3);
            sc.Parameters.AddWithValue("@DegreeLevel_ID", DegreeLevel_ID);
            sc.ExecuteNonQuery();
        }
    }
}
