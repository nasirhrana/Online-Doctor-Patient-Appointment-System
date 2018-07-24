using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ODASApp.ViewModel
{
    public class DoctorViewModel
    {
        public int Id { get; set; }
        public string DoctorName { get; set; }
        public string Degree { get; set; }
        public string Specialist { get; set; }
        public DateTime Date { get; set; }
        public DateTime  StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}