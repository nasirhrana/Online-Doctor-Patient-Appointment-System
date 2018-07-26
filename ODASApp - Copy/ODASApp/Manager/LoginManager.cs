using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ODASApp.Gateway;
using ODASApp.Models;

namespace ODASApp.Manager
{
    public class LoginManager
    {
        private LoginGateway aGateway=new LoginGateway();

        public List<Login> AdminLogin(Login aLogin)
        {
            return aGateway.AdminLogin(aLogin);
        }

        public List<Login> DoctorLogin(Login aLogin)
        {
            return aGateway.DoctorLogin(aLogin);
        }

        public List<Login> PatientLogin(Login aLogin)
        {
            return aGateway.PatientLogin(aLogin);
        }
        public bool IsDoctorEmailExists(string email)
        {
            return aGateway.IsDoctorEmailExists(email);
        }
        public bool IsPatientEmailExists(string email)
        {
            return aGateway.IsPatientEmailExists(email);
        }
    }
}