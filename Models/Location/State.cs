using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace FYP1.Models.Location
{
    public class State
    {

        public int State_ID { get; set; }
        public string State_Name { get; set; }
        public List<State> State_Get_All()
        {
            List<State> lst = new List<State>();
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_State", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            //sc.Parameters.AddWithValue("@State_ID", 0);
            //sc.Parameters.AddWithValue("@State_Name", null);
            sc.Parameters.AddWithValue("@Query", 4);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                State s = new State();
                s.State_ID = (int)sdr["State_ID"];
                s.State_Name = (string)sdr["State_Name"];
                lst.Add(s);
            }
            sdr.Close();
            return lst;
        }
        public State State_Get_By_ID()
        {
            State s = new State();
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_State", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@State_ID", State_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                s.State_ID = (int)sdr["State_ID"];
                s.State_Name = (string)sdr["State_Name"];
            }
            sdr.Close();
            return s;
        }
        public void State_Add()
        {
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_State", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@State_Name", State_Name);
            sc.ExecuteNonQuery();

        }
        public void State_Update()
        {
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_State", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@State_ID", State_ID);
            sc.Parameters.AddWithValue("@State_Name", State_Name);
            sc.ExecuteNonQuery();
        }
        public void State_Delete()
        {
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_State", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@State_ID", State_ID);
            sc.ExecuteNonQuery();
        }
    }
}