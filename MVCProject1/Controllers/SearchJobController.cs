using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProject1.Models;
using System.Data.SqlClient;
using System.Data;



namespace MVCProject1.Controllers
{
    public class SearchJobController : Controller
    {
        // GET: SearchJob
        MVCProjectEntities dbobj = new MVCProjectEntities();
        
       
        public ActionResult searchjob_Pageload()
        {
            return View(GetData());
        }
        private JobSearch GetData()
        {
            var joblist = new JobSearch();
            List<string> lst = new List<string>();
            var job = dbobj.Job_Table.ToList();
            foreach (var e in job)
            {
                var jobcls = new jsearch();
                jobcls.job_id = e.Job_Id;
                jobcls.company_Id = e.Comp_Id;
                jobcls.job_title = e.Job_Tittle;
                jobcls.skills = e.job_Skills;
                jobcls.experience = e.Job_Experi;
                jobcls.job_Status = e.Status;
                jobcls.last_Date = e.Last_Date;

                joblist.selectjob.Add(jobcls);
                //Session["job_id"] = e.Job_Id;

                var s = jobcls.skills;
                lst.Add(s);
                TempData["ski"] = string.Join(" ", lst);
            }
            return joblist;
        }
        public ActionResult searchjob_click(JobSearch clsobj)
        {
            string qry = "";
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.experience))
            {
                qry += " and Job_Experi like '%" + clsobj.insertse.experience + "%'";
            }



            if (!string.IsNullOrWhiteSpace(clsobj.insertse.job_title))
            {
                qry += " and Job_Tittle like '%" + clsobj.insertse.job_title + "%'";

            }



            if (!string.IsNullOrWhiteSpace(clsobj.insertse.skills))
            {
                qry += " and job_Skills like '%" + clsobj.insertse.skills + "%'";
            }
            return View("searchjob_Pageload", getdata1(clsobj, qry));
        }

        private JobSearch getdata1(JobSearch clsobj, string qry)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["test"].ConnectionString))
            
            {
                SqlCommand cmd = new SqlCommand("sp_jobsearches", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@qry", qry);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                var joblist = new JobSearch();
                while (dr.Read())
                {
                    var jobcls = new jsearch();
                    jobcls.company_Id = Convert.ToInt32(dr["Comp_Id"].ToString());
                    jobcls.job_title= dr["Job_Tittle"].ToString();
                    jobcls.skills = dr["job_Skills"].ToString();
                    jobcls.experience = dr["Job_Experi"].ToString();
                    jobcls.job_Status = dr["Status"].ToString();
                    jobcls.last_Date = dr["Last_Date"].ToString();

                    joblist.selectjob.Add(jobcls);
                }
                con.Close();
                return joblist;


            }
        }
    }
}



    