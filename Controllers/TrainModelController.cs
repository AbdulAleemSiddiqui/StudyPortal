using FYP1.Models;
using FYP1.Models.Student;
using RecommendationSystemML.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FYP1.Controllers
{
    public class TrainModelController : Controller
    {
        public ActionResult Index()

        {
            var id = (int)Session["S_ID"];
            var data = new Student_Detail().Student_Detail_Get_By_Id(id);
            var quiz = new Quiz_user_score() { student_id=id}.getbyid();
            ModelInput sampleData = new ModelInput()
            {
                Fav_Hobby = data.Fav_Hobby.Replace("\r\n",""),
                Inter_Subject = data.Field_Name.Replace("\r\n", ""),
                Fav_Subject = data.Fav_Subject.Replace("\r\n", ""),
                Inter_Percentage = (float)data.Percentage,
                Gender = data.Gender.Replace("\r\n", ""),
                Sports  = data.Fav_Sport.Replace("\r\n", "")
            };

            //Make a single prediction on the sample data and print results
            var predictionResult = ConsumeModel.Predict(sampleData).dictionary.OrderByDescending(x=>x.Value);

            ViewBag.Student = data;
            ViewBag.Quiz = data;
            ViewBag.Output = predictionResult;

            
            return View();
        }
    }
}