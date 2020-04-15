using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace FYP1.Models
{
    public class Quiz
    {
        public int quiz_question_id { get; set; }

        public int quiz_cat_ques_id { get; set; }

        public string question { get; set; }

        public List<quiz_choice> choicess { get; set; }

        public List<Quiz> get()
        {
            quiz_choice qc = new quiz_choice();

            List<Quiz> ql = new List<Quiz>();
            SqlCommand sc = new SqlCommand("Usp_Quiz_ques_choices", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@Query", 2);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                Quiz q = new Quiz();

                q.quiz_question_id = (int)sdr["quiz_question_id"];
                q.quiz_cat_ques_id = (int)sdr["quiz_cat_ques_id"];
                //     q.quiz_choice_id=(int)sdr["quiz_choice_id"];
                //    q.quiz_ques_id = (int)sdr["quiz_ques_id"];
                q.question = (string)sdr["question"];
                //    q.choices = (string)sdr["choices"];
                // q.is_correct_choice = (bool)sdr["is_correct_choice"];

                q.choicess = qc.Getchoices().Where(a => a.quiz_ques_id == q.quiz_question_id).ToList();

                ql.Add(q);
            }
            sdr.Close();
            return ql;

        }
    }
    public class quiz_choice
    {
        public int quiz_choice_id { get; set; }

        public int quiz_ques_id { get; set; }
        public string choices { get; set; }

        public bool is_correct_choice { get; set; }

        public List<quiz_choice> Getchoices()
        {
            List<quiz_choice> QC = new List<quiz_choice>();
            SqlCommand sc = new SqlCommand("Usp_Quiz_ques_choices", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@Query", 3);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                quiz_choice q = new quiz_choice();
                //  q.quiz_question_id = (int)sdr["quiz_question_id"];
                // q.quiz_cat_ques_id = (int)sdr["quiz_cat_ques_id"];
                q.quiz_choice_id = (int)sdr["quiz_choice_id"];
                q.quiz_ques_id = (int)sdr["quiz_ques_id"];
                // q.question = (string)sdr["question"];
                q.choices = (string)sdr["choices"];
                q.is_correct_choice = (bool)sdr["is_correct_choice"];

                QC.Add(q);
            }
            sdr.Close();
            return QC;




        }

    }

    public class Quiz_user_answer
  {
    public int answer_id { get; set; }
    public int student_id { get; set; }
    public int quiz_ques_id { get; set; }
    public int quiz_choice_id { get; set; }
    public bool Is_correct { get; set; }
    public string answer { get; set; }
    public string best_category { get; set; }
    public int count { get; set; }



    public void Add()
    {

        SqlCommand sc = new SqlCommand("Usp_Quiz_user_answer", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
        sc.Parameters.AddWithValue("@student_id", student_id);
        sc.Parameters.AddWithValue("@quiz_ques_id", quiz_ques_id);
        sc.Parameters.AddWithValue("@quiz_choice_id", quiz_choice_id);
        sc.Parameters.AddWithValue("@Is_correct", Is_correct);
            sc.Parameters.AddWithValue("@answer", answer);
        




        sc.Parameters.AddWithValue("@Query", 1);
        sc.ExecuteNonQuery();
    }


}



    public class Quiz_user_score
    {
        public int score_id { get; set; }
        public int student_id { get; set; }
        
        public int score { get; set; }



        public void Add()
        {

            SqlCommand sc = new SqlCommand("Usp_Quiz_user_score", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure }; ;
            sc.Parameters.AddWithValue("@student_id", student_id);
            sc.Parameters.AddWithValue("@score", score);




            sc.Parameters.AddWithValue("@Query", 1);
            sc.ExecuteNonQuery();
        }

        public Quiz_user_score getbyid()
        {
            Quiz_user_score u = new Quiz_user_score();
            SqlCommand sc = new SqlCommand("Usp_Quiz_user_score", Connection.Get()) { CommandType = System.Data.CommandType.StoredProcedure };
            sc.Parameters.AddWithValue("@student_id", student_id);
            sc.Parameters.AddWithValue("@Query", 2);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                u.score_id = (int)sdr["score_id"];
                u.student_id = (int)sdr["student_id"];
                u.score = (int)sdr["score"];


            }
            sdr.Close();
            return u;

        }


    }

}

