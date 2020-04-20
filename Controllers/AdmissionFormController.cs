using FYP1.Models;
using FYP1.Models.Admin.AdmissionForm;
using FYP1.Models.Department;
using FYP1.Models.Institute;
using FYP1.Models.Student;
using FYP1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;

namespace FYP1.Controllers
{
    public class AdmissionFormController : Controller
    {



        // GET: AdmissionForm

        [Student_Session]
        [HttpGet]
        public ActionResult Add()
        {
            //University u = new University();
            //u.GetData();

            #region Fuzzy Logic

            //u.UB_ActAvg = u.getUpperBound(u.ActAvg);
            //u.FV_ActAvg = u.getFuzzyValues(u.ActAvg, u.UB_ActAvg, true);

            //u.UB_SatAvg = u.getUpperBound(u.SatAvg);
            //u.FV_SatAvg = u.getFuzzyValues(u.SatAvg, u.UB_SatAvg, true);

            //u.UB_AcceptanceRate = u.getUpperBound(u.AcceptanceRate);
            //u.FV_AcceptanceRate = u.getFuzzyValues(u.AcceptanceRate, u.UB_AcceptanceRate, false);

            //u.UB_PercentReceivingAid = u.getUpperBound(u.PercentReceivingAid);
            //u.FV_PercentReceivingAid = u.getFuzzyValues(u.PercentReceivingAid, u.UB_PercentReceivingAid, false);

            //u.UB_CostAfterAid = u.getUpperBound(u.CostAfterAid);
            //u.FV_CostAfterAid = u.getFuzzyValues(u.CostAfterAid, u.UB_CostAfterAid, true);

            //u.UB_TuitionFee = u.getUpperBound(u.TuitionFee);
            //u.FV_TuitionFee = u.getFuzzyValues(u.TuitionFee, u.UB_TuitionFee, true);

            //u.UB_Rank = u.getUpperBound(u.Rank);
            //u.FV_Rank = u.getFuzzyValues(u.Rank, u.UB_Rank, false);

            //u.UB_Control = u.getUpperBound(u.Control);
            //u.FV_Control = u.getFuzzyValues(u.Control, u.UB_Control, false);

            //u.FuzzyLogic();
            //List<University_View> lst = u.Sort();
            //ViewBag.uni = lst;

            #endregion

            //ViewBag.cities = new University().GetCities();
            ViewBag.DegreeLevel = new DegreeLevel().DegreeLevel_Get_All();
            ViewBag.Department = new Department().DepartmentAndType_Get_All();
            ViewBag.Degree = new Degree().Degree_Get_All();

            var lst = new AdmissionViewModel() { S_ID = (int)Session["S_ID"] }.Get_Student_Admission();
            //int ids = new AdmissionForm();
            List<int> ids = new List<int>();
            foreach (var item in lst)
            {
                ids.Add(item.Institute_ID);
            }
            ViewBag.ids = ids;
             ViewBag.insdetail = new Chat() { S_ID = (int)Session["S_ID"] }.institutebyid();
            if (Session["S_ID"] != null)
            {
                int id = (int)Session["S_ID"];
                AdmissionForm s = new AdmissionForm() { S_ID = id };
                return View(s);
            }
           
            return View();
        }[HttpGet]
        public ActionResult index()
        {
            
           
            return View();
        }
        [HttpPost]
        public ActionResult Add(AdmissionForm obj)
        {
            obj.Inst_List = obj.Inst_List.FindAll(x => x.I_ID != 0);
            //AdminViewModel a = new AdminViewModel();
            //List<Institute> lis = a.institute.Institute_Get_All().ToList();
            //ViewBag.InstituteList = new SelectList(lis, "Institute_ID", "Institute_Name");
            //a.institute.Institute_ID = a.institute.Institute_ID;
            int A_ID = obj.Admission_Add();

            foreach (var item in obj.Inst_List)
            {
                item.A_ID = A_ID; // last admission ID
                item.Add();
            }
            return RedirectToAction("AdmissionStatus");
        }
        public ActionResult GetByDeprtment(int D_ID)
        {
            return Json(new Institute().Institute_Get_By_Deprt(D_ID), JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetByDegree(int Degree_ID)
        {
            var listOfuni = new Institute().Institute_Get_By_Degree(Degree_ID);
          
            return Json(listOfuni, JsonRequestBehavior.AllowGet);
        }
        //public ActionResult GetUni(University_View model)
        //{
        //    University u = new University();
        //    u.GetData();

        //    #region Fuzzy Logic

        //    u.UB_ActAvg = u.getUpperBound(u.ActAvg);
        //    u.FV_ActAvg = u.getFuzzyValues(u.ActAvg, u.UB_ActAvg, false);

        //    u.UB_SatAvg = u.getUpperBound(u.SatAvg);
        //    u.FV_SatAvg = u.getFuzzyValues(u.SatAvg, u.UB_SatAvg, false);

        //    u.UB_AcceptanceRate = u.getUpperBound(u.AcceptanceRate);
        //    u.FV_AcceptanceRate = u.getFuzzyValues(u.AcceptanceRate, u.UB_AcceptanceRate, false);

        //    u.UB_PercentReceivingAid = u.getUpperBound(u.PercentReceivingAid);
        //    u.FV_PercentReceivingAid = u.getFuzzyValues(u.PercentReceivingAid, u.UB_PercentReceivingAid, false);

        //    u.UB_CostAfterAid = u.getUpperBound(u.CostAfterAid);
        //    u.FV_CostAfterAid = u.getFuzzyValues(u.CostAfterAid, u.UB_CostAfterAid, false);

        //    u.UB_TuitionFee = u.getUpperBound(u.TuitionFee);
        //    u.FV_TuitionFee = u.getFuzzyValues(u.TuitionFee, u.UB_TuitionFee, false);

        //    u.UB_Rank = u.getUpperBound(u.Rank);
        //    u.FV_Rank = u.getFuzzyValues(u.Rank, u.UB_Rank, false);

        //    u.UB_Control = u.getUpperBound(u.Control);
        //    u.FV_Control = u.getFuzzyValues(u.Control, u.UB_Control, false);

        //    u.FuzzyLogic();
        //    List<University_View> lst = u.Sort();


        //    #endregion

        //    lst = lst.FindAll(x =>x.P_City==model.P_City );
        //    lst = lst.FindAll(x =>x.P_TuitionFee <= model.P_TuitionFee);
        //    lst = lst.FindAll(x =>x.P_Rank >= model.P_Rank);
        //    return Json(lst, JsonRequestBehavior.AllowGet);
        //}
        public ActionResult GetDegreeByDeprtment(int D_ID)
        {
            return Json(new Degree().Degree_Get_By_Deprtment(D_ID), JsonRequestBehavior.AllowGet);
        }
     

        [Admin_Session]
        //Admin
        public ActionResult Get_Unpaid_Admission()
        {
            return View(new AdmissionViewModel().Get_Admission_For_Admin());
        }



        [HttpGet]
        public ActionResult GetQuizQuestion()
        {
            // Quiz qs = new Quiz();

            //object q= new Quiz().get().ToList();


            // qs.choicess = new Quiz.quiz_choice().Getchoices().Where(a=>a.quiz_ques_id==q.quiz_question_id).Select(a=>new Quiz.quiz_choice{choices=a.choices }).ToList();
            Quiz_user_score qu = new Quiz_user_score();
            qu.student_id= (int)Session["S_ID"];
            ViewBag.data = qu.getbyid().student_id;


            return View(new Quiz().get().ToList());
        }
        [HttpPost]
        public ActionResult GetQuizQuestion(List<Quiz_user_answer> resultQuiz)
        {
            List<quiz_choice> qc = new quiz_choice().Getchoices();
            int id = (int)Session["S_ID"];
            int count = 0;
            List<Quiz_user_answer> finalresult = new List<Quiz_user_answer>();
            foreach (Quiz_user_answer ans in resultQuiz)
            {
                if (ans.answer != null)
                {

                    Quiz_user_answer qa = new Quiz_user_answer();
                    qa.student_id = id;
                    qa.quiz_choice_id = ans.quiz_choice_id;
                    qa.quiz_ques_id = ans.quiz_ques_id;
                    qa.answer = ans.answer.ToLower();
                    qa.count = count;



                    //Quiz_user_answer qq = q.Where(a => a.quiz_ques_id == ans.quiz_ques_id)
                    //    .Select(a => new Quiz_user_answer {
                    //    quiz_ques_id = ans.quiz_ques_id
                    //      , quiz_choice_id = ans.quiz_choice_id
                    //      , answer = ans.answer
                    //      , Is_correct = (ans.answer.ToLower().Equals(a.choices.ToLower()))
                    foreach (var item in qc)
                    {
                        if (ans.quiz_ques_id == item.quiz_ques_id && ans.answer == item.choices && item.is_correct_choice == true)
                        {
                            qa.Is_correct = true;
                            //  qa.Add();
                            count++;
                            break;
                        }
                        else
                        {
                            qa.Is_correct = false;
                            if (ans.quiz_ques_id==item.quiz_ques_id && ans.answer != item.choices && item.is_correct_choice==true)
                            {
                                qa.answer = item.choices;
                            }
                            
                        }

                        //}).FirstOrDefault();
                        //    if (qa.answer!=null)
                        //{

                        //    }

                    }
                   

                    finalresult.Add(qa);
                    qa.Add();
                }


            }
            if (finalresult.Count > 0)
            {


                Quiz_user_score qus = new Quiz_user_score();
                qus.student_id = id;
                qus.score = count;
                qus.Add();
                return Json(new { qa = finalresult }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, responseText = "The attached file is not supported." }, JsonRequestBehavior.AllowGet);
            }
        }







        [Admin_Session]
        [HttpGet]
        public ActionResult PayAdmission(int AI_ID)
        {
            new Admission_Institute() { AI_ID = AI_ID }.Pay();
            return RedirectToAction("Get_Unpaid_Admission");
        }

        //[Institute_Session,Admin_Session]
        
public ActionResult Get_All_Admission()
        {
            return View(new AdmissionViewModel().Get_All_Admission_For_Admin()) ;
        }
        public ActionResult Get_Paid_Admission()
        {
            ViewBag.stddetail = new Chat() { Institute_ID = (int)Session["I_ID"] }.studentbyid();
            return View(new AdmissionViewModel().Get_Admission_For_Institute((int)Session["I_ID"]));
        }
        public ActionResult StudentSearch(int S_ID)
        {
            return View(new Student().Student_Get_By_Id(S_ID));
        }
        [Institute_Session]
        [HttpGet]
        public ActionResult AdmissionResponse(int AI_ID, int Status_ID)
        {
            new Admission_Institute() { AI_ID = AI_ID, Status_ID = Status_ID }.Response();
            return RedirectToAction("Get_paid_Admission");
        }
        [Student_Session]

        public ActionResult AdmissionStatus()
        {
            return View(new AdmissionViewModel() { S_ID=(int)Session["S_ID"]}.Get_Student_Admission());
        }




        [HttpPost]
        public ActionResult UpdateAdmissionform(AdmissionForm obj)
        {
            obj.Query = 2; //for update we use 2
            //obj.Admission_Update();
            return RedirectToAction("ShowAdmissionForm");


        }






    }
}