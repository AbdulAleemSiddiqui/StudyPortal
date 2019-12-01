using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FYP1.Models;
using System.Data.SqlClient;

namespace FYP1.Models.Student
{
    public class Board
    {
        public int Board_ID { get; set; }
        public string Board_Name { get; set; }

        public List<Board> Board_Get_All()
        {
            List<Board> lst = new List<Board>();
            SqlCommand sc = new SqlCommand("Board_Get_All", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@Query", 1);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                Board u = new Board();
                u.Board_ID = (int)sdr["Board_ID"];
                u.Board_Name = (string)sdr["Board_Name"];
                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }
        public Board Board_Get_By_ID()
        {
            Board u = new Board();
            SqlCommand sc = new SqlCommand("Board_Get_By_ID", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@Board_ID", Board_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                u.Board_ID = (int)sdr["Board_ID"];
                u.Board_Name = (string)sdr["Board_Name"];
            }
            sdr.Close();
            return u;
        }
        public void Board_Add()
        {
            SqlCommand sc = new SqlCommand("Board_Add", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@Board_Name", Board_Name);
            sc.ExecuteNonQuery();

        }
        public void Board_Update()
        {
            SqlCommand sc = new SqlCommand("Board_Update", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@Board_ID", Board_ID);
            sc.Parameters.AddWithValue("@Board_Name", Board_Name);
            sc.ExecuteNonQuery();
        }
        public void Board_Delete()
        {
            SqlCommand sc = new SqlCommand("Board_Delete", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@Board_ID", Board_ID);
            sc.ExecuteNonQuery();
        }
    }
}