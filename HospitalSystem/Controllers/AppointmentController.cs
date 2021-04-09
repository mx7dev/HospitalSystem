using HospitalSystem.Backend.Business.Interfaces;
using HospitalSystem.Backend.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalSystem.Backend.Entity;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace HospitalSystem.Controllers
{
    [Authorize]
    public class AppointmentController : Controller
    {
        private IBusinessAppointment _businessAppointment;
        private IBusinessPatient _businessPatient;
        private readonly AppSettings _appSettings;

        public AppointmentController(IOptions<AppSettings> appSettings, IBusinessAppointment businessAppointment, IBusinessPatient businessPatient)
        {
            _businessAppointment = businessAppointment;
            _businessPatient = businessPatient;
            _appSettings = appSettings.Value;            
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetHours(int idPatient, string date)
        {
            //get info doctor
            var identity = (ClaimsIdentity)this.User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            int nidDoctor = Convert.ToInt32(claims.ToList()[1].Value);

            var result = _businessAppointment.GetHours(nidDoctor, idPatient, Convert.ToDateTime(date)).Result;
            //var result = _businessAppointment.GetHours(18, idPatient, Convert.ToDateTime(date)).Result;

            return Json(new
            {
                lista = result
            });
        }

        [HttpGet]
        public JsonResult GetPatients(int idPatient, string date)
        {
            var result = _businessPatient.FindAllPatients().Result;

            result.ToList().ForEach(res => { 
                res.SCOMPLETENAME = string.Format("{0} {1}{2} {3}", res.SFIRSTNAME, res.SSECONDNAME == string.Empty ? "" : res.SSECONDNAME + " ", res.SLASTNAME, res.SLASTNAME1);
            });

            return Json(new
            {
                lista = result
            });
        }

        [HttpPost]
        public JsonResult SaveAppointment(int idPatient, string scomment, string sidsHours, string date)
        {
            //get info doctor
            var identity = (ClaimsIdentity)this.User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            int nidDoctor = Convert.ToInt32(claims.ToList()[1].Value);

            Appointment objAppointment = new Appointment() { 
                NIDPATIENT = idPatient,
                DAPPOINTMENT = Convert.ToDateTime(date),
                //NIDDOCTOR = 18,
                NIDDOCTOR = nidDoctor,
                cadenaConfigHoras = sidsHours,
                SCOMENT = scomment
            };
            var result = _businessAppointment.SaveAppointment(objAppointment);

            return Json(new
            {
                data = result
            });
        }

        [HttpGet]
        public JsonResult GetAppointments(string date)
        {
            //get info doctor
            var identity = (ClaimsIdentity)this.User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            int nidDoctor = Convert.ToInt32(claims.ToList()[1].Value);

            //var result = _businessAppointment.FindAppointments(Convert.ToDateTime(date), 18).Result;
            var result = _businessAppointment.FindAppointments(Convert.ToDateTime(date), nidDoctor).Result;

            return Json(new
            {
                lista = result
            });
        }

        [HttpGet]
        public JsonResult GetAppointmentById(int idAppointment)
        {
            var result = _businessAppointment.FindAppointmentById(idAppointment).Result;            

            return Json(result);
        }

        [HttpDelete]
        public JsonResult DeleteAppointment(int nidAppointment)
        {
            var result = _businessAppointment.Delete(nidAppointment).Result;
            return Json(result);
        }
    }
}
