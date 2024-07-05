using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProject1.Models;

namespace MVCProject1.Controllers
{
    public class UserRegController : Controller
    {
        // GET: UserReg
        MVCProjectEntities dbobj = new MVCProjectEntities();
        public ActionResult Insert_Pageload()
        {

            UserInsert user = new UserInsert();
            user.MyFavoriteQual = getQualificationData();

            return View(user);
        }
            public List<CheckBoxListHelper> getQualificationData()
            {
                List<CheckBoxListHelper> sts = new List<CheckBoxListHelper>()
            {
                new CheckBoxListHelper{Value="SSLC",Text="SSLC",IsChecked=true},
                new CheckBoxListHelper{Value="PLUS TWO",Text="PLUS TWO",IsChecked=false},
                new CheckBoxListHelper{Value="BCA",Text="BCA",IsChecked=false},
                new CheckBoxListHelper{Value="MCA",Text="MCA",IsChecked=false},
                


                new CheckBoxListHelper{Value="BTECH",Text="BTECH",IsChecked=false},



            };
                return sts;
          }
          
        
        
        public ActionResult Insert_click(UserInsert clsobj, HttpPostedFileBase file, HttpPostedFileBase uresumeFile)
        {





            if (ModelState.IsValid)
            {

                //var quid = string.Join(",", clsobj.selectedQual);
                //clsobj.uqual = quid;
                //clsobj.MyFavoriteQual = getQualificationData();
                if (clsobj.selectedQual != null)
                {
                    var quid = string.Join(",", clsobj.selectedQual);
                    clsobj.uqual = quid;
                }
                clsobj.MyFavoriteQual = getQualificationData();


                if (file.ContentLength > 0)
                {
                    // save to folder
                    string fname = Path.GetFileName(file.FileName);
                    var s = Server.MapPath("~/photos");
                    string pa = Path.Combine(s, fname);
                    file.SaveAs(pa);
                    //for table save

                    var fullpath = Path.Combine("\\photos", fname);
                    clsobj.uphoto = fullpath;//set
                }



                if (uresumeFile.ContentLength > 0)
                {
                    string resumeName = Path.GetFileName(uresumeFile.FileName);
                    var resumePath = Server.MapPath("~/resumes");
                    string resumeFullPath = Path.Combine(resumePath, resumeName);
                    uresumeFile.SaveAs(resumeFullPath);
                    clsobj.uresume = Path.Combine("\\resumes", resumeName);
                }






                //var quid = string.Join(",", clsobj.selectedQual);
                //clsobj.uqual = quid;
                //clsobj.MyFavoriteQual = getQualificationData();

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

                dbobj.sp_userReg(regid, clsobj.uname, clsobj.uage, clsobj.uaddress, clsobj.uemail, clsobj.uphone,clsobj.uphoto,clsobj.uqual,clsobj.uexp,clsobj.uskill,clsobj.uresume);
                dbobj.sp_loginsert(regid, clsobj.Username, clsobj.Password, "user");
                clsobj.umsg = "successfuly inserted";
                Session["userid"] = regid;
                return View("Insert_Pageload", clsobj);
            }
            else
            {
                clsobj.MyFavoriteQual = getQualificationData();
            }
            return View("Insert_Pageload", clsobj);
            
           
        }
    }
}