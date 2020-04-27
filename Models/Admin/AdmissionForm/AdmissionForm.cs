using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using FYP1.Models.Institute;
namespace FYP1.Models.Admin.AdmissionForm
{
    public class AdmissionForm
    {
        public int Query { get; set; }
        public int Admission_id { get; set; }
        public int S_ID { get; set; }
        public int Degree_ID { get; set; }

        public List<Admission_Institute> Inst_List { get; set; }
        public int Admission_Add()
        {   


            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_AdmissionForm", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@S_ID", S_ID); // seshan se uth k aarai hai or view mei hide karwadi
            sc.Parameters.AddWithValue("@Degree_ID", Degree_ID);
            sc.Parameters.AddWithValue("@Query", 1);
            object id = sc.ExecuteScalar();
            return Convert.ToInt32((decimal)id);
        }
    }
    public class Admission_Institute
    {
        public int AI_ID { get; set; }
        public int I_ID { get; set; }
        public int A_ID { get; set; }
        public int Status_ID { get; set; }
        public string Payment_Info { get; set; }
        public void Add()
        {
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_AdmissionInstitute", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@A_ID", A_ID); 
            sc.Parameters.AddWithValue("@I_ID", I_ID);
            sc.Parameters.AddWithValue("@Query", 1);
            object id = sc.ExecuteScalar();
         }
      public string Pay()
        {
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_AdmissionInstitute", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@AI_ID", AI_ID);
            sc.Parameters.AddWithValue("@Status", 2);
            sc.Parameters.AddWithValue("@Query", 2);
            SqlDataReader sdr =sc.ExecuteReader();
            while (sdr.Read())
            {
                Payment_Info=(string)sdr[0];
            }
            sdr.Close();
            return Payment_Info;
        }
        public void Response()
        {
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_AdmissionInstitute", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@AI_ID", AI_ID);
            sc.Parameters.AddWithValue("@Status", Status_ID);
            sc.Parameters.AddWithValue("@Query",2);
            sc.ExecuteNonQuery();
        }
    }



}