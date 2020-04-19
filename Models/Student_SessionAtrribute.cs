using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FYP1.Models
{
    public class Student_SessionAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(HttpContext.Current.Session["S_ID"]==null)
            {
                filterContext.Result = new RedirectResult("~\\Login\\StudentLogin");

            }
            base.OnActionExecuting(filterContext);
        }
    }
    public class Admin_SessionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["A_ID"] == null)
            {
                filterContext.Result = new RedirectResult("~\\Login\\AdminLogin");

            }
            base.OnActionExecuting(filterContext);
        }
    }
    public class Institute_SessionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["I_ID"] == null)
            {
                filterContext.Result = new RedirectResult("~\\Login\\InstituteLogin");

            }
            base.OnActionExecuting(filterContext);
        }
    }




}