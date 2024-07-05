using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProject1.Models
{
    public class Jobinsertion
    {
        public int jId { get; set; }
        public int CId { get; set; }
        [Required(ErrorMessage = "Enter the jobtittle")]
        public string Jtittle { get; set; }
        public string JExp { get; set; }
        public string JSkill { get; set; }
        public int jVacc { get; set; }
       
        public string ldate { get; set; }
        public string jStatus { get; set; }
        public string jmsg { get; set; }
    }
}