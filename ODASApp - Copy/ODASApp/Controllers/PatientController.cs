using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using ODASApp.Manager;
using ODASApp.Models;
using ODASApp.ViewModel;

namespace ODASApp.Controllers
{
    public class PatientController : Controller
    {
        private DrRegistrationManager aManager = new DrRegistrationManager();
        //
        // GET: /Patient/
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
            if (Session["Id"] == null)
            {
                return RedirectToAction("Home", "Home");
                ;
            }
            int userId = (int)Session["Id"];
            PtRegistration aRegistration = aManager.GetPatient(userId);
            return View(aRegistration);
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("Home", "Home");
                ;
            }
            int userId = (int)Session["Id"];
            PtRegistration aRegistration = aManager.GetPatient(userId);
            return View(aRegistration);
        }
        [HttpPost]
        public ActionResult Edit(PtRegistration aRegistration)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int message = aManager.PtUpdate(aRegistration);
                    if (message > 0)
                    {
                        ViewBag.showMsg = "Updated Successfully";
                    }
                    else
                    {
                        ViewBag.showMsg = "failed to Upate! please try again";
                    }
                }
            }
            catch (Exception exception)
            {
                ViewBag.showMsg = exception.Message;

            }
            return View();
        }

        public ActionResult SearchIndex()
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("Home", "Home");
                ;
            }
            ViewBag.Specialyty = aManager.GetAllSpeciality();
            return View();
        }

        public JsonResult GetDoctor(string search)
        {
            List<SearchModel> aList = aManager.GetDoctor(search);
            return Json(aList.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetBySpecialityId(int specialityId)
        {

            List<DoctorViewModel> aList = aManager.GetBySpecialityId(specialityId);
            return Json(aList.ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetDoctorById(int doctorId)
        {

            List<DoctorViewModel> aList = aManager.GetDoctorById(doctorId);
            return Json(aList, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Appointment(int id)
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("Home", "Home");
                ;
            }
            Appointment aModel = aManager.GetDoctorAppointment(id);
            aModel.PateintId = (int)Session["Id"];
            int appointmentId = aModel.PateintId;
            aModel.Status = "Submit";
            if (aManager.IsScheduleExist(aModel))
            {
                ViewBag.msg="you already booked this schedule";
            }
            else
            {
                int message = aManager.GetAppointment(aModel);
                if (message > 0)
                {
                    List<CheckStatusViewModel> userEmail = aManager.GetsubmitedEmail(appointmentId);
                    bool result = aManager.SendEmail(userEmail[0].PatientEmail, "About your leave application",
                        "<p>Hello '" + userEmail[0].PatientName + "' <br/>Your Leave Application  date '" +
                        userEmail[0].AppointmentDate + "' and start time '" + userEmail[0].StartTime + "', end time " +
                        userEmail[0].EndTime + " are submitted successfully<br/>Thank You<br/></p>");
                    ViewBag.msg = "Submit successfully";
                }
                else
                {
                    ViewBag.msg = "failed to submit";
                }
            }
            
            return RedirectToAction("AppointmentStatus");
        }

        public ActionResult AppointmentStatus()
          {
              if (Session["Id"] == null)
              {
                  return RedirectToAction("Home", "Home");
                  ;
              }
            int id = (int)Session["Id"];
            List<CheckStatusViewModel> aList = aManager.GetAppointmentById(id);
            return View(aList);
        }
    }
}