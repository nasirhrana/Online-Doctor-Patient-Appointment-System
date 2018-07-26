using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ODASApp.Manager;
using ODASApp.Models;

namespace ODASApp.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        private DrRegistrationManager aManager=new DrRegistrationManager();
        private LoginManager aLoginManager=new LoginManager();
        public ActionResult Index()
        {
            if (Session["Id"] != null)
            {
                Session["Id"] = null;
                ;
            }
            return View();
        }
        [HttpPost]
        public ActionResult Index(Login aLogin)
        {
            Session["UserType"] = aLogin.UserType;
            if (aLogin.UserType=="Admin")
            {
                List<Login> status = aLoginManager.AdminLogin(aLogin);
                if (status.Count() > 0)
                {
                    var name = status[0].Name;
                    Session["Id"] = status[0].Id;
                    Session["user"] = name;
                    Session["status"] = true;
                   return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ViewBag.message = "Username and password in invalid";
                }
            }
            else if (aLogin.UserType == "Doctor")
            {
                List<Login> status = aLoginManager.DoctorLogin(aLogin);
                if (status.Count() > 0)
                {
                    var name = status[0].Name;
                    Session["Id"] = status[0].Id;
                    Session["user"] = name;
                    Session["status"] = true;
                  return  RedirectToAction("Index", "Doctor");
                }
                else
                {
                    ViewBag.message = "Username and password in invalid";
                }
            }
            else
            {
                List<Login> status = aLoginManager.PatientLogin(aLogin);
                if (status.Count() > 0)
                {
                    var name = status[0].Name;
                    Session["Id"] = status[0].Id;
                    Session["user"] = name;
                    Session["status"] = true;
                    return RedirectToAction("Index", "Patient");
                }
                else
                {
                    ViewBag.message = "Username and password in invalid";
                }
            }
            return View();
        }
        public ActionResult LogOut()
        {
            Session["Id"] = null;
            return RedirectToAction("Home", "Home");

        }
	}
}