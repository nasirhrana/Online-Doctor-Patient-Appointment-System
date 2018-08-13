using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ODASApp.ViewModel
{
    public class CheckStatusViewModel
    {
        public int AppointmentId { get; set; }
        public int  PatientId { get; set; }
        public int ScheduleId { get; set; }
        public string  DoctorName { get; set; }
        public string Speciality { get; set; }
        public string AppointmentDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Status { get; set; }
        public string PatientName { get; set; }
        public string PatientEmail { get; set; }
    }
}