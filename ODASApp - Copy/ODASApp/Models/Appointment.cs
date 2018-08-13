using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security.DataHandler;

namespace ODASApp.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int ScheduleId { get; set; }
        public int DoctorId { get; set; }
        public int PateintId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Status { get; set; }

    }
}