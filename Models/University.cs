using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FYP1.Models
{
    public class University
    {
        #region Data Set
        public List<int> U_ID { get; set; } = new List<int>();
        public List<string> Name { get; set; } = new List<string>();
        public List<string> City { get; set; } = new List<string>();
        public List<int> Enrollment { get; set; } = new List<int>();
        public List<int> ActAvg { get; set; } = new List<int>();
        public List<int> SatAvg { get; set; } = new List<int>();
        public List<int> AcceptanceRate { get; set; } = new List<int>();
        public List<int> PercentReceivingAid { get; set; } = new List<int>();
        public List<int> CostAfterAid { get; set; } = new List<int>();
        public List<int> TuitionFee { get; set; } = new List<int>();
        public List<int> Rank { get; set; } = new List<int>();
        public List<int> Control { get; set; } = new List<int>();
        public List<string> Photo_URL { get; set; } = new List<string>();
        #endregion
        #region Upper Bond
        public long UB_ActAvg { get; set; }
        public long UB_SatAvg { get; set; }
        public long UB_AcceptanceRate { get; set; }
        public long UB_PercentReceivingAid { get; set; }
        public long UB_CostAfterAid { get; set; }
        public long UB_TuitionFee { get; set; }
        public long UB_Rank { get; set; }
        public long UB_Control { get; set; }
        #endregion
        #region Data Set
        public List<decimal> FV_ActAvg { get; set; } = new List<decimal>();
        public List<decimal> FV_SatAvg { get; set; } = new List<decimal>();
        public List<decimal> FV_AcceptanceRate { get; set; } = new List<decimal>();
        public List<decimal> FV_PercentReceivingAid { get; set; } = new List<decimal>();
        public List<decimal> FV_CostAfterAid { get; set; } = new List<decimal>();
        public List<decimal> FV_TuitionFee { get; set; } = new List<decimal>();
        public List<decimal> FV_Rank { get; set; } = new List<decimal>();
        public List<decimal> FV_Control { get; set; } = new List<decimal>();
        #endregion
        List<University_View> universities = new List<University_View>();
        //public void GetData()
        //{
        //    SqlCommand sc = new SqlCommand("Select * FROM University", Connection.GetConnection());
        //    SqlDataReader sdr = sc.ExecuteReader();
        //    while (sdr.Read())
        //    {
        //        University_View u = new University_View();
        //        u.P_U_ID = (int)(sdr[0] == null ? 0 : sdr[0]);
        //        u.P_Name = (string)(sdr[1] == null ? "none" : sdr[1]);
        //        u.P_City = (string)(sdr[2] == null ? "none" : sdr[2]);
        //        u.P_Enrollment = ((int)(sdr.IsDBNull(3) ? 0 : sdr[3]));
        //        u.P_ActAvg = ((int)(sdr.IsDBNull(4) ? 0 : sdr[4]));
        //        u.P_SatAvg = ((int)(sdr.IsDBNull(5) ? 0 : sdr[5]));
        //        u.P_AcceptanceRate = ((int)(sdr.IsDBNull(6) ? 0 : sdr[6]));
        //        u.P_PercentReceivingAid = ((int)(sdr.IsDBNull(7) ? 0 : sdr[7]));
        //        u.P_CostAfterAid = ((int)(sdr.IsDBNull(8) ? 0 : sdr[8]));
        //        u.P_TuitionFee = ((int)(sdr[9] == null ? 0 : sdr[9]));
        //        u.P_Rank = ((int)(sdr[10] == null ? 0 : sdr[10]));
        //        u.P_Photo_URL = ((string)(sdr.IsDBNull(12) ? "none" : sdr[12]));
        //        string control = (string)(sdr[11] == null ? "none" : sdr[11]);
        //        if (control == "public")
        //        {
        //            Control.Add(1);
        //            u.P_Control = 1;
        //        }
        //        else
        //        {
        //            Control.Add(0);
        //            u.P_Control = 0;
        //        }

        //        U_ID.Add(u.P_U_ID);
        //        Name.Add(u.P_Name);
        //        City.Add(u.P_City);
        //        Enrollment.Add(u.P_Enrollment);
        //        ActAvg.Add(u.P_ActAvg);
        //        SatAvg.Add(u.P_SatAvg);
        //        AcceptanceRate.Add(u.P_AcceptanceRate);
        //        PercentReceivingAid.Add(u.P_PercentReceivingAid);
        //        CostAfterAid.Add(u.P_CostAfterAid);
        //        TuitionFee.Add(u.P_TuitionFee);
        //        Rank.Add(u.P_Rank);
        //        Photo_URL.Add(u.P_Photo_URL);

        //        universities.Add(u);
        //    }
        //    sdr.Close();
        //}
        public long getUpperBound(List<int> u)
        {
            long max = u[0];
            for (int i = 1; i < u.Count; i++)
            {
                long value = u[i];
                if (value > max)
                {
                    max = value;
                }
            }
            return max + Convert.ToInt64(Math.Round(max * 0.1));
        }
        public List<decimal> getFuzzyValues(List<int> u, long UpperBond, bool isDecrease)
        {
            List<decimal> lst = new List<decimal>();
            foreach (var item in u)
            {
                if (isDecrease)
                {
                    lst.Add(1 - (Convert.ToDecimal(item) / Convert.ToDecimal(UpperBond)));
                }
                else
                {
                    decimal d = Convert.ToDecimal(item) / Convert.ToDecimal(UpperBond);
                    lst.Add(d);
                }
            }
            return lst;
        }

        public void FuzzyLogic()
        {
            for (int i = 0; i < U_ID.Count; i++)
            {
                decimal sum = (FV_ActAvg[i] + FV_SatAvg[i] + FV_AcceptanceRate[i] + FV_PercentReceivingAid[i] + FV_CostAfterAid[i] + FV_TuitionFee[i] + FV_Rank[i] + FV_Control[i]);
                universities[i].Priority = sum / 8;
            }
        }
        //public List<string> GetCities()
        //{
        //    List<string> cities = new List<string>();
        //    SqlCommand sc = new SqlCommand("SELECT Distinct City FROM University", Connection.GetConnection());
        //    SqlDataReader sdr = sc.ExecuteReader();
        //    while (sdr.Read())
        //    {
        //        cities.Add((string)sdr[0]);
        //    }
        //    sdr.Close();
        //    return cities;
        //}
        public List<University_View> Sort()
        {
            return this.universities.OrderBy(x => x.Priority).ToList();
        }
    }
    public class University_View
    {
        public decimal Priority { get; set; }

        #region Properties
        public int P_U_ID { get; set; }
        public string P_Name { get; set; }
        public string P_City { get; set; }
        public int P_Enrollment { get; set; }
        public int P_ActAvg { get; set; }
        public int P_SatAvg { get; set; }
        public int P_AcceptanceRate { get; set; }
        public int P_PercentReceivingAid { get; set; }
        public int P_CostAfterAid { get; set; }
        public int P_TuitionFee { get; set; }
        public int P_Rank { get; set; }
        public int P_Control { get; set; }
        public string P_Photo_URL { get; set; }
        #endregion

    }

}