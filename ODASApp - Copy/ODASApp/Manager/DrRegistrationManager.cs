using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using ODASApp.Gateway;
using ODASApp.Models;
using ODASApp.ViewModel;

namespace ODASApp.Manager
{
    public class DrRegistrationManager
    {
      private   DrRegstrationGateway aGateway=new DrRegstrationGateway();
        public int Save(DrRegistration aRegistration)
        {
            return aGateway.Save(aRegistration);
        }

        public int PtSave(PtRegistration aRegistration)
        {
            return aGateway.PtSave(aRegistration);
        }

        public List<DrRegistration> GetAll()
        {
            return aGateway.GetAll();
        }

        public DrRegistration Get(int? id)
        {
            return aGateway.Get(id);
        }

        public int Update(DrRegistration aRegistration)
        {
            return aGateway.Update(aRegistration);
        }

        public int Delete(int? id)
        {
            return aGateway.Delete(id);
        }

        public List<PtRegistration> GetAllPatient()
        {
            return aGateway.GetAllPatient();
        }

        public PtRegistration GetPatient(int? id)
        {
            return aGateway.GetPatient(id);
        }

        public int PtUpdate(PtRegistration aRegistration)
        {
            return aGateway.PtUpdate(aRegistration);
        }

        public int PtDelete(int? id)
        {
            return aGateway.PtDelete(id);
        }

        public int ScheduleSave(DrSchedule aSchedule)
        {
            return aGateway.ScheduleSave(aSchedule);
        }

        public bool IsDateExist(DrSchedule aSchedule)
        {
            return aGateway.IsDateExist(aSchedule);
        }

        public bool IsTimeExist(DrSchedule aSchedule)
        {
            return aGateway.IsTimeExist(aSchedule);
        }

        public List<SearchModel> GetDoctor(string search)
        {
            return aGateway.GetDoctor(search);
        }

        public List<Speciality> GetAllSpeciality()
        {
            return aGateway.GetAllSpeciality();
        }

        public List<DoctorViewModel> GetBySpecialityId(int specialityId)
        {
            return aGateway.GetBySpecialityId(specialityId);
        }
        public List<DoctorViewModel> GetDoctorById(int doctorId)
        {
            
            return aGateway.GetDoctorById(doctorId);
        }
        //public List<DoctorViewModel> GetByScheduleId(int schedulId)
        //{

        //    return aGateway.GetByScheduleId(schedulId);
        //}

        public Appointment GetDoctorAppointment(int? id)
        {
            return aGateway.GetDoctorAppointment(id);
        }

        public int GetAppointment(Appointment appointment)
        {
            return aGateway.GetAppointment(appointment);
        }

        public bool IsScheduleExist(Appointment appointment)
        {
            return aGateway.IsScheduleExist(appointment);
        }

        public List<CheckStatusViewModel> GetAppointmentById(int id)
        {
            return aGateway.GetAppointmentById(id);
        }

        public List<CheckStatusViewModel> GetAllSubmitttedAppointment()
        {
            return aGateway.GetAllSubmitttedAppointment();
        }

        public int Approve(int appointmentId)
        {
            return aGateway.Approve(appointmentId);
        }

        public int Reject(int appointmentId)
        {
            return aGateway.Reject(appointmentId);
        }

        public List<CheckStatusViewModel> GetAllApprovedAppointment()
        {
            return aGateway.GetAllApprovedAppointment();
        }
        public List<CheckStatusViewModel> GetAllRejectedAppointment()
        {
            return aGateway.GetAllRejectedAppointment();
        }

        public List<CheckStatusViewModel> GetEmail(int appointmentId)
        {
            return aGateway.GetEmail(appointmentId);
        }
        public List<CheckStatusViewModel> GetsubmitedEmail(int appointmentId)
        {
            return aGateway.GetsubmitedEmail(appointmentId);
        }
        public bool SendEmail(string toEmail, string subject, string emailBody)
        {

            try
            {
                string senderEmail = System.Configuration.ConfigurationManager.AppSettings["SenderEmail"].ToString();
                string senderPassword = System.Configuration.ConfigurationManager.AppSettings["SenderPassword"].ToString();

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Timeout = 100000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(senderEmail, senderPassword);
                MailMessage mailMessage = new MailMessage(senderEmail, toEmail, subject, emailBody);

                mailMessage.IsBodyHtml = true;
                mailMessage.BodyEncoding = UTF8Encoding.UTF8;
                client.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}