using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProject1.Models;

namespace MVCProject1.Controllers
{
    public class AdminRegController : Controller
    {
        // GET: AdminReg

        MVCProjectEntities dbobj = new MVCProjectEntities();
        public ActionResult Insertadmin_Pageload()
        {
            return View();
        }
        public ActionResult Insertadmin_click(AdminInsert clsobj)
        {
            if (ModelState.IsValid)
            {
                var getmaxid = dbobj.sp_MaxIdLogin().FirstOrDefault();
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
                dbobj.sp_adminReg(regid, clsobj.name, clsobj.address, clsobj.phone, clsobj.email);
                dbobj.sp_loginsert(regid, clsobj.username, clsobj.pass, "admin");
                clsobj.adminmsg = "successfuly inserted";

                return View("Insertadmin_Pageload", clsobj);
            }
            return View("Insertadmin_Pageload", clsobj);
        }
    }
}