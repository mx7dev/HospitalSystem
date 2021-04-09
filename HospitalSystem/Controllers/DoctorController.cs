using HospitalSystem.Backend.Business.Interfaces;
using HospitalSystem.Backend.Entity;
using HospitalSystem.Backend.Utilities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using Newtonsoft;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.IO;
using System.Globalization;
using Microsoft.AspNetCore.Hosting;

namespace HospitalSystem.Controllers
{
    //[EnableCors("AllowCors")]
    [Authorize]
    public class DoctorController : Controller
    {
        private IBusinessDoctor _businessDoctor;
        private readonly AppSettings _appSettings;
        private readonly IHostingEnvironment _env;

        public DoctorController(IOptions<AppSettings> appSettings, IBusinessDoctor businessDoctor, IHostingEnvironment env)
        {
            _businessDoctor = businessDoctor;
            _appSettings = appSettings.Value;
            _env = env;
        }

        public IActionResult Index()
        {
            var result = _businessDoctor.FindAllDoctors().Result;
            ViewBag.ListDoctor = result;
            return View();
        }


        //Actions

        [HttpPost]
        public JsonResult SaveDoctor()//(Doctor request, object files)//IList<IFormFile> files)
        {
            var files = Request.Form.Files;
            string flagEdit = Request.Form.Where(x => x.Key == "flagEdit").FirstOrDefault().Value;
            string fullPath = string.Empty;
            string newName = string.Empty;
            string pathServer = Path.Combine(_env.WebRootPath, "Files", "Doctor");

            foreach (IFormFile source in Request.Form.Files)
            {
                newName = Utils.GenerateNameAleatory();
                //fullPath = string.Format("{0}{1}", Utils.GetPathDoctor(), newName);
                //fullPath = string.Format("{0}{1}", _appSettings.pathDoctor, newName);
                fullPath = string.Format("{0}/{1}", pathServer, newName);

                string filename = ContentDispositionHeaderValue.Parse(source.ContentDisposition).FileName.Trim('"');

                newName += Path.GetExtension(filename);
                fullPath = string.Format("{0}{1}", fullPath, Path.GetExtension(filename));

                using (FileStream output = System.IO.File.Create(fullPath))
                     source.CopyToAsync(output);
                break;
            }

            string jsonData = Request.Form.Where(x => x.Key == "json").FirstOrDefault().Value;
            Doctor request = Newtonsoft.Json.JsonConvert.DeserializeObject<Doctor>(jsonData);
            string pathDoctorPast = request.SPATHIMAGE;
            request.SPATHIMAGE = newName;
            var result = _businessDoctor.SaveDoctor(request).Result;

            if (result.resultado == 0)//si resultado es erroneo
            {
                if (System.IO.File.Exists(fullPath)) System.IO.File.Delete(fullPath);
            } else
            {
                if (request.SPATHIMAGE != "" && fullPath != "")
                {
                    //if (System.IO.File.Exists(Utils.GetPathDoctor() + pathDoctorPast)) System.IO.File.Delete(Utils.GetPathDoctor() + pathDoctorPast);
                    if (System.IO.File.Exists(pathServer + "/" + pathDoctorPast)) System.IO.File.Delete(pathServer + "/" + pathDoctorPast);
                }
            }

            return Json(new
            {
                data = result
            });
        }

        [HttpGet]
        public JsonResult GetAllDoctor()
        //public async Task<IActionResult> SaveDoctor([FromBody] Doctor request)
        {
            var result = _businessDoctor.FindAllDoctors().Result;

            return Json(new
            {
                lista = result
            });
        }

        [HttpGet]       
        public JsonResult GetDoctorById(int niddoctor)
        //public async Task<IActionResult> SaveDoctor([FromBody] Doctor request)
        {
            var result = _businessDoctor.FinDoctorById(niddoctor).Result;
            result.SFIRSTNAME = (CultureInfo.InvariantCulture.TextInfo.ToTitleCase(result.SFIRSTNAME));
            result.SSECONDNAME = (CultureInfo.InvariantCulture.TextInfo.ToTitleCase(result.SSECONDNAME));
            result.SLASTNAME = (CultureInfo.InvariantCulture.TextInfo.ToTitleCase(result.SLASTNAME));
            result.SLASTNAME1 = (CultureInfo.InvariantCulture.TextInfo.ToTitleCase(result.SLASTNAME1));
            result.SSPECIALITY = (CultureInfo.InvariantCulture.TextInfo.ToTitleCase(result.SSPECIALITY));

            result.SCOMPLETENAME = string.Format("{0} {1}{2} {3}", result.SFIRSTNAME, result.SSECONDNAME == string.Empty ? "" : result.SSECONDNAME + " ", result.SLASTNAME, result.SLASTNAME1);

            string pathServer = Path.Combine(_env.WebRootPath, "Files", "Doctor");
            //string fullPathImage = string.Format("{0}{1}", Utils.GetPathDoctor(), result.SPATHIMAGE);
            string fullPathImage = string.Format("{0}/{1}", pathServer, result.SPATHIMAGE);

            if (System.IO.File.Exists(fullPathImage))
            {
                Byte[] bytes = System.IO.File.ReadAllBytes(fullPathImage);
                result.base64Image = Convert.ToBase64String(bytes);
            }

            return Json(new
            {
                doctor = result
            });
        }

        [HttpDelete]
        public JsonResult Deletedoctor(int niddoctor)
        //public async Task<IActionResult> SaveDoctor([FromBody] Doctor request)
        {
            var result = _businessDoctor.Delete(niddoctor).Result;
            return Json(new
            {
                data = result
            });
        }
    }
}
