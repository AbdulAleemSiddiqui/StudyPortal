using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FYP1.Models.Institute
{

    public class InstituteType
    {
        public int InstituteType_ID { get; set; }
        public string InstituteType_Name { get; set; }



        public List<InstituteType> InstituteType_Get_All()
        {
            List<InstituteType> lst = new List<InstituteType>();
            SqlCommand sc = new SqlCommand("InstituteType_Get_All", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("Query", 1);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                InstituteType u = new InstituteType();
                u.InstituteType_ID = (int)sdr["InstituteType_ID"];
                u.InstituteType_Name = (string)sdr["InstituteType_Name"];

                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }

    }
}