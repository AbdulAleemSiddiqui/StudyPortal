using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;

namespace FYP1.Models
{
    public class Connection
    {
        static SqlConnection c;
        static SqlConnection c_log;
        public static SqlConnection Get()
        {
            if (c == null ||c.State==System.Data.ConnectionState.Closed|| c.State != System.Data.ConnectionState.Connecting)
            {
                c = new SqlConnection();
                c.ConnectionString = ConfigurationManager.ConnectionStrings["FYPSTUDYPORTALEntities"].ToString();
                c.Open();
            }
            return c;
        }
        public static SqlConnection GetLogConnection()
        {
            if (c_log == null)
            {
                c_log = new SqlConnection();
                c_log.ConnectionString = ConfigurationManager.ConnectionStrings["FYP_Log"].ToString();
                c_log.Open();
            }
            return c_log;
        }
     //   static SqlConnection ssc = null;
        //public static SqlConnection GetConnection()
        //{
        //    if (ssc == null)
        //    {
        //        ssc = new SqlConnection();
        //        ssc.ConnectionString = @"Data Source=DESKTOP-Q78RQP5\SQLEXPRESS;Initial Catalog=University_DataSet;Integrated Security=True";
        //        ssc.Open();
        //    }
        //    return ssc;
        //}
    }
}