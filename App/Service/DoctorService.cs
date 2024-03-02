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
    public class DoctorService
    {
        private AppDbContext _dbcontext;

        public DoctorService()
        {
            _dbcontext = new AppDbContext();
        }

        public void CreateDoctor(Doctor doctor)
        {
            if (_dbcontext.Doctors.Any(x => x.Email == doctor.Email))
            {
                throw new EntityDublicateException("Doctor already exists with email: " + doctor.Email);
            }
            _dbcontext.Doctors.Add(doctor);
            _dbcontext.SaveChanges();
        }


        public Doctor GetById(int id)
        {
            var entity = _dbcontext.Doctors.FirstOrDefault(x => x.Id == id);

            if (entity == null) throw new EntityNotFoundException("Doctor not found");
            
           return entity;
        }
        public List<Doctor> GetAllDoctors()
        {
            return _dbcontext.Doctors.ToList();
        }

        public void UpdateDoctor(int id, Doctor updatedDoctor)
        {
            var existingDoctor = _dbcontext.Doctors.FirstOrDefault(x => x.Id == id);

            if (existingDoctor == null)
            {
                throw new EntityNotFoundException("Doctor not found");
            }
            existingDoctor.Email = updatedDoctor.Email;
            existingDoctor.Fullname = updatedDoctor.Fullname;
            _dbcontext.SaveChanges();
        }

        public void DeleteDoctor(int id)
        {
            var doctorToDelete = _dbcontext.Doctors.FirstOrDefault(x => x.Id == id);

            if (doctorToDelete == null)
            {
                throw new EntityNotFoundException("Doctor not found");
            }
            _dbcontext.Doctors.Remove(doctorToDelete);
            _dbcontext.SaveChanges();
        }
    }
}
