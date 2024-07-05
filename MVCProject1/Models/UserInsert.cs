using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProject1.Models
{


    public class CheckBoxListHelper
    {
        public string Value { get; set; }
        public string Text { get; set; }
        public bool IsChecked { get; set; }
    }
    public class UserInsert
    {


        public List<CheckBoxListHelper> MyFavoriteQual { get; set; }
        public string[] selectedQual { get; set; }


        [Required(ErrorMessage = "Enter username")]
        public string uname { get; set; }
        [Range(18, 50, ErrorMessage = "Enter a valid age")]
        public int uage{ get; set; }
        [Required(ErrorMessage = "Enter user address")]
        public string uaddress { get; set; }
        [EmailAddress(ErrorMessage = "Enter valid email id")]
        public string uemail { get; set; }
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Enter valid number")]

        public string uphone{ get; set; }
        public string uphoto { get; set; }
       
        public string uqual { get; set; }
        
        public int uexp { get; set; }
       
        public string uskill { get; set; }
        public string uresume { get; set; }
        //public HttpPostedFileBase File { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Password mismatch")]
        public string CPassword { get; set; }
        public string umsg { get; set; }
    }
}