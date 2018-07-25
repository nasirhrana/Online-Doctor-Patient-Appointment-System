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
        public ActionResult Home()
        {
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
	}  
}