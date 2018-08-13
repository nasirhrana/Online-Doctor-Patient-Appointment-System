using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Web;

namespace ODASApp.Models
{
    public class DrSchedule
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime AppointmentDate { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        public string StartTime { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        public string EndTime { get; set; }
        
    }
}