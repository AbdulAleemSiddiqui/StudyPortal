using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Web;

namespace FYP1.Models.Institute
{
    public class InstituteCampus
    {
        public int Query { get; set; }
        public int InsCampus_ID { get; set; }

        public int Institute_ID { get; set; }
      
        public string Institute_Name { get; set; }
        public string InsCampus_Area { get; set; }
        public string InsCampus_Address { get; set; }
        public int InsCampus_PhoneNo { get; set; }
        public string InsCampus_EmailID { get; set; }
        public string InsCampus_EstablishYear { get; set; }
        

        public List<InstituteCampus> InstituteCampus_Get_All()
        {
            List<InstituteCampus> lst = new List<InstituteCampus>();
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_InstituteCampus", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@Query",4);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                InstituteCampus u = new InstituteCampus();
                u.InsCampus_ID = (int)sdr["InsCampus_ID"];
                u.Institute_ID = (int)sdr["Institute_ID"];
                u.InsCampus_Area = (string)sdr["InsCampus_Area"];
                u.InsCampus_Address = (string)sdr["InsCampus_Address"];
                u.Institute_Name = (string)sdr["Institute_Name"];
                u.InsCampus_PhoneNo = (int)sdr["InsCampus_PhoneNo"];
                u.InsCampus_EmailID = (string)sdr["InsCampus_EmailID"];
                u.InsCampus_EstablishYear = (string)sdr["InsCampus_EstablishYear"];

                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }
        public InstituteCampus InstituteCampus_Get_By_ID()
        {
            InstituteCampus u = new InstituteCampus();
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_InstituteCampus", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@InsCampus_ID", InsCampus_ID);
            sc.Parameters.AddWithValue("@Query", Query);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                u.InsCampus_ID = (int)sdr["InsCampus_ID"];
                u.Institute_ID = (int)sdr["Institute_ID"];
                u.InsCampus_Area = (string)sdr["InsCampus_Area"];
                u.InsCampus_Address = (string)sdr["InsCampus_Address"];
                u.InsCampus_PhoneNo = (int)sdr["InsCampus_PhoneNo"];
                u.InsCampus_EmailID = (string)sdr["InsCampus_EmailID"];
                u.InsCampus_EstablishYear = (string)sdr["InsCampus_EstablishYear"];
                u.Institute_Name = (string)sdr["Institute_Name"];

            }
            sdr.Close();
            return u;
        }

        public void InstituteCampus_Add()
        {
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_InstituteCampus", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@Institute_ID", Institute_ID);
            sc.Parameters.AddWithValue("@InsCampus_Area", InsCampus_Area);
            sc.Parameters.AddWithValue("@InsCampus_Address", InsCampus_Address);
            sc.Parameters.AddWithValue("@InsCampus_PhoneNo", InsCampus_PhoneNo);
            sc.Parameters.AddWithValue("@InsCampus_EmailID", InsCampus_EmailID);
            sc.Parameters.AddWithValue("@InsCampus_EstablishYear", InsCampus_EstablishYear);

            sc.Parameters.AddWithValue("@Query", 1);
            
            sc.ExecuteNonQuery();

        }
        public void InstituteCampus_Update()
        {
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_InstituteCampus", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@Institute_ID", Institute_ID);
            sc.Parameters.AddWithValue("@InsCampus_ID", InsCampus_ID);
            sc.Parameters.AddWithValue("@InsCampus_Area", InsCampus_Area);
            sc.Parameters.AddWithValue("@InsCampus_Address", InsCampus_Address);
            sc.Parameters.AddWithValue("@InsCampus_PhoneNo", InsCampus_PhoneNo);
            sc.Parameters.AddWithValue("@InsCampus_EmailId", InsCampus_EmailID);
            sc.Parameters.AddWithValue("@InsCampus_EstablishYear", InsCampus_EstablishYear);
            
            sc.ExecuteNonQuery();
        }
        public void InstituteCampus_Delete()
        {
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_InstituteCampus", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@InsCampus_ID", InsCampus_ID);
            sc.ExecuteNonQuery();
        }
    }
}
