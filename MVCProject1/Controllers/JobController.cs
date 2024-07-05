using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProject1.Models;

namespace MVCProject1.Controllers
{
    public class JobController : Controller
    {
        MVCProjectEntities dbobj = new MVCProjectEntities();
        // GET: Job
        public ActionResult Insertjob_Pageload()
        {
            
            return View();
        }
        public ActionResult Insertjob_click(Jobinsertion clsobj)
        {
            if (ModelState.IsValid)
            {
                if (Session["uid"] != null)
                {
                    int companyId = (int)Session["uid"];

                    dbobj.sp_insertjob(companyId, clsobj.Jtittle, clsobj.JExp, clsobj.JSkill, clsobj.jVacc, clsobj.ldate, clsobj.jStatus);
                    clsobj.jmsg = "Job successfully inserted";
                }
                else
                {
                    clsobj.jmsg = "Company ID not found in session. Please insert company first.";
                }

                return View("Insertjob_Pageload", clsobj);
            }
            return View("Insertjob_Pageload", clsobj);
        }
    }
}