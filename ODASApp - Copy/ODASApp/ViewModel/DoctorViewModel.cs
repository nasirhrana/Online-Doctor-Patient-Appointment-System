using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ODASApp.ViewModel
{
    public class DoctorViewModel
    {
        public int Id { get; set; }
        public int  ScheduleId { get; set; }
        public string DoctorName { get; set; }
        public string Degree { get; set; }
        public string Specialist { get; set; }
        public string Date { get; set; }
        public string  StartTime { get; set; }
        public string EndTime { get; set; }
        public int MaxAppointment { get; set; }
        public string AppointmentNumber { get; set; }
    }
}