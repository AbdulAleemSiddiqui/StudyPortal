using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FYP1.Models.Admin
{
    public class InstituteDepartment
    {
        public int InstituteDepartment_ID { get; set; }
        public int InsCampus_ID { get; set; }
        
        public int Department_ID { get; set; }
        public int DegreeLevel_ID { get; set; }
        public int DegreeDuration_ID { get; set; }



        public List<InstituteDepartment> Institute_Get_All()
        {
            List<InstituteDepartment> lst = new List<InstituteDepartment>();
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_Institute", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@Query", 4);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                InstituteDepartment ID = new InstituteDepartment();
                ID.InsCampus_ID = (int)sdr["InsCampus_ID"];
                ID.Department_ID = (int)sdr["Department_ID"];
                ID.DegreeLevel_ID = (int)sdr["DegreeLevel_ID"];
                ID.DegreeDuration_ID = (int)sdr["DegreeDuration_ID"];
                


                lst.Add(ID);
            }
            sdr.Close();
            return lst;
        }
        public InstituteDepartment InstituteDepartment_Get_By_ID()
        {
            InstituteDepartment ID = new InstituteDepartment();
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_InstituteDepartment", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@InstituteDepartment_ID", InstituteDepartment_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                ID.InsCampus_ID = (int)sdr["InsCampus_ID"];
                ID.Department_ID = (int)sdr["Department_ID"];
                ID.DegreeLevel_ID = (int)sdr["DegreeLevel_ID"];
                ID.DegreeDuration_ID = (int)sdr["DegreeDuration_ID"];

            }
            sdr.Close();
            return ID;
        }

        public void InstituteDepartment_Add()
        {
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_InstituteDepartment", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@InstituteDepartment_ID", 0);
            sc.Parameters.AddWithValue("@InsCampus_ID", InsCampus_ID);
            sc.Parameters.AddWithValue("@Department_ID", Department_ID);
            sc.Parameters.AddWithValue("@DegreeLevel_ID", DegreeLevel_ID);
            sc.Parameters.AddWithValue("@DegreeDuration_ID", DegreeDuration_ID);
          
            sc.Parameters.AddWithValue("@Query", 1);

            sc.ExecuteNonQuery();

        }
        public void InstituteDepartment_Update()
        {
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_InstituteDepartment", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@InsCampus_ID", InsCampus_ID);
            sc.Parameters.AddWithValue("@Department_ID", Department_ID);
            sc.Parameters.AddWithValue("@DegreeLevel_ID", DegreeLevel_ID);
            sc.Parameters.AddWithValue("@DegreeDuration_ID", DegreeDuration_ID);


            sc.ExecuteNonQuery();
        }
        public void InstituteDepartment_Delete()
        {
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_InstituteDepartment", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@InstituteDepartment_ID", InstituteDepartment_ID);
            sc.ExecuteNonQuery();
        }


    }
}