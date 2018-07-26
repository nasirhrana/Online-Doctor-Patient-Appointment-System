using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ODASApp.Manager;
using ODASApp.Models;

namespace ODASApp.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private DrRegistrationManager aManager=new DrRegistrationManager();
        private LoginManager aLoginManager=new LoginManager();
        public ActionResult Home()
        {
            if (Session["user"] != null)
            {
                Session["user"] = null;
                ;
            }
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Specialyty = aManager.GetAllSpeciality();
            return View();
        }
        [HttpPost]
        public ActionResult Create(DrRegistration aRegistration)
        {
            ViewBag.Specialyty = aManager.GetAllSpeciality();
            try
            {
                if (ModelState.IsValid)
                {
                    int message = aManager.Save(aRegistration);
                    if (message > 0)
                    {
                        ViewBag.showMsg = "Insert Successfully";
                    }
                    else
                    {
                        ViewBag.showMsg = "failed to Insert! please try again";
                    }
                }
            }
            catch (Exception exception)
            {
                ViewBag.showMsg = exception.Message;

            }



            return View();
        }
        public ActionResult PatientCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PatientCreate(PtRegistration aRegistration)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int message = aManager.PtSave(aRegistration);
                    if (message > 0)
                    {
                        ViewBag.showMsg = "Insert Successfully";
                    }
                    else
                    {
                        ViewBag.showMsg = "failed to Insert! please try again";
                    }
                }
            }
            catch (Exception exception)
            {
                ViewBag.showMsg = exception.Message;

            }

            return View();
        }
        public JsonResult IsDoctorEmailExists(string email)
        {
            bool isExist = aLoginManager.IsDoctorEmailExists(email);

            if (isExist)
                return Json(false, JsonRequestBehavior.AllowGet);
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);

            }
        }
        public JsonResult IsPatientEmailExists(string email)
        {
            bool isExist = aLoginManager.IsPatientEmailExists(email);

            if (isExist)
                return Json(false, JsonRequestBehavior.AllowGet);
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);

            }
        }
	}  
}