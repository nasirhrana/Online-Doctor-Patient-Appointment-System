using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ODASApp.Models
{
    public class PtRegistration
    {
        public int Id { get; set; }
        [Required]
        public string Image { get; set; }
        public string  Name{ get; set; }
        [Required]
        [EmailAddress]
        [Remote("IsPatientEmailExists", "Home", ErrorMessage = "Email already exists!")]
        public string Email { get; set; }
        [Required]
        public string PhoneNo { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public string NID { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [NotMapped]
        [System.ComponentModel.DataAnnotations.Compare("Password")]
        public string  ConfirmPassword { get; set; }
    }
}