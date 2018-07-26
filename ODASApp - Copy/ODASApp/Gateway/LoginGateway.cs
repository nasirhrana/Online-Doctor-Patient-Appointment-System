using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using ODASApp.Models;

namespace ODASApp.Gateway
{
    public class LoginGateway
    {
        private SqlConnection con = new SqlConnection(
            WebConfigurationManager.ConnectionStrings["ODASDB"].ConnectionString);

        public List<Login> AdminLogin(Login aLogin)
        {
            string query = @"SELECT [Id]
      ,[Name]
      ,[Email]
      ,[Password]
  FROM [dbo].[Admin]
where Email = '" + aLogin.Email + "' and Password = '" + aLogin.Password + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Login> aList = new List<Login>();
            while (reader.Read())
            {
                Login alogin = new Login();
                alogin.Id = (int)reader["Id"];
                alogin.Name = reader["Name"].ToString();
                alogin.Email = reader["Email"].ToString();
                alogin.Password = reader["Password"].ToString();
                aList.Add(alogin);
            }
            reader.Close();
            con.Close();
            return aList;
        }

        public List<Login> DoctorLogin(Login aLogin)
        {
            string query = @"SELECT [Id]
      ,[DoctorName]
      ,[Email]
      ,[Password]
  FROM DrRegistration
where Email = '" + aLogin.Email + "' and Password = '" + aLogin.Password + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Login> aList = new List<Login>();
            while (reader.Read())
            {
                Login alogin = new Login();
                alogin.Id = (int)reader["Id"];
                alogin.Name = reader["DoctorName"].ToString();
                alogin.Email = reader["Email"].ToString();
                alogin.Password = reader["Password"].ToString();
                aList.Add(alogin);
            }
            reader.Close();
            con.Close();
            return aList;
        }

        public List<Login> PatientLogin(Login aLogin)
        {
            string query = @"SELECT [Id]
      ,[PatientName]
      ,[Email]
      ,[Password]
  FROM PtRegistration
where Email = '" + aLogin.Email + "' and Password = '" + aLogin.Password + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Login> aList = new List<Login>();
            while (reader.Read())
            {
                Login alogin = new Login();
                alogin.Id = (int)reader["Id"];
                alogin.Name = reader["DoctorName"].ToString();
                alogin.Email = reader["Email"].ToString();
                alogin.Password = reader["Password"].ToString();
                aList.Add(alogin);
            }
            reader.Close();
            con.Close();
            return aList;
        }
        public bool IsDoctorEmailExists(string email)
        {
            
                bool isExists = false;

                string query = "SELECT Email FROM [dbo].[DrRegistration] WHERE Email= @Email ";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.Clear();

                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = email;
                
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isExists = true;
                }

                reader.Close();
                con.Close();
                return isExists;

        }
        public bool IsPatientEmailExists(string email)
        {

            bool isExists = false;

            string query = "SELECT Email FROM [dbo].[PtRegistration] WHERE Email= @Email ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.Parameters.Clear();

            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = email;
            
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                isExists = true;
            }

            reader.Close();
            con.Close();
            return isExists;

        }
    }
}