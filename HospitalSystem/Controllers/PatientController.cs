using HospitalSystem.Backend.Business.Interfaces;
using HospitalSystem.Backend.Entity;
using HospitalSystem.Backend.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HospitalSystem.Controllers
{
    public class PatientController : Controller
    {
        private IBusinessPatient _businessPatient;
        private readonly AppSettings _appSettings;
        private readonly IHostingEnvironment _env;

        public PatientController(IOptions<AppSettings> appSettings, IBusinessPatient businessPatient, IHostingEnvironment env)
        {
            _businessPatient = businessPatient;
            _appSettings = appSettings.Value;
            _env = env;
        }
        public IActionResult Index()
        {
            var result = _businessPatient.FindAllPatients().Result;
            ViewBag.ListPatient = result;
            return View();
        }

        //Actions
        [HttpPost]
        public JsonResult SavePatient()//(Doctor request, object files)//IList<IFormFile> files)
        {
            var files = Request.Form.Files;
            string flagEdit = Request.Form.Where(x => x.Key == "flagEdit").FirstOrDefault().Value;
            string fullPath = string.Empty;
            string newName = string.Empty;
            string pathServer = Path.Combine(_env.WebRootPath, "Files", "Patient");

            foreach (IFormFile source in Request.Form.Files)
            {
                newName = Utils.GenerateNameAleatory();
                fullPath = string.Format("{0}/{1}", pathServer, newName);

                string filename = ContentDispositionHeaderValue.Parse(source.ContentDisposition).FileName.Trim('"');

                newName += Path.GetExtension(filename);
                fullPath = string.Format("{0}{1}", fullPath, Path.GetExtension(filename));

                using (FileStream output = System.IO.File.Create(fullPath))
                    source.CopyToAsync(output);
                break;
            }

            string jsonData = Request.Form.Where(x => x.Key == "json").FirstOrDefault().Value;
            Patient request = Newtonsoft.Json.JsonConvert.DeserializeObject<Patient>(jsonData);
            string pathPatientPast = request.SPATHIMAGE;
            request.SPATHIMAGE = newName;
            var result = _businessPatient.SavePatient(request).Result;

            if (result.resultado == 0)//si resultado es erroneo
            {
                if (System.IO.File.Exists(fullPath)) System.IO.File.Delete(fullPath);
            }
            else
            {
                if (request.SPATHIMAGE != "" && fullPath != "")
                {
                    if (System.IO.File.Exists(pathServer + "/" + pathPatientPast)) System.IO.File.Delete(pathServer + "/" + pathPatientPast);
                }
            }

            return Json(new
            {
                data = result
            });
        }

        [HttpGet]
        public JsonResult GetPatientById(int nidpatient)
        //public async Task<IActionResult> SaveDoctor([FromBody] Doctor request)
        {
            var result = _businessPatient.FindPatientById(nidpatient).Result;
            result.SFIRSTNAME = (CultureInfo.InvariantCulture.TextInfo.ToTitleCase(result.SFIRSTNAME));
            result.SSECONDNAME = (CultureInfo.InvariantCulture.TextInfo.ToTitleCase(result.SSECONDNAME));
            result.SLASTNAME = (CultureInfo.InvariantCulture.TextInfo.ToTitleCase(result.SLASTNAME));
            result.SLASTNAME1 = (CultureInfo.InvariantCulture.TextInfo.ToTitleCase(result.SLASTNAME1));

            result.SCOMPLETENAME = string.Format("{0} {1}{2} {3}", result.SFIRSTNAME, result.SSECONDNAME == string.Empty ? "" : result.SSECONDNAME + " ", result.SLASTNAME, result.SLASTNAME1);

            string pathServer = Path.Combine(_env.WebRootPath, "Files", "Patient");
            string fullPathImage = string.Format("{0}/{1}", pathServer, result.SPATHIMAGE);

            if (System.IO.File.Exists(fullPathImage))
            {
                Byte[] bytes = System.IO.File.ReadAllBytes(fullPathImage);
                result.base64Image = Convert.ToBase64String(bytes);
            }
            return Json(new
            {
                patient = result
            });
        }

        [HttpDelete]
        public JsonResult DeletePatient(int nidpatient)
        //public async Task<IActionResult> SaveDoctor([FromBody] Doctor request)
        {
            var result = _businessPatient.Delete(nidpatient).Result;
            return Json(new
            {
                data = result
            });
        }
    }
}
