using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace FYP1.Models
{
    public class Chat
    {
        public int S_ID { get; set; }
        public int Institute_ID { get; set; }

        public string Student_Name { get; set; }
        public string Institute_Name { get; set; }


        public string ConnectionID { get; set; }
        public List<Chat> studentbyid()
        {
            List<Chat> lst = new List<Chat>();
            SqlCommand sc = new SqlCommand("Usp_Chat", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@Institute_ID", Institute_ID);
            sc.Parameters.AddWithValue("@Query", 2);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                Chat u = new Chat();
                u.S_ID = (int)sdr["S_ID"];
                u.Student_Name = (string)sdr["Student_Name"];
                u.Institute_Name = (string)sdr["Institute_Name"];
                u.Institute_ID = (int)sdr["Institute_ID"];
                u.ConnectionID = (string)sdr["ConnectionID"].ToString();

                lst.Add(u);

            }
            sdr.Close();
            return lst;

        }

        public List<Chat> institutebyid()
        {
            List<Chat> lts = new List<Chat>();
            SqlCommand sc = new SqlCommand("Usp_Chat", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@S_ID", S_ID);
            sc.Parameters.AddWithValue("@Query", 1);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                Chat u = new Chat();
                u.Institute_ID = (int)sdr["Institute_ID"];
                u.Institute_Name = (string)sdr["Institute_Name"];
                u.Student_Name = (string)sdr["Student_Name"];
                u.S_ID = (int)sdr["Student_ID"];
                u.ConnectionID = (string)sdr["ConnectionID"].ToString();
                lts.Add(u);

            }
            sdr.Close();
            return lts;

        }
        public void IConnectionID_Update()
        {
            SqlCommand sc = new SqlCommand("Usp_Chat", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@Query", 4);
            sc.Parameters.AddWithValue("@Institute_ID", Institute_ID);
            sc.Parameters.AddWithValue("@ConnectionID", ConnectionID);
            sc.ExecuteNonQuery();
        }
        public void SConnectionID_Update()
        {
            SqlCommand sc = new SqlCommand("Usp_Chat", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@Query", 3);
            sc.Parameters.AddWithValue("@S_ID", S_ID);
            sc.Parameters.AddWithValue("@ConnectionID", ConnectionID);
            sc.ExecuteNonQuery();
        }

        public string get_con_for_student(int a)
        {
            SqlCommand sc = new SqlCommand("Usp_Chat", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@Query", 5);
            sc.Parameters.AddWithValue("S_ID", a);
            SqlDataReader sdr = sc.ExecuteReader();
            Chat u = new Chat();

            while (sdr.Read())
            {

                u.ConnectionID = (string)sdr["ConnectionID"].ToString();


            }
            sdr.Close();
            return u.ConnectionID;
        }
        public string get_con_for_institute(int a)
        {
            SqlCommand sc = new SqlCommand("Usp_Chat", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@Query", 6);
            sc.Parameters.AddWithValue("Institute_ID", a);
            SqlDataReader sdr = sc.ExecuteReader();
            Chat u = new Chat();

            while (sdr.Read())
            {

                u.ConnectionID = (string)sdr["ConnectionID"].ToString();


            }
            sdr.Close();
            return u.ConnectionID;
        }
    }
}