using Core.Entities;
using Data;
using Microsoft.EntityFrameworkCore;
using Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ApointmentService
    {
        private AppDbContext _dbcontext;

        public ApointmentService()
        {
            _dbcontext = new AppDbContext();
        }

        public void CancelAppointment(int id)
        {
            var apointmentToRemove = _dbcontext.Apointments.FirstOrDefault(x => x.Id == id);

            if (apointmentToRemove == null)
            {
                throw new EntityNotFoundException("Apointment not found");
            }
            _dbcontext.Apointments.Remove(apointmentToRemove);
            _dbcontext.SaveChanges();
        }

        public Apointment GetById(int id)
        {
            var entity = _dbcontext.Apointments.FirstOrDefault(x => x.Id == id);

            if (entity == null) throw new EntityNotFoundException("Apointment not found");

            return entity;
        }

        public List<Apointment> GetAll()
        {
            return _dbcontext.Apointments.Include(x => x.Doctor).Include(x => x.Patient).ToList();
        }


        public void MakeApointment(Apointment apointment)
        {
            if (_dbcontext.Doctors.FirstOrDefault(x => x.Id == apointment.DoctorId) == null)
            {
                throw new EntityNotFoundException("Doctor not found!");
            }
            if (_dbcontext.Patients.FirstOrDefault(x => x.Id == apointment.PatientId) == null)
            {
                throw new EntityNotFoundException("Doctor not found!");
            }
            if (_dbcontext.Apointments.Any(x => x.StartDate == apointment.StartDate) == null)
            {
                throw new EntityNotFoundException("This time is not available!");
            }
            if (_dbcontext.Apointments.Any(x => x.StartDate.AddMinutes(30) >= apointment.StartDate && x.DoctorId == apointment.DoctorId))
            {
                throw new TimeNotAvailableException("This time is not available!");
            }
            _dbcontext.Apointments.Add(apointment);
            _dbcontext.SaveChanges();

        }
    }
}
