using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProject1.Models
{
    public class Apply
    {
        public int App_Id { get; set; }
        public int User_Id { get; set; }
        public int Comp_Id { get; set; }

        public int Job_Id { get; set; }
        //[Required(ErrorMessage ="Insert CV")]
        public string CV { get; set; }
        public string App_Date { get; set; }
        public string Status { get; set; }
        public string apmsg { get; set; }
    }
}