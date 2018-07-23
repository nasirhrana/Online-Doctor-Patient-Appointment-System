using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Configuration;
using Microsoft.Owin.Security.Provider;
using ODASApp.Models;
using ODASApp.ViewModel;

namespace ODASApp.Gateway
{
    public class DrRegstrationGateway
    {
        private SqlConnection con=new SqlConnection(
            WebConfigurationManager.ConnectionStrings["ODASDB"].ConnectionString);
    
        
        public int Save(DrRegistration aRegistration)
        {
            string query = @"INSERT INTO [dbo].[DrRegistration]
           ([Image]
           ,[DoctorName]
           ,[Email]
           ,[RegistrationNo]
           ,[NID]
           ,[PhoneNo]
           ,[Gender]
           ,[DOB]
           ,[Degree]
           ,[SpecialityId]
           ,[Password])
     VALUES('" + aRegistration.Image+"','"+aRegistration.Name+"','"+aRegistration.Email+"','"+aRegistration.RegistrationNo+"'," +
                           "'"+aRegistration.NID+"','"+aRegistration.PhoneNo+"','"+aRegistration.Gender+"','"+aRegistration.DOB+"'," +
                           "'" + aRegistration.Degree + "','" + aRegistration.SpecialityId + "','" + aRegistration.Password + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int rowAffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowAffected;
        }

        public int PtSave(PtRegistration aRegistration)
        {
            string query = @"INSERT INTO [dbo].[PtRegistration]
           ([Image]
           ,[PatientName]
           ,[Email]
           ,[PhoneNo]
           ,[Gender]
           ,[DOB]
           ,[NID]
           ,[Password])
     VALUES('"+aRegistration.Image+"','"+aRegistration.Name+"','"+aRegistration.Email+"','"+aRegistration.PhoneNo+"'," +
                           "'"+aRegistration.Gender+"','"+aRegistration.DOB+"','"+aRegistration.NID+"','"+aRegistration.Password+"')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int rowAffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowAffected;
        }

        public List<DrRegistration> GetAll()
        {
            string query = @"select * from DrRegistration";
            SqlCommand cmd= new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<DrRegistration> aList=new List<DrRegistration>();
            while (reader.Read())
            {
                DrRegistration aRegistration=new DrRegistration();
                aRegistration.Id = (int) reader["Id"];
                aRegistration.Image = reader["Image"].ToString();
                aRegistration.Name = reader["DoctorName"].ToString();
                aRegistration.Email = reader["Email"].ToString();
                aRegistration.RegistrationNo = reader["RegistrationNo"].ToString();
                aRegistration.NID = reader["NID"].ToString();
                aRegistration.PhoneNo = reader["PhoneNo"].ToString();
                aRegistration.Gender = reader["Gender"].ToString();
                aRegistration.DOB = Convert.ToDateTime(reader["DOB"].ToString());
                aRegistration.Degree = reader["Degree"].ToString();
                aRegistration.SpecialityId = (int) reader["SpecialityId"];
                aRegistration.Password = reader["Password"].ToString();
                aList.Add(aRegistration);
            }
            reader.Close();
            con.Close();
            return aList;
        }

        public DrRegistration Get(int? id)
        {
            string query = @"SELECT [Id]
      ,[Image]
      ,[DoctorName]
      ,[Email]
      ,[RegistrationNo]
      ,[NID]
      ,[PhoneNo]
      ,[Gender]
      ,[DOB]
      ,[Degree]
      ,[SpecialityId]
      ,[Password]
  FROM [dbo].[DrRegistration] where Id='" + id+"'";
            SqlCommand cmd=new SqlCommand(query,con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            DrRegistration aRegistration=new DrRegistration();
            while (reader.Read())
            {
                aRegistration.Id = (int) reader["Id"];
                aRegistration.Image = reader["Image"].ToString();
                aRegistration.Name = reader["DoctorName"].ToString();
                aRegistration.Email = reader["Email"].ToString();
                aRegistration.RegistrationNo = reader["RegistrationNo"].ToString();
                aRegistration.NID = reader["NID"].ToString();
                aRegistration.PhoneNo = reader["PhoneNo"].ToString();
                aRegistration.Gender = reader["Gender"].ToString();
                aRegistration.DOB = Convert.ToDateTime(reader["DOB"].ToString());
                aRegistration.Degree = reader["Degree"].ToString();
                aRegistration.SpecialityId = (int) reader["SpecialityId"];
                aRegistration.Password = reader["Password"].ToString();
            }
            reader.Close();
            con.Close();
            return aRegistration;
        }

        public int Update(DrRegistration aRegistration)
        {
            string query = @"UPDATE [dbo].[DrRegistration]
   SET [Image]='"+aRegistration.Image+"',[DoctorName] ='"+aRegistration.Name+"',[Email]='"+aRegistration.Email+
                 "' ,[RegistrationNo]='"+aRegistration.RegistrationNo+ "' ,[NID]='"+aRegistration.NID+
                 "' ,[PhoneNo]='"+aRegistration.PhoneNo+"' ,[Gender]='"+aRegistration.Gender+"' ,[DOB]='"+aRegistration.DOB+
            "',[Degree]='" + aRegistration.Degree + "',[SpecialityId]='" + aRegistration.SpecialityId + "',[Password]='" + aRegistration.Password +
            "'  WHERE Id='"+aRegistration.Id+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int rowAffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowAffected;
        }

        public int Delete(int? id)
        {
            string query = @"DELETE FROM [dbo].[DrRegistration]
      WHERE Id='"+id+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int rowAffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowAffected;
        }

        public List<PtRegistration> GetAllPatient()
        {
            string query = @"select * from PtRegistration";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<PtRegistration> aList = new List<PtRegistration>();
            while (reader.Read())
            {
                PtRegistration aRegistration = new PtRegistration();
                aRegistration.Id = (int)reader["Id"];
                aRegistration.Image = reader["Image"].ToString();
                aRegistration.Name = reader["PatientName"].ToString();
                aRegistration.Email = reader["Email"].ToString();
                aRegistration.NID = reader["NID"].ToString();
                aRegistration.PhoneNo = reader["PhoneNo"].ToString();
                aRegistration.Gender = reader["Gender"].ToString();
                aRegistration.DOB = Convert.ToDateTime(reader["DOB"].ToString());
                aRegistration.Password = reader["Password"].ToString();
                aList.Add(aRegistration);
            }
            reader.Close();
            con.Close();
            return aList;
        }

        public PtRegistration GetPatient(int?id)
        {
            string query = @"SELECT [Id]
      ,[Image]
      ,[PatientName]
      ,[Email]
      ,[PhoneNo]
      ,[Gender]
      ,[DOB]
      ,[NID]
      ,[Password]
  FROM [dbo].[PtRegistration] where Id='"+id+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            PtRegistration aRegistration = new PtRegistration();
            while (reader.Read())
            {
                aRegistration.Id = (int)reader["Id"];
                aRegistration.Image = reader["Image"].ToString();
                aRegistration.Name = reader["PatientName"].ToString();
                aRegistration.Email = reader["Email"].ToString();
                aRegistration.NID = reader["NID"].ToString();
                aRegistration.PhoneNo = reader["PhoneNo"].ToString();
                aRegistration.Gender = reader["Gender"].ToString();
                aRegistration.DOB = Convert.ToDateTime(reader["DOB"].ToString());
                aRegistration.Password = reader["Password"].ToString();
            }
            reader.Close();
            con.Close();
            return aRegistration;
        }

        public int PtUpdate(PtRegistration aRegistration)
        {
            string query = @"UPDATE [dbo].[PtRegistration]
   SET [Image]='" + aRegistration.Image + "',[PatientName] ='" + aRegistration.Name + "',[Email]='" + aRegistration.Email +
                 "' ,[NID]='" + aRegistration.NID +
                 "' ,[PhoneNo]='" + aRegistration.PhoneNo + "' ,[Gender]='" + aRegistration.Gender + "' ,[DOB]='" + aRegistration.DOB +
            "',[Password]='" + aRegistration.Password +
            "'  WHERE Id='" + aRegistration.Id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int rowAffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowAffected;
        }

        public int PtDelete(int? id)
        {
            string query = @"DELETE FROM [dbo].[PtRegistration]
      WHERE Id='" + id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int rowAffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowAffected;
        }

        public int ScheduleSave(DrSchedule aSchedule)
        {
            string query = @"INSERT INTO [dbo].[DrSchedule]
           ([DoctorId]
           ,[Date]
           ,[Start-Time]
           ,[End-Time])
     VALUES('"+aSchedule.DoctorId+"','"+aSchedule.Date+"','"+aSchedule.Start_Time+"','"+aSchedule.End_Time+"')";
            SqlCommand cmd=new SqlCommand(query,con);
            con.Open();
            int rowAffected = cmd.ExecuteNonQuery();
            return rowAffected;
        }

        public bool IsDateExist(DrSchedule aSchedule)
        {
            string query = @"SELECT * FROM [dbo].[DrSchedule] WHERE (Date <= @Date AND DoctorId = @DoctorId)";
            SqlCommand cmd=new SqlCommand(query,con);
            con.Open();
            cmd.Parameters.Clear();
            cmd.Parameters.Add("Date", SqlDbType.Date);
            cmd.Parameters["Date"].Value = aSchedule.Date;
            cmd.Parameters.Add("DoctorId", SqlDbType.Int);
            cmd.Parameters["DoctorId"].Value = aSchedule.DoctorId;
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            bool isExist = reader.HasRows;
            reader.Close();
            con.Close();
            return isExist;
        }

        public bool IsTimeExist(DrSchedule aSchedule)
        {
            string query = @"SELECT * FROM [dbo].[DrSchedule] WHERE ([Start-Time] <= @End_Time AND [End-Time]<=@Start_Time AND [DoctorId] = @DoctorId)";
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Parameters.Clear();
            cmd.Parameters.Add("[Start-Time]", SqlDbType.Date);
            cmd.Parameters["[Start-Time]"].Value = aSchedule.Start_Time;
            cmd.Parameters.Add("[End-Time]", SqlDbType.Date);
            cmd.Parameters["[End-Time]"].Value = aSchedule.End_Time;
            cmd.Parameters.Add("[DoctorId]", SqlDbType.Int);
            cmd.Parameters["[DoctorId]"].Value = aSchedule.DoctorId;
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            bool isExist = reader.HasRows;
            reader.Close();
            con.Close();
            return isExist;
        }

        public List<SearchModel> GetDoctor(string search)
        {
            string query = @"select DoctorName from [dbo].[DrRegistration] where " + "DoctorName like @Search + '%'";
            SqlCommand cmd=new SqlCommand(query,con);
            con.Open();
            cmd.Parameters.AddWithValue("@Search", search);
            SqlDataReader reader = cmd.ExecuteReader();
            List<SearchModel> aList=new List<SearchModel>();
            while (reader.Read())
            {
                SearchModel aModel=new SearchModel();
                //aModel.Id = (int) reader["Id"];
                aModel.Name = reader["DoctorName"].ToString();
                aList.Add(aModel);
            }
            reader.Close();
            con.Close();
            return aList;

        }

        public List<Speciality> GetAllSpeciality()
        {
            string query = @"select * from [dbo].[Speciality]";
            SqlCommand cmd=new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Speciality> aList=new List<Speciality>();
            while (reader.Read())
            {
                Speciality aSpeciality=new Speciality();
                aSpeciality.Id = (int) reader["Id"];
                aSpeciality.SpecialityName = reader["SpecialityName"].ToString();
                aList.Add(aSpeciality);
            }
            reader.Close();
            con.Close();
            return aList;
        }

        public List<DoctorViewModel> GetBySpecialityId(int specialityId)
        {
            string query = @"Select p.SpecialityName ,s.Id, s.DoctorName, s.Degree 
                           from [dbo].[Speciality] p
                           inner join [dbo].[DrRegistration] s on  p.Id  = s.SpecialityId
                           inner join DrSchedule k on s.Id=k.DoctorId
                           where p.Id = '" + specialityId + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<DoctorViewModel> aList = new List<DoctorViewModel>();
                while (reader.Read())
                {
                    DoctorViewModel aModel = new DoctorViewModel();
                    aModel.Id = (int)reader["Id"];
                    aModel.DoctorName = reader["DoctorName"].ToString();
                    aModel.Degree = reader["Degree"].ToString();
                    aModel.Specialist = reader["SpecialityName"].ToString();
                    aList.Add(aModel);
                }
                reader.Close();
                con.Close();
                return aList;
            
            
        }
        public List<DoctorViewModel> GetDoctorById(int doctorId)
        {
            string query = @"Select p.SpecialityName ,s.Id, s.DoctorName, s.Degree 
                           from [dbo].[Speciality] p
                           inner join [dbo].[DrRegistration] s on  p.Id  = s.SpecialityId
                           where p.Id = '" + doctorId + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<DoctorViewModel> aList = new List<DoctorViewModel>();
                while (reader.Read())
                {
                    DoctorViewModel aModel = new DoctorViewModel();
                    aModel.Id = (int)reader["Id"];
                    aModel.DoctorName = reader["DoctorName"].ToString();
                    aModel.Degree = reader["Degree"].ToString();
                    aModel.Specialist = reader["SpecialityName"].ToString();
                    aList.Add(aModel);
                }
                reader.Close();
                con.Close();
                return aList;
            
            
        }
        
    }
}