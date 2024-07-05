using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProject1.Models;

namespace MVCProject1.Controllers
{
    public class ApplyCVController : Controller
    {
        MVCProjectEntities dbobj = new MVCProjectEntities();
        // GET: ApplyCV
        public ActionResult Apply_Pageload(int jid,int cid)
        {
            ViewBag.JobId = jid;
            ViewBag.companyid = cid;
            Session["job_id"] = jid;
            Session["com_id"] = cid;
            return View();
        }
        public ActionResult Apply_Click(Apply clsobj, HttpPostedFileBase uresumeFile)
        {
            if (ModelState.IsValid)
            {

                if (uresumeFile.ContentLength > 0)
                {
                    string resumeName = Path.GetFileName(uresumeFile.FileName);
                    var resumePath = Server.MapPath("~/cv");
                    string resumeFullPath = Path.Combine(resumePath, resumeName);
                    uresumeFile.SaveAs(resumeFullPath);
                    clsobj.CV = Path.Combine("\\cv", resumeName);
                }
                if (Session["uid"] != null)
                {

                    int jobId = (int)Session["job_id"];
                    int userid = (int)Session["uid"];
                    int companyid = (int)Session["com_id"];
                    dbobj.sp_InsertApp(userid, companyid, jobId, clsobj.CV, clsobj.App_Date, clsobj.Status);
                    clsobj.apmsg = "Application successfully Sended";
                }
            }
            else
            {
                clsobj.apmsg = "error";
            }

            //return View("Apply_Pageload", clsobj);
            return View("ApplyHome", clsobj);


        }
        public ActionResult ApplyHome()
        {
           
            return View();
        }
    }
}