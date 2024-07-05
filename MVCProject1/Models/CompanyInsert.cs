using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProject1.Models
{
    public class CompanyInsert
    {
        [Required(ErrorMessage ="Enter company name")]
        public string cname { get; set; }
        [Required(ErrorMessage = "Enter company address")]
        public string caddress { get; set; }
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Enter valid number")]

        public string cphone { get; set; }
        
        public string cwebsite { get; set; }
        [EmailAddress(ErrorMessage = "Enter valid email id")]

        public string cemail { get; set; }
        public string clocation { get; set; }

        public string username { get; set; }
        public string pass { get; set; }
        [Compare("pass", ErrorMessage = "Password mismatch")]
        public string cpassword { get; set; }
        public string commsg { get; set; }
    }
}