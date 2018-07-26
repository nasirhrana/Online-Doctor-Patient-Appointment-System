using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ODASApp.Manager;
using ODASApp.Models;

namespace ODASApp.Controllers
{
    public class DoctorController : Controller
    {
        //
        // GET: /Doctor/
        private DrRegistrationManager aManager=new DrRegistrationManager();

        public ActionResult Index()
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("Home", "Home");
                ;
            }
            return View();
        }
        public ActionResult Details(int? id)
        {
            if (Session["Id"]==null)
            {
                return RedirectToAction("Home", "Home");
                ;
            }
            int userId = (int) Session["Id"];
            DrRegistration aRegistration = aManager.Get(userId);
            return View(aRegistration);
        }
        [HttpGet]
        public ActionResult Edit(int?id)
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("Home", "Home");
                ;
            }
            int userId = (int)Session["Id"];
            DrRegistration aRegistration = aManager.Get(userId);
            return View(aRegistration);
        }
        [HttpPost]
        public ActionResult Edit(DrRegistration aRegistration)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int message = aManager.Update(aRegistration);
                    if (message > 0)
                    {
                        ViewBag.showMsg = "Updated Successfully";
                    }
                    else
                    {
                        ViewBag.showMsg = "failed to Update! please try again";
                    }
                }
            }
            catch (Exception exception)
            {
                ViewBag.showMsg = exception.Message;

            }

            return View();
        }
        [HttpGet]
        public ActionResult CreateSchedule()
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("Home", "Home");
                ;
            }
            
            return View();
        }
        [HttpPost]
        public ActionResult CreateSchedule(DrSchedule aSchedule)
        {
            aSchedule.DoctorId = (int)Session["Id"];
            try
            {
                if (ModelState.IsValid)
                {
                    if (aManager.IsDateExist(aSchedule))
                    {
                        if (aManager.IsTimeExist(aSchedule))
                        {
                            ViewBag.message = "schedule is conflicting";
                        }

                        else
                        {
                            int message = aManager.ScheduleSave(aSchedule);
                            if (message > 0)
                            {
                                ViewBag.message = "Schedule created successfully";
                            }
                            else
                            {
                                ViewBag.message = "failed to create Schedule";
                            }
                        }

                    }
                    else
                    {
                        int message = aManager.ScheduleSave(aSchedule);
                        if (message > 0)
                        {
                            ViewBag.message = "Schedule created successfully";
                        }
                        else
                        {
                            ViewBag.message = "failed to create Schedule";
                        }
                    }
                }
            }
            catch (Exception exception)
            {

                ViewBag.message = exception.Message;
            }
            
            
            
            return View();
        }


	}
}