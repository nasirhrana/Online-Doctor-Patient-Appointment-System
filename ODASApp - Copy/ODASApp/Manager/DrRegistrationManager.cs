using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ODASApp.Gateway;
using ODASApp.Models;
using ODASApp.ViewModel;

namespace ODASApp.Manager
{
    public class DrRegistrationManager
    {
      private   DrRegstrationGateway aGateway=new DrRegstrationGateway();
        public int Save(DrRegistration aRegistration)
        {
            return aGateway.Save(aRegistration);
        }

        public int PtSave(PtRegistration aRegistration)
        {
            return aGateway.PtSave(aRegistration);
        }

        public List<DrRegistration> GetAll()
        {
            return aGateway.GetAll();
        }

        public DrRegistration Get(int? id)
        {
            return aGateway.Get(id);
        }

        public int Update(DrRegistration aRegistration)
        {
            return aGateway.Update(aRegistration);
        }

        public int Delete(int? id)
        {
            return aGateway.Delete(id);
        }

        public List<PtRegistration> GetAllPatient()
        {
            return aGateway.GetAllPatient();
        }

        public PtRegistration GetPatient(int? id)
        {
            return aGateway.GetPatient(id);
        }

        public int PtUpdate(PtRegistration aRegistration)
        {
            return aGateway.PtUpdate(aRegistration);
        }

        public int PtDelete(int? id)
        {
            return aGateway.PtDelete(id);
        }

        public int ScheduleSave(DrSchedule aSchedule)
        {
            return aGateway.ScheduleSave(aSchedule);
        }

        public bool IsDateExist(DrSchedule aSchedule)
        {
            return aGateway.IsDateExist(aSchedule);
        }

        public bool IsTimeExist(DrSchedule aSchedule)
        {
            return aGateway.IsTimeExist(aSchedule);
        }

        public List<SearchModel> GetDoctor(string search)
        {
            return aGateway.GetDoctor(search);
        }

        public List<Speciality> GetAllSpeciality()
        {
            return aGateway.GetAllSpeciality();
        }

        public List<DoctorViewModel> GetBySpecialityId(int specialityId)
        {
            return aGateway.GetBySpecialityId(specialityId);
        }
        public List<DoctorViewModel> GetDoctorById(int doctorId)
        {
            return aGateway.GetDoctorById(doctorId);
        }
    }
}