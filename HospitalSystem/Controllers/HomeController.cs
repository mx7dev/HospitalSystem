using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalSystem.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //Verification.
            if (!this.User.Identity.IsAuthenticated)
            {
                // Home Page.  
                return this.RedirectToAction("Index", "Login");
            }

            return this.RedirectToAction("Index", "Appointment");
        }

    }
}
