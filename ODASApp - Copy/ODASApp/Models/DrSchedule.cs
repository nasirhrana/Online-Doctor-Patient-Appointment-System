using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ODASApp.Models
{
    public class DrSchedule
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public DateTime Start_Time { get; set; }
        [Required]
        public DateTime End_Time { get; set; }
        
    }
}