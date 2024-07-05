using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProject1.Models;

namespace MVCProject1.Controllers
{
    public class UALoginController : Controller
    {
        // GET: UALogin
        MVCProjectEntities dbobj = new MVCProjectEntities();
        public ActionResult Login_pageload()
        {
            return View();
        }
        public ActionResult UserHome()
        {
            return View();
        }
        public ActionResult CompanyHome()
        {
            return View();
        }
        public ActionResult Login_Click(Login objcls)
        {
            if (ModelState.IsValid)
            {
                ObjectParameter op = new ObjectParameter("status", typeof(int));
                dbobj.sp_login(objcls.Uname, objcls.Password, op);
                int val = Convert.ToInt32(op.Value);
                if (val == 1)
                {
                    var uid = dbobj.sp_loginId(objcls.Uname, objcls.Password).FirstOrDefault();
                    Session["uid"] = uid;
                    var lt = dbobj.sp_loginType(objcls.Uname, objcls.Password).FirstOrDefault();
                    if (lt == "user")
                    {
                        return RedirectToAction("UserHome");
                    }
                    else if (lt == "company")
                    {
                        return RedirectToAction("companyHome");
                    }
                }

            }
            else
            {
                ModelState.Clear();
                objcls.msg = "Invalid login";
                return View("Login_pageload", objcls);
            }

            return View("Login_pageload", objcls);
        }
       
    }
}