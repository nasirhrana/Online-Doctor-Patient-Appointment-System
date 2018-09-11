using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;

namespace ODASApp.Models
{
    public class DrRegistration
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Upload File")]
        public string Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        //[Remote("IsDoctorEmailExists", "Home", ErrorMessage = "Email already exists!")]
        public string Email { get; set; }
        [Required]
        public string PhoneNo { get; set; }
        [Required]
        public string NID { get; set; }
        [Required]
        public string RegistrationNo { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public string Degree { get; set; }
        [Required]
        public int SpecialityId { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [NotMapped]
        [System.ComponentModel.DataAnnotations.Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}