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
            List<DrRegistration> aList = aManager.GetAll();
            return View(aList);
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
        public ActionResult Delete(int? id)
        {
            DrRegistration aRegistration = aManager.Get(id);
            return View(aRegistration);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int?id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int message = aManager.Delete(id);
                    if (message > 0)
                    {
                        ViewBag.showMsg = "Deleted Successfully";
                    }
                    else
                    {
                        ViewBag.showMsg = "failed to Delete! please try again";
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
            aSchedule.DoctorId = 2;
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