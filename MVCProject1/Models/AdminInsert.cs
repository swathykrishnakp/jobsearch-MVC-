using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProject1.Models
{
    public class AdminInsert
    {
        [Required(ErrorMessage = "Enter the name")]
        public string name { get; set; }
        [Required(ErrorMessage = "Enter the address")]

        public string address { get; set; }
        [Required(ErrorMessage = "Enter the phone number")]
        //[RegularExpression(@"^(\d{10}$",ErrorMessage ="Enter valid number")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Enter valid number")]
        public string phone { get; set; }
        [EmailAddress(ErrorMessage = "Enter valid email id")]
        public string email { get; set; }
        public string username { get; set; }
        public string pass { get; set; }
        [Compare("pass", ErrorMessage = "Password mismatch")]
        public string cpassword { get; set; }
        public string adminmsg { get; set; }
    }
}