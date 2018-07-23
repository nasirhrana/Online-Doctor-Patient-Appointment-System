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
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public string Date { get; set; }
        public string Start_Time { get; set; }
        public string End_Time { get; set; }
        public string Status { get; set; }
    }
}