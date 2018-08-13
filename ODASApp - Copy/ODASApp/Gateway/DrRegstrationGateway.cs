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
           ,[AppointmentDate]
           ,[StartTime]
           ,[EndTime])
     VALUES('" + aSchedule.DoctorId + "','" + aSchedule.AppointmentDate + "','" + aSchedule.StartTime + "','" + aSchedule.EndTime + "')";
            SqlCommand cmd=new SqlCommand(query,con);
            con.Open();
            int rowAffected = cmd.ExecuteNonQuery();
            return rowAffected;
        }

        public bool IsDateExist(DrSchedule aSchedule)
        {
            string query = @"SELECT * FROM [dbo].[DrSchedule] WHERE (AppointmentDate= @AppointmentDate AND DoctorId=@DoctorId )";
            SqlCommand cmd=new SqlCommand(query,con);
            
            con.Open();
            cmd.Parameters.Clear();
            cmd.Parameters.Add("AppointmentDate", SqlDbType.Date);
            cmd.Parameters["AppointmentDate"].Value = aSchedule.AppointmentDate;
            cmd.Parameters.Add("DoctorId", SqlDbType.Int);
            cmd.Parameters["DoctorId"].Value = aSchedule.DoctorId;
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            bool isExist = false;
             isExist = reader.HasRows;
            reader.Close();
            con.Close();
            return isExist;
        }

        public bool IsTimeExist(DrSchedule aSchedule)
        {
            string query = @"SELECT * FROM [dbo].[DrSchedule] WHERE (StartTime <= @EndTime AND EndTime>=@StartTime AND DoctorId=@DoctorId)";
            SqlCommand cmd = new SqlCommand(query,con);
            bool isExist = false;
            con.Open();
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@StartTime", SqlDbType.Char);
            cmd.Parameters["StartTime"].Value = aSchedule.StartTime;
            cmd.Parameters.Add("EndTime", SqlDbType.Char);
            cmd.Parameters["EndTime"].Value = aSchedule.EndTime;
            cmd.Parameters.Add("@DoctorId", SqlDbType.Int);
            cmd.Parameters["DoctorId"].Value = aSchedule.DoctorId;
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
              isExist = reader.HasRows;
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
            string query = @"Select p.Id,p.DoctorName,p.Degree, s.SpecialityName,k.ScheduleId,CONVERT(varchar, k.AppointmentDate, 101) as date,k.[StartTime],k.[EndTime]   
                            from DrRegistration p
                            inner join Speciality s on s.Id=p.specialityId 
                            inner join [dbo].[DrSchedule] k on p.Id=k.DoctorId
                            where p.Id = '" + doctorId + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<DoctorViewModel> aList = new List<DoctorViewModel>();
                while (reader.Read())
                {
                    DoctorViewModel aModel = new DoctorViewModel();
                    aModel.Id = (int)reader["Id"];
                    aModel.ScheduleId = (int) reader["ScheduleId"];
                    aModel.DoctorName = reader["DoctorName"].ToString();
                    aModel.Degree = reader["Degree"].ToString();
                    aModel.Specialist = reader["SpecialityName"].ToString();
                    aModel.Date = reader["date"].ToString();
                    aModel.StartTime = reader["StartTime"].ToString();
                    aModel.EndTime = reader["EndTime"].ToString();
                    aList.Add(aModel);
                }
                reader.Close();
                con.Close();
                return aList;
            
            
        }

        public Appointment GetDoctorAppointment(int? id)
        {
            string query = @"SELECT [ScheduleId]
      ,[DoctorId]
      ,CONVERT(varchar, AppointmentDate, 101) as date
      ,[StartTime]
      ,[EndTime]
  FROM [dbo].[DrSchedule] where ScheduleId='" + id + "'";
            SqlCommand cmd=new SqlCommand(query,con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Appointment appointment=new Appointment();
            while (reader.Read())
            {
                appointment.ScheduleId = (int) reader["ScheduleId"];
                appointment.DoctorId = (int)reader["DoctorId"];
                appointment.AppointmentDate = Convert.ToDateTime(reader["date"].ToString());
                appointment.StartTime = reader["StartTime"].ToString();
                appointment.EndTime = reader["EndTime"].ToString();
                
            }
            reader.Close();
            con.Close();
            return appointment;
        }

        public int GetAppointment(Appointment appointment)
        {
            string query = @"INSERT INTO [dbo].[Appointment]
           ([ScheduleId]
           ,[DoctorId]
           ,[PatientId]
           ,[Date]
           ,[StartTime]
           ,[EndTime]
           ,[Status])
     VALUES ('"+appointment.ScheduleId+"','" + appointment.DoctorId + "','" + appointment.PateintId + "','" + appointment.AppointmentDate + "','" + appointment.StartTime + "','" + appointment.EndTime + "','" + appointment.Status + "')";
            SqlCommand cmd=new SqlCommand(query, con);
            con.Open();
            int rowAffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowAffected;
        }

        public bool IsScheduleExist(Appointment appointment)
        {
            string query = @"SELECT * FROM [dbo].[Appointment] WHERE (ScheduleId=@ScheduleId and PatientId=@PatientId)";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            bool isExist = false;
            cmd.Parameters.AddWithValue("@ScheduleId", appointment.ScheduleId);
            cmd.Parameters.AddWithValue("@PatientId", appointment.PateintId);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            isExist = reader.HasRows;
            reader.Close();
            con.Close();
            return isExist;
        }

        public List<CheckStatusViewModel> GetAppointmentById(int id)
        {
            string query = @"SELECT a.Date,a.StartTime,a.EndTime,a.Status,p.DoctorName,s.SpecialityName
FROM [dbo].[Appointment] a inner join [dbo].[DrRegistration] p on a.DoctorId=p.Id
inner join [dbo].[Speciality]  s on s.Id=p.SpecialityId
                   where a.PatientId='" + id+"'";
            SqlCommand cmd=new SqlCommand(query,con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<CheckStatusViewModel> alList = new List<CheckStatusViewModel>();
            while (reader.Read())
            {
                CheckStatusViewModel appointment = new CheckStatusViewModel();
                appointment.DoctorName = reader["DoctorName"].ToString();
                appointment.Speciality = reader["SpecialityName"].ToString();
                appointment.AppointmentDate = reader["Date"].ToString();
                appointment.StartTime = reader["StartTime"].ToString();
                appointment.EndTime = reader["EndTime"].ToString();
                appointment.Status = reader["Status"].ToString();
                alList.Add(appointment);
                
            }
            reader.Close();
            con.Close();
            return alList;
        }

        public List<CheckStatusViewModel> GetAllSubmitttedAppointment()
        {
            string query = @"SELECT a.Id, a.PatientId,a.ScheduleId, a.Date,a.StartTime,a.EndTime,a.Status,p.DoctorName,s.SpecialityName
                            FROM [dbo].[Appointment] a inner join [dbo].[DrRegistration] p on a.DoctorId=p.Id
                            inner join [dbo].[Speciality]  s on s.Id=p.SpecialityId
                            where Status='Submit'";
            SqlCommand cmd=new SqlCommand(query,con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<CheckStatusViewModel> alList = new List<CheckStatusViewModel>();
            while (reader.Read())
            {
                CheckStatusViewModel appointment = new CheckStatusViewModel();
                appointment.AppointmentId = (int)reader["Id"];
                appointment.PatientId = (int) reader["PatientId"];
                appointment.ScheduleId = (int)reader["ScheduleId"];
                appointment.DoctorName = reader["DoctorName"].ToString();
                appointment.Speciality = reader["SpecialityName"].ToString();
                appointment.AppointmentDate = reader["Date"].ToString();
                appointment.StartTime = reader["StartTime"].ToString();
                appointment.EndTime = reader["EndTime"].ToString();
                appointment.Status = reader["Status"].ToString();
                alList.Add(appointment);
                
            }
            reader.Close();
            con.Close();
            return alList;

        }

        public int Approve(int appointmentId)
        {
            string query = @"update [dbo].[Appointment] set Status='Approved'
                           where Id='" + appointmentId + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int rowAffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowAffected;

        }

        public int Reject(int appointmentId)
        {
            string query = @"update [dbo].[Appointment] set Status='Reject'
                           where Id='" + appointmentId + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int rowAffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowAffected;
        }

        public List<CheckStatusViewModel> GetAllApprovedAppointment()
        {
            string query = @"SELECT a.Id, a.PatientId,a.ScheduleId, a.Date,a.StartTime,a.EndTime,a.Status,p.DoctorName,s.SpecialityName
                            FROM [dbo].[Appointment] a inner join [dbo].[DrRegistration] p on a.DoctorId=p.Id
                            inner join [dbo].[Speciality]  s on s.Id=p.SpecialityId
                            where Status='Approved'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<CheckStatusViewModel> alList = new List<CheckStatusViewModel>();
            while (reader.Read())
            {
                CheckStatusViewModel appointment = new CheckStatusViewModel();
                appointment.AppointmentId = (int)reader["Id"];
                appointment.PatientId = (int)reader["PatientId"];
                appointment.ScheduleId = (int)reader["ScheduleId"];
                appointment.DoctorName = reader["DoctorName"].ToString();
                appointment.Speciality = reader["SpecialityName"].ToString();
                appointment.AppointmentDate = reader["Date"].ToString();
                appointment.StartTime = reader["StartTime"].ToString();
                appointment.EndTime = reader["EndTime"].ToString();
                appointment.Status = reader["Status"].ToString();
                alList.Add(appointment);

            }
            reader.Close();
            con.Close();
            return alList;
        }
        public List<CheckStatusViewModel> GetAllRejectedAppointment()
        {
            string query = @"SELECT a.Id, a.PatientId,a.ScheduleId, a.Date,a.StartTime,a.EndTime,a.Status,p.DoctorName,s.SpecialityName
                            FROM [dbo].[Appointment] a inner join [dbo].[DrRegistration] p on a.DoctorId=p.Id
                            inner join [dbo].[Speciality]  s on s.Id=p.SpecialityId
                            where Status='Reject'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<CheckStatusViewModel> alList = new List<CheckStatusViewModel>();
            while (reader.Read())
            {
                CheckStatusViewModel appointment = new CheckStatusViewModel();
                appointment.AppointmentId = (int)reader["Id"];
                appointment.PatientId = (int)reader["PatientId"];
                appointment.ScheduleId = (int)reader["ScheduleId"];
                appointment.DoctorName = reader["DoctorName"].ToString();
                appointment.Speciality = reader["SpecialityName"].ToString();
                appointment.AppointmentDate = reader["Date"].ToString();
                appointment.StartTime = reader["StartTime"].ToString();
                appointment.EndTime = reader["EndTime"].ToString();
                appointment.Status = reader["Status"].ToString();
                alList.Add(appointment);

            }
            reader.Close();
            con.Close();
            return alList;
        }

        public List<CheckStatusViewModel> GetEmail(int appointmentId)
        {
            string query = @"select a.Date,a.StartTime,a.EndTime,p.PatientName,p.Email
                            from Appointment a
                            inner join [dbo].[PtRegistration] p on p.Id=a.PatientId
                            where a.Id='"+appointmentId+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<CheckStatusViewModel> alList = new List<CheckStatusViewModel>();
            while (reader.Read())
            {
                CheckStatusViewModel appointment = new CheckStatusViewModel();
                appointment.PatientName = reader["PatientName"].ToString();
                appointment.AppointmentDate = reader["Date"].ToString();
                appointment.StartTime = reader["StartTime"].ToString();
                appointment.EndTime = reader["EndTime"].ToString();
                appointment.PatientEmail = reader["Email"].ToString();
                alList.Add(appointment);

            }
            reader.Close();
            con.Close();
            return alList;
        }
        public List<CheckStatusViewModel> GetsubmitedEmail(int appointmentId)
        {
            string query = @"select a.Date,a.StartTime,a.EndTime,p.PatientName,p.Email
                            from [dbo].[PtRegistration] p
                            inner join [dbo].[Appointment] a on p.Id=a.PatientId
                            where p.Id='" + appointmentId + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<CheckStatusViewModel> alList = new List<CheckStatusViewModel>();
            while (reader.Read())
            {
                CheckStatusViewModel appointment = new CheckStatusViewModel();
                appointment.PatientName = reader["PatientName"].ToString();
                appointment.AppointmentDate = reader["Date"].ToString();
                appointment.StartTime = reader["StartTime"].ToString();
                appointment.EndTime = reader["EndTime"].ToString();
                appointment.PatientEmail = reader["Email"].ToString();
                alList.Add(appointment);

            }
            reader.Close();
            con.Close();
            return alList;
        }

    }
}