using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FYP1.Models.Admin;
using System.Data.SqlClient;

namespace FYP1.Models
{
    public class DegreeDuration
    {
        public int DegreeDuration_ID { get; set; }
        public string DegreeDuration_Name { get; set; }

        public List<DegreeDuration> DegreeDuration_Get_All()
        {
            List<DegreeDuration> lst = new List<DegreeDuration>();
            SqlCommand sc = new SqlCommand("DegreeDuration_Get_All", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@Query", 1);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                DegreeDuration dd = new DegreeDuration();
                dd.DegreeDuration_ID = (int)sdr["DegreeDuration_ID"];
             dd.DegreeDuration_Name = (string)sdr["DegreeDuration_Name"];
                

                lst.Add(dd);
            }
            sdr.Close();
            return lst;
        }
    }
}