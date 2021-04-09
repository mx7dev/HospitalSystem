using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalSystem.Backend.Utilities
{
    public class Utils
    {
        public static string GenerateNameAleatory()
        {
            string name = DateTime.Now.ToString("ddmmyyyyhhmmss");
            return name;
        }

        public static string GetPathDoctor()
        {
            return "../HospitalSystem/wwwroot/Files/Doctor/";
        }

        public static string GetPathPatient()
        {
            return "../HospitalSystem/wwwroot/Files/Patient/";
        }
    }
}
