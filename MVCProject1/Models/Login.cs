using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProject1.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Enter user name")]
        public string Uname { set; get; }
        [Required(ErrorMessage = "Enter upassword")]

        public string Password { set; get; }
        public string msg { set; get; }
        public string ltype { set; get; }
    }
}