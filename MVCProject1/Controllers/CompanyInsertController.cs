using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProject1.Models;

namespace MVCProject1.Controllers
{
    public class CompanyInsertController : Controller
    {
        MVCProjectEntities dbobj=new MVCProjectEntities();
        // GET: CompanyReg
        public ActionResult Insertcompany_Pageload()
        {
            return View();
        }
        
        public ActionResult Insertcompany_click(CompanyInsert clsobj)
        {
            if (ModelState.IsValid)
            {
                var getmaxid = dbobj.sp_MaxIdCompany().FirstOrDefault();
                int mid = Convert.ToInt32(getmaxid);
                int regid = 0;
                if (mid == 0)
                {
                    regid = 1;
                }
                else
                {
                    regid = mid + 1;
                }
                dbobj.sp_insertcompany(regid, clsobj.cname, clsobj.caddress, clsobj.cphone, clsobj.cwebsite,clsobj.cemail,clsobj.clocation);
                dbobj.sp_loginsert(regid, clsobj.username, clsobj.pass, "company");
                clsobj.commsg = "successfuly inserted";

                Session["CompanyId"] = regid;

                return View("Insertcompany_Pageload", clsobj);
            }
            return View("Insertcompany_Pageload", clsobj);
        }






    }
}