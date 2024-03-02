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
        

        //public void MakeApointment(Apointment apointment)
        //{
        //    if(_dbcontext.Doctors.FirstOrDefault(x => x.Id == _dbcontext.DoctorId) == null)
        //    {
        //        throw new EntityNotFoundException("Doctor not found!");

        //    }
                
        //}
    }
}
