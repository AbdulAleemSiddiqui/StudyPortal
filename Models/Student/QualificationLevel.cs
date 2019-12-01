using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FYP1.Models;
using System.Data.SqlClient;

namespace FYP1.Models.Student
{

    public class QualificationLevel
    {
        public int QLevel_ID { get; set; }
        public string Qualification_Level { get; set; }





        public List<QualificationLevel> QualificationLevel_Get_All()
        {
            List<QualificationLevel> lst = new List<QualificationLevel>();
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_QualificationLevel", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@QLevel_ID", 0);
            sc.Parameters.AddWithValue("@Qualification_Level", null);
            sc.Parameters.AddWithValue("@Query", 4);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                QualificationLevel u = new QualificationLevel();
                u.QLevel_ID = (int)sdr["QLevel_ID"];
                u.Qualification_Level = (string)sdr["Qualification_Level"];

                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }
        public QualificationLevel QualificationLevel_Get_By_ID()
        {
            QualificationLevel u = new QualificationLevel();
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_QualificationLevel", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@QLevel_ID", QLevel_ID);
            sc.Parameters.AddWithValue("@Query", 1);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                u.QLevel_ID = (int)sdr["QLevel_ID"];
                u.Qualification_Level = (string)sdr["Qualification_Level"];

            }
            sdr.Close();
            return u;
        }

        public void QualificationLevel_Add()
        {
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_QualificationLevel", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@Qualification_Level", Qualification_Level);

            sc.ExecuteNonQuery();

        }
        public void QualificationLevel_Update()
        {
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_QualificationLevel", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@QLevel_ID", QLevel_ID);
            sc.Parameters.AddWithValue("@Qualification_Level", Qualification_Level);


            sc.ExecuteNonQuery();
        }
        public void QualificationLevel_Delete()
        {
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_QualificationLevel", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@QLevel_ID", QLevel_ID);
            sc.ExecuteNonQuery();
        }
    }
}
