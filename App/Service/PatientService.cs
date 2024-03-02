using Core.Entities;
using Data;
using Microsoft.EntityFrameworkCore;
using Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public  class PatientService
    {
        private AppDbContext _dbcontext;

        public PatientService()
        {
            _dbcontext = new AppDbContext();
        }

        public void CreatePatient(Patient patient)
        {
            if (_dbcontext.Patients.Any(x => x.Email == patient.Email))
            {
                throw new EntityDublicateException("Patient already exists with email: " + patient.Email);
            }
            _dbcontext.Patients.Add(patient);
            _dbcontext.SaveChanges();
        }

        public Patient GetById(int id)
        {
            var entity = _dbcontext.Patients.FirstOrDefault(x => x.Id == id);

            if (entity == null) throw new EntityNotFoundException("Patient not found");

            return entity;
        }

        public List<Patient> GetAllPatients()
        {
            return _dbcontext.Patients.Include(x => x.Apointments).ToList();
        }

        public void UpdateDoctor(int id, Doctor updatedPatient)
        {
            var existingPatient = _dbcontext.Doctors.FirstOrDefault(x => x.Id == id);

            if (existingPatient == null)
            {
                throw new EntityNotFoundException("Patient not found");
            }
            existingPatient.Email = updatedPatient.Email;
            existingPatient.Fullname = updatedPatient.Fullname;
            _dbcontext.SaveChanges();
        }

        public void DeletePatient(int id)
        {
            var patientToDelete = _dbcontext.Patients.FirstOrDefault(x => x.Id == id);

            if (patientToDelete == null)
            {
                throw new EntityNotFoundException("Patient not found");
            }
            _dbcontext.Patients.Remove(patientToDelete);
            _dbcontext.SaveChanges();
        }
    }
}
