using HospitalSystem.Backend.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Backend.Entity
{
    public class Appointment 
    {
        public int NIDPATIENT { get; set; }
        public int NIDDOCTOR { get; set; }
        public string SCOMENT { get; set; }
        public DateTime DAPPOINTMENT { get; set; }
        public string cadenaConfigHoras { get; set; }

        public int NIDAPPOINTMENT { get; set; }
        public string SPATIENTNAME { get; set; }
        public string SINITAPPOINTMENT { get; set; }
    }

    public class AppointmentDetail
    {
        public int NIDAPPOINTMENT { get; set; }
        public string SNAMEPATIENT { get; set; }
        public string SVALUEINI { get; set; }
        public string SVALUEFIN { get; set; }
        public string SCOMENT { get; set; }
    }
}
