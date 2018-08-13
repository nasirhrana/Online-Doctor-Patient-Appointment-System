using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ODASApp.Manager;
using ODASApp.Models;
using ODASApp.ViewModel;

namespace ODASApp.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
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
        public ActionResult DoctorIndex()
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("Home", "Home");
                ;
            }
            List<DrRegistration> aList = aManager.GetAll();
            return View(aList);
        }
        public ActionResult PatientIndex()
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("Home", "Home");
                ;
            }
            List<PtRegistration> aRegistrations = aManager.GetAllPatient();
            return View(aRegistrations);
        }
        public ActionResult Details(int? id)
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("Home", "Home");
                ;
            }
            DrRegistration aRegistration = aManager.Get(id);
            return View(aRegistration);
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("Home", "Home");
                ;
            }
            DrRegistration aRegistration = aManager.Get(id);
            return View(aRegistration);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int? id)
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
        public ActionResult PatientDetails(int? id)
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("Home", "Home");
                ;
            }
            PtRegistration aRegistration = aManager.GetPatient(id);
            return View(aRegistration);
        }
        [HttpGet]
        public ActionResult PatientDelete(int? id)
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("Home", "Home");
                ;
            }
            PtRegistration aRegistration = aManager.GetPatient(id);
            return View(aRegistration);
        }
        [HttpPost]
        [ActionName("PatientDelete")]
        public ActionResult ConfirmPatientDelete(int? id)
        {
            try
            {
                int message = aManager.PtDelete(id);

                if (message > 0)
                {
                    ViewBag.showMsg = "Deleted Successfully";
                }
                else
                {
                    ViewBag.showMsg = "failed to Delete! please try again";
                }
            }
            catch (Exception exception)
            {
                ViewBag.showMsg = exception.Message;

            }

            return View();
        }

        public ActionResult Check()
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("Home", "Home");
                ;
            }
            List<CheckStatusViewModel> aList = aManager.GetAllSubmitttedAppointment();
            return View(aList);
        }
        public ActionResult Approve(int appointmentId)
        {
            aManager.Approve(appointmentId);
            List<CheckStatusViewModel> userEmail = aManager.GetEmail(appointmentId);
            bool result = aManager.SendEmail(userEmail[0].PatientEmail, "About your leave application",
                "<p>Hello '" + userEmail[0].PatientName + "' <br/>Your Leave Application  date '" +
                userEmail[0].AppointmentDate + "' and start time '" + userEmail[0].StartTime + "', end time " +
                userEmail[0].EndTime + " are Approved by  Admin<br/>Thank You<br/></p>");
            return RedirectToAction("Check");
        }

        public ActionResult Reject(int appointmentId)
        {
            aManager.Reject(appointmentId);
            List<CheckStatusViewModel> userEmail = aManager.GetEmail(appointmentId);
            bool result = aManager.SendEmail(userEmail[0].PatientEmail, "About your leave application",
                "<p>Hello '" + userEmail[0].PatientName + "' <br/>Your Leave Application  date '" +
                userEmail[0].AppointmentDate + "' and start time '" + userEmail[0].StartTime + "', end time " +
                userEmail[0].EndTime + " are Rejected by  Admin<br/>Thank You<br/></p>");
            return RedirectToAction("Check");
        }

        public ActionResult Approved()
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("Home", "Home");
                ;
            }
            List<CheckStatusViewModel> aList = aManager.GetAllApprovedAppointment();
            return View(aList);
        }

        public ActionResult Rejected()
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("Home", "Home");
                ;
            }
            List<CheckStatusViewModel> aList = aManager.GetAllRejectedAppointment();
            return View(aList);
        }

	}
}