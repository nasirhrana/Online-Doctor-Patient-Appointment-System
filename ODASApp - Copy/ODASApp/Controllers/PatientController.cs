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
            List<PtRegistration> aRegistrations = aManager.GetAllPatient();
            return View(aRegistrations);
        }
        [HttpGet]
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

        public ActionResult Details(int? id)
        {
            PtRegistration aRegistration = aManager.GetPatient(id);
            return View(aRegistration);
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            PtRegistration aRegistration = aManager.GetPatient(id);
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
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            PtRegistration aRegistration = aManager.GetPatient(id);
            return View(aRegistration);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int? id)
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

        public ActionResult SearchIndex()
        {
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
            return Json(aList.ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}