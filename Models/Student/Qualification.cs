using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FYP1.Models;
using System.Data.SqlClient;

namespace FYP1.Models.Student
{
    public class Qualification
    {
        public int Qualification_ID { get; set; }

        public string Current_Field { get; set; }




        public List<Qualification> Qualification_Get_All()
        {
            List<Qualification> lst = new List<Qualification>();
            SqlCommand sc = new SqlCommand("Qualification_Get_All", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };

            sc.Parameters.AddWithValue("@Query", 1);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                Qualification u = new Qualification();
                u.Qualification_ID = (int)sdr["Qualification_ID"];
                u.Current_Field = (string)sdr["Current_Field"];

                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }
        public Qualification Qualification_Get_By_ID()
        {
            Qualification u = new Qualification();
            SqlCommand sc = new SqlCommand("Qualification_Get_By_ID", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@Qualification_ID", this.Qualification_ID);

            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                u.Qualification_ID = (int)sdr["Qualification_ID"];
                u.Current_Field = (string)sdr["Current_Field"];

            }
            sdr.Close();
            return u;
        }

        public void Qualification_Add()
        {
            SqlCommand sc = new SqlCommand("Qualification_Add", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@Current_Field", Current_Field);

            sc.ExecuteNonQuery();

        }
        public void Qualification_Update()
        {
            SqlCommand sc = new SqlCommand("Qualification_Update", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@ID", Qualification_ID);
            sc.Parameters.AddWithValue("@Current_Field", Current_Field);

            sc.ExecuteNonQuery();
        }
        public void Qualification_Delete()
        {
            SqlCommand sc = new SqlCommand("Qualification_Delete", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@Qualification_ID", Qualification_ID);
            sc.ExecuteNonQuery();
        }
    }
}
