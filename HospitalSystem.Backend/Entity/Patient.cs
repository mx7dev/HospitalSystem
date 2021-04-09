using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalSystem.Backend.Entity
{
    public class Patient
    {
        public int NIDPATIENT { get; set; }
        public string SCOMPLETENAME { get; set; }
        public string SFIRSTNAME { get; set; }
        public string SSECONDNAME { get; set; }
        public string SLASTNAME { get; set; }
        public string SLASTNAME1 { get; set; }
        public string SBIRTHDATE { get; set; }
        public DateTime DBIRTHDATE { get; set; }
        public string SGENDER { get; set; }
        public string SDESCRIPTION { get; set; }
        public string NPHONE { get; set; }
        public string SEMAIL { get; set; }
        public string base64Image { get; set; }
        public string SPATHIMAGE { get; set; }
        public DateTime DREGISTER { get; set; }
    }
}
