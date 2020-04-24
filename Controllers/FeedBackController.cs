using FYP1.Models;
using FYP1.Models.Institute;
using FYP1.Models.Student;
using System.Web.Mvc;

namespace FYP1.Controllers
{
    public class FeedBackController : Controller
    {



        //Get All
        public ActionResult Index()
        {
            return View(new FeedBack().FeedBack_Get_All());
        }

        //Search
        //Get By ID
        public ActionResult Search(int id)
        {
            return View(new FeedBack().FeedBack_Get_By_Id(id));
        }

        //Add
        public ActionResult Add()
        {
            FeedBack obj = new FeedBack();
            if (Session["S_ID"] != null)
            {
                obj.is_Student = true;
                Student s = new Student().Student_Get_By_Id((int)Session["S_ID"]);
                obj.User_Name = s.Student_Name;
                obj.User_Email = s.Email;
            }
            if (Session["I_ID"] != null)
            {
                obj.is_Institute = true;
                Institute s = new Institute() { Institute_ID = (int)Session["I_ID"] }.Institute_Get_By_ID();
                obj.User_Name = s.Institute_Name;
                obj.User_Email = s.Email;
            }
            return View(obj);
        }
        [HttpPost]
        public ActionResult Add(FeedBack obj)
        {
            if (Session["S_ID"] != null)
            {
                obj.is_Student = true;
                Student s = new Student().Student_Get_By_Id((int)Session["S_ID"]);
                obj.User_Name = s.Student_Name;
                obj.User_Email = s.Email;
            }
            if (Session["I_ID"] != null)
            {
                obj.is_Institute = true;
                Institute s = new Institute() { Institute_ID = (int)Session["I_ID"] }.Institute_Get_By_ID();
                obj.User_Name = s.Institute_Name;
                obj.User_Email = s.Email;
            }
            int id = obj.FeedBack_Add();
            return RedirectToAction("Notification", new { msg = obj.Message, name = obj.User_Name });
        }
        public ActionResult Notification(string msg, string name)
        {
            ViewBag.msg = msg;
            ViewBag.name = name;
            return View();
        }
        //Edit
        public ActionResult Edit(int id)
        {
            return View(new FeedBack().FeedBack_Get_By_Id(id));
        }
        [HttpPost]
        public ActionResult Edit(FeedBack obj)
        {
            obj.FeedBack_Edit();
            return RedirectToAction("Index");
        }

        //Delete
        public ActionResult Delete(int id)
        {
            new FeedBack().FeedBack_Delete(id);
            return RedirectToAction("Index");
        }





    }
}