using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HospitalSystem.Model;
using HospitalSystem.Backend.Business.Interfaces;
using HospitalSystem.Backend.Utilities;
using Microsoft.Extensions.Options;
using System.Globalization;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace HospitalSystem.Controllers
{
    public class LoginController : Controller
    {
        private IBusinessUser _businessUser;
        private readonly AppSettings _appSettings;
        private readonly IHostingEnvironment _env;

        public LoginController(IOptions<AppSettings> appSettings, IBusinessUser businessUser, IHostingEnvironment env)
        {
            _businessUser = businessUser;
            _appSettings = appSettings.Value;
            _env = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetUserInfo(string username)
        //public async Task<IActionResult> SaveDoctor([FromBody] Doctor request)
        {
            //Verification.
            if (!this.User.Identity.IsAuthenticated)
            {
                // Home Page.  
                return Json(null);
            }

            var result = _businessUser.GetUserInfo(username).Result;

            if (result == null) return Json(null);

            string pathServer = Path.Combine(_env.WebRootPath, "Files", "Doctor");
            result.SFIRSTNAME = (CultureInfo.InvariantCulture.TextInfo.ToTitleCase(result.SFIRSTNAME));
            result.SSECONDNAME = (CultureInfo.InvariantCulture.TextInfo.ToTitleCase(result.SSECONDNAME));
            result.SLASTNAME = (CultureInfo.InvariantCulture.TextInfo.ToTitleCase(result.SLASTNAME));
            result.SLASTNAME1 = (CultureInfo.InvariantCulture.TextInfo.ToTitleCase(result.SLASTNAME1));

            //string fullPathImage = string.Format("{0}{1}", Utils.GetPathDoctor(), result.SPATHIMAGE);
            string fullPathImage = string.Format("{0}/{1}", pathServer, result.SPATHIMAGE);

            if (System.IO.File.Exists(fullPathImage))
            {
                Byte[] bytes = System.IO.File.ReadAllBytes(fullPathImage);
                result.base64image = Convert.ToBase64String(bytes);
            }

            return Json(result);
        }

        [BindProperty]
        public LoginViewModel LoginModel { get; set; }

        [HttpPost]
        public async Task<IActionResult> OnPostLogIn()
        {
            try
            {
                var x = LoginModel;

                if (ModelState.IsValid)
                {

                    var result = _businessUser.Authenticate(LoginModel.Username, LoginModel.Password);

                    if (result.Result.resultado == 0)
                    {
                        // Login In.  
                        await this.SignInUser(LoginModel.Username, true, result.Result.nidprocess);

                       // HttpContext.Session.Set("xxx", Convert.ToByte(resultDoctor.Result));
                        

                        // Info.  
                        return this.RedirectToAction("Index", "Home");
                    }
                    TempData["Message"] = result.Result.mensaje;
                } else TempData["Message"] = "Debe llenar ambos campos";
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }

            return this.RedirectToAction("Index", "Login");
        }

        private async Task SignInUser(string username, bool isPersistent, int idUser)
        {
            // Initialization.  
            var claims = new List<Claim>();

            try
            {
                // Setting  
                claims.Add(new Claim(ClaimTypes.Name, username));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, idUser.ToString()));
                var claimIdenties = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimPrincipal = new ClaimsPrincipal(claimIdenties);
                var authenticationManager = Request.HttpContext;

                // Sign In.  
                await authenticationManager.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal, new AuthenticationProperties() { IsPersistent = isPersistent });
            }
            catch (Exception ex)
            {
                // Info  
                throw ex;
            }
        }

        public async Task<IActionResult> LogOff()
        {
            try
            {
                // Setting.  
                var authenticationManager = Request.HttpContext;

                // Sign Out.  
                await authenticationManager.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            catch (Exception ex)
            {
                // Info  
                throw ex;
            }

            // Info.  
            return this.RedirectToAction("Index", "Login");
        }
    }
}
