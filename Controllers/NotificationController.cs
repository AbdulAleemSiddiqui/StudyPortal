using FYP1.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FYP1.Controllers
{
    public class NotificationController : Controller
    {
        // GET: Notification
        public ActionResult Notification_Admin()
        {
            return View(new Notification().Notification_Admin());
        }
        public ActionResult Notification_Student(int id)
        {
            return View(new Notification() { Fk_Id=id}.Notification_Student());
        }
        public ActionResult Notification_Institute(int id)
        {
            return View(new Notification() { Fk_Id = id }.Notification_Institute());
        }
        [HttpPost]
        public ActionResult Notification_Update(List<int> data)
        {
            if (data != null)
            {
                data.ForEach(x => new Notification().Notification_Update(x));
            }
            return View();
        }
    }
}