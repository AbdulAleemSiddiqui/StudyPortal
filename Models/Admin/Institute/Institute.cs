
using DatabaseTVP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FYP1.Models.Institute
{
    public class Institute
    {
        [DisplayName("Instiitute ID")]
        public int Institute_ID { get; set; }
        [DisplayName("Institute Name")]
        public string Institute_Name { get; set; }
        [DisplayName("Institute Reg No")]
        public string Institute_RegNo { get; set; }
        [DisplayName("Institute EstablishYear")]
        public DateTime Institute_EstablishYear { get; set; }
        public int InstituteType_ID { get; set; }
        [DisplayName("Institute Affilation")]
        public string Institute_Affilation { get; set; }
        public int Query { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public bool EmailConfirmation { get; set; }
        [DataType(DataType.Password)]

        public string Password { get; set; }
        public string Institute_img { get; set; }
        [DataType(DataType.MultilineText)]
        public string Payment_Info { get; set; }
        public string Website_Link { get; set; }
        public int Alumni_Rating { get;  set; }
        public string Advertisement_Img { get; set; }

        public HttpPostedFileBase Prop { get; set; }
        public HttpPostedFileBase Prop2 { get; set; }
        public List<Institute> Institute_Get_All()
        {
            List<Institute> lst = new List<Institute>();
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_Institute", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@Query", 4);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                Institute u = new Institute();
                u.Institute_ID = (int)sdr["Institute_ID"];
                u.Institute_Name = (string)sdr["Institute_Name"];
                u.Institute_RegNo = (string)sdr["Institute_RegNo"];
                u.Institute_EstablishYear = (DateTime)sdr["Institute_EstablishYear"];
                u.InstituteType_ID = (int)sdr["InstituteType_ID"];
                u.Institute_Affilation = (string)sdr["Institute_Affilation"];
                u.start_date = (DateTime)sdr["start_date"];
                u.end_date = (DateTime)sdr["end_date"];
                u.Email = (string)sdr["Email"];
                u.EmailConfirmation = (bool)sdr["EmailConfirmation"];
                u.Password = (string)sdr["Password"];
                u.Institute_img = (string)sdr["Institute_img"];
                u.Payment_Info = (string)sdr["Payment_Info"];
                u.Website_Link= (string)sdr["Website_Link"];
                u.Alumni_Rating = (int)sdr["Alumni_Rating"];
                u.Advertisement_Img= (string)sdr["Advertisement_Img"];
                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }
        public Institute Institute_Get_By_ID()
        {
            Institute u = new Institute();
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_Institute", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@Institute_ID", Institute_ID);
            sc.Parameters.AddWithValue("@Query", 5);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                u.Institute_ID = (int)sdr["Institute_ID"];
                u.Institute_Name = (string)sdr["Institute_Name"];
                u.Institute_RegNo = (string)sdr["Institute_RegNo"];
                u.Institute_EstablishYear = (DateTime)sdr["Institute_EstablishYear"];
                u.InstituteType_ID = (int)sdr["InstituteType_ID"];
                u.Institute_Affilation = (string)sdr["Institute_Affilation"];
                u.start_date = (DateTime)sdr["start_date"];
                u.end_date = (DateTime)sdr["end_date"];
                u.Email = (string)sdr["Email"];
                u.EmailConfirmation = (bool)sdr["EmailConfirmation"];
                u.Password = (string)sdr["Password"];
                u.Institute_img = (string)sdr["Institute_img"];
                u.Payment_Info = (string)sdr["Payment_Info"];
                u.Website_Link = (string)sdr["Website_Link"];
                u.Alumni_Rating = (int)sdr["Alumni_Rating"];
                u.Advertisement_Img = (string)sdr["Advertisement_Img"];
            }
            sdr.Close();
            return u;
        }

        public void Institute_Add()
        {
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_Institute", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@InstituteType_ID", InstituteType_ID);
            sc.Parameters.AddWithValue("@Institute_Name", Institute_Name);
            sc.Parameters.AddWithValue("@Institute_RegNo", Institute_RegNo);
            sc.Parameters.AddWithValue("@Institute_EstablishYear", Institute_EstablishYear);
            sc.Parameters.AddWithValue("@Institute_Affilation", Institute_Affilation);
            sc.Parameters.AddWithValue("@start_date", start_date);
            sc.Parameters.AddWithValue("@end_date", end_date);
            sc.Parameters.AddWithValue("@Institute_img", Institute_img);
            sc.Parameters.AddWithValue("@Email", Email);
            sc.Parameters.AddWithValue("@EmailConfirmation", EmailConfirmation);
            sc.Parameters.AddWithValue("@Password", Password);
            sc.Parameters.AddWithValue("@Payment_Info", Payment_Info);
            sc.Parameters.AddWithValue("@Website_Link", Website_Link);
            sc.Parameters.AddWithValue("@Adversitement_Img", Advertisement_Img);
            sc.Parameters.AddWithValue("@Query", 1);

            sc.ExecuteNonQuery();

        }
        public void Institute_Update()
        {
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_Institute", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@Institute_ID", Institute_ID);
            sc.Parameters.AddWithValue("@InstituteType_ID", InstituteType_ID);
            sc.Parameters.AddWithValue("@Institute_Name", Institute_Name);
            sc.Parameters.AddWithValue("@Institute_RegNo", Institute_RegNo);
            sc.Parameters.AddWithValue("@Institute_EstablishYear", Institute_EstablishYear);
            sc.Parameters.AddWithValue("@Institute_Affilation", Institute_Affilation);
            sc.Parameters.AddWithValue("@start_date", start_date);
            sc.Parameters.AddWithValue("@end_date", end_date);
            sc.Parameters.AddWithValue("@Institute_img", Institute_img);
            sc.Parameters.AddWithValue("@Email", Email);
            sc.Parameters.AddWithValue("@Password", Password);
            sc.Parameters.AddWithValue("@Payment_Info", Payment_Info);
            sc.Parameters.AddWithValue("@Website_Link", Website_Link);
            sc.Parameters.AddWithValue("@Adversitement_Img", Advertisement_Img);
            sc.Parameters.AddWithValue("@Query", 2);

            sc.ExecuteNonQuery();
        }
        public void Institute_Delete()
        {
            SqlCommand sc = new SqlCommand("Usp_InsertUpdateDelete_Institute", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@Institute_ID", Institute_ID);
            sc.ExecuteNonQuery();
        }

        public List<Institute> Institute_Get_By_Deprt(int D_ID)
        {
            List<Institute> lst = new List<Institute>();
            SqlCommand sc = new SqlCommand("Institute_Get_By_Deprt", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@D_ID", D_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                Institute u = new Institute();
                u.Institute_ID = (int)sdr["Institute_ID"];
                u.Institute_Name = (string)sdr["Institute_Name"];
                u.Institute_RegNo = (string)sdr["Institute_RegNo"];
                u.Institute_EstablishYear = (DateTime)sdr["Institute_EstablishYear"];
                u.InstituteType_ID = (int)sdr["InstituteType_ID"];
                u.Institute_Affilation = (string)sdr["Institute_Affilation"];
                u.start_date = (DateTime)sdr["start_date"];
                u.end_date = (DateTime)sdr["end_date"];
                u.Institute_img = (string)sdr["Institute_img"];
                u.Website_Link= (string)sdr["Website_Link"];
                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }
        public List<Institute> Institute_Get_By_Degree(int Degree_ID)
        {
            List<Institute> lst = new List<Institute>();
            SqlCommand sc = new SqlCommand("Institute_Get_By_Degree", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@Degree_ID", Degree_ID);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                Institute u = new Institute();
                u.Institute_ID = (int)sdr["Institute_ID"];
                u.Institute_Name = (string)sdr["Institute_Name"];
                u.Institute_RegNo = (string)sdr["Institute_RegNo"];
                u.Institute_EstablishYear = (DateTime)sdr["Institute_EstablishYear"];
                u.InstituteType_ID = (int)sdr["InstituteType_ID"];
                u.Institute_Affilation = (string)sdr["Institute_Affilation"];
                u.start_date = (DateTime)sdr["start_date"];
                u.end_date = (DateTime)sdr["end_date"];
                u.Institute_img = (string)sdr["Institute_img"];
               // u.Website_Link = (string)sdr["Website_Link"];
                lst.Add(u);
            }
            sdr.Close();
            return lst;
        }
        public int Institute_Login()
        {
            try
            {
                //place your Model Logic and DB Calls here:
                int I_ID = DataBase.ExecuteQuery<Institute>(new { x = this.Email, x2 = this.Password }, Connection.Get()).FirstOrDefault().Institute_ID;
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except 1), PageName, Module (for Multiple Areas), Connection to Log DB, 1
                Logger.Logging.DB_Log(Logger.eLogType.Log_Positive, "", new { x = this }, "", "", Connection.GetLogConnection(), 1);
                return I_ID;
            }
            catch (Exception ex)
            {
                // Logging Here=> Type of Log, Message, Data (complete objects or paramters except 1), PageName, Module (for Multiple Areas), Connection to Log DB, 1
                Logger.Logging.DB_Log(Logger.eLogType.Log_Negative, ex.Message, new { x = this }, "", "", Connection.GetLogConnection(), 1);
                return 0;
            }
        }
    }
}