using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Patient
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public List<Apointment> Apointments { get; set; }
    }
}
