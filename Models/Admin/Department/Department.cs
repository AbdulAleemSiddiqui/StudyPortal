using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.ComponentModel;

namespace FYP1.Models.Department
{
    public class Department
    {

        public int Department_ID { get; set; }
        public string Department_Name { get; set; }
        [DisplayName("Department Type")]
        public int DepartmentType_ID { get; set; }

        public string DepartmentType_Name { get; set; }

        public int Query { get; set; }


        public List<Department> Department_Get_All()
        {
            List<Department> lst = new List<Department>();
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_Department", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@Query", 4);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                Department u = new Department();
                u.Department_ID = (int)sdr["Department_ID"];
                u.Department_Name = (string)sdr["Department_Name"];
                u.DepartmentType_ID = (int)sdr["DepartmentType_ID"];
                u.DepartmentType_Name = (string)sdr["DepartmentType_Name"];


                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }
        public Department Department_Get_By_ID()
        {
            Department u = new Department();
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_Department", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@Department_ID", this.Department_ID);
            sc.Parameters.AddWithValue("@Query", 5);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                u.Department_ID = (int)sdr["Department_ID"];
                u.Department_Name = (string)sdr["Department_Name"];
                u.DepartmentType_ID = (int)sdr["DepartmentType_ID"];


            }
            sdr.Close();
            return u;
        }

        public void Department_Add()
        {
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_Department", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@Department_Name", this.Department_Name);
            sc.Parameters.AddWithValue("@DepartmentType_ID", this.DepartmentType_ID);
            sc.Parameters.AddWithValue("@Query", 1);

            sc.ExecuteNonQuery();

        }
        public void Department_Update()
        {
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_Department", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@Department_ID", this.Department_ID);
            sc.Parameters.AddWithValue("@Department_Name", this.Department_Name);
            sc.Parameters.AddWithValue("@DepartmentType_ID", this.DepartmentType_ID);
            sc.Parameters.AddWithValue("@Query", 2);

            sc.ExecuteNonQuery();
        }
        public void Department_Delete()
        {
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_Department", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@Department_ID", this.Department_ID);
            sc.Parameters.AddWithValue("@Query", 3);

            sc.ExecuteNonQuery();
        }

        public List<Department> DepartmentAndType_Get_All()
        {
            List<Department> lst = new List<Department>();
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_Department", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@Query", 4);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                Department u = new Department();
                u.Department_ID = (int)sdr["Department_ID"];
                u.Department_Name = (string)sdr["Department_Name"];
                u.DepartmentType_ID = (int)sdr["DepartmentType_ID"];
                u.DepartmentType_Name = (string)sdr["DepartmentType_Name"];


                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }

    }
}