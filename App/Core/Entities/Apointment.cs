using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Apointment
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public DateTime StartDate { get; set; }
    }
}
