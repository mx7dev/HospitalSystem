using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalSystem.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class LoginViewModel
    {  
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public bool isPersistent { get; set; }
    }
}
