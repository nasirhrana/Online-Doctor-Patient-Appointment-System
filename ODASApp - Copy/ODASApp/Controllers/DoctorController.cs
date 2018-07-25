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
            return View();
        }
        public ActionResult Details(int?id)
        {
            DrRegistration aRegistration = aManager.Get(id);
            return View(aRegistration);
        }
        [HttpGet]
        public ActionResult Edit(int?id)
        {
            DrRegistration aRegistration = aManager.Get(id);
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
            return View();
        }
        [HttpPost]
        public ActionResult CreateSchedule(DrSchedule aSchedule)
        {
            aSchedule.DoctorId = 1005;
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