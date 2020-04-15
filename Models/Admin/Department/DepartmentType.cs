using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Web;
using System.Data.SqlClient;

namespace FYP1.Models.Department
{
    public class DepartmentType
    {

        public int DepartmentType_ID { get; set; }
        [DisplayName ("Department Type")]
        public string DepartmentType_Name { get; set; }
        public int Query { get; set; }



        public List<DepartmentType> DepartmentType_Get_All()
        {
            List<DepartmentType> lst = new List<DepartmentType>();
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_DepartmentType", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
           
            sc.Parameters.AddWithValue("@Query", 4);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                DepartmentType u = new DepartmentType();
                u.DepartmentType_ID = (int)sdr["DepartmentType_ID"];
                u.DepartmentType_Name = (string)sdr["DepartmentType_Name"];


                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }
        public DepartmentType DepartmentType_Get_By_ID()
        {
            DepartmentType u = new DepartmentType();
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_DepartmentType", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@Dept_ID", DepartmentType_ID);
            sc.Parameters.AddWithValue("@Query", 5);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                u.DepartmentType_ID = (int)sdr["DepartmentType_ID"];
                u.DepartmentType_Name = (string)sdr["DepartmentType_Name"];

            }
            sdr.Close();
            return u;
        }

        public void DepartmentType_Add()
        {
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_DepartmentType", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@Dept_name", DepartmentType_Name);
            sc.Parameters.AddWithValue("@Query", 1);

            sc.ExecuteNonQuery();

        }
        public void DepartmentType_Update()
        {
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_DepartmentType", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@Dept_ID", DepartmentType_ID);
            sc.Parameters.AddWithValue("@Dept_Name", DepartmentType_Name);
            sc.Parameters.AddWithValue("@Query", 2);

            sc.ExecuteNonQuery();
        }
        public void DepartmentType_Delete()
        {
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_DepartmentType", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@Dept_ID", DepartmentType_ID);
            sc.Parameters.AddWithValue("@Query", 3);

            sc.ExecuteNonQuery();
        }
    }
}
