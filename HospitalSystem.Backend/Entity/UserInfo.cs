using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalSystem.Backend.Entity
{
    public class UserInfo
    {
        public int NIDDOCTOR { get; set; }
        public int NIDUSER { get; set; }
        public string SFIRSTNAME { get; set; }
        public string SSECONDNAME { get; set; }
        public string SLASTNAME { get; set; }
        public string SLASTNAME1 { get; set; }
        public string SEMAIL { get; set; }
        public string SPATHIMAGE { get; set; }
        public string base64image { get; set; }
        public int NVISITS { get; set; }
        public int NPATIENTS { get; set; }
        public int PENDINGS { get; set; }
    }
}
