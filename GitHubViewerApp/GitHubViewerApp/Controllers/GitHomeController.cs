using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using GitHubViewerApp.Models;

namespace GitHubViewerApp.Controllers
{
    public class GitHomeController : Controller
    {
        //
        // GET: /GitHome/
        RestConsumer consumer = new RestConsumer();
        public ActionResult Index()
        {
            ViewModelSearch Model = new ViewModelSearch();
            return View(Model);
        }

      



        [HttpPost]
        public ActionResult Index(ViewModelSearch Model)
        {
            if (Model.search != "")
            {
                @ViewBag.PageCount = 10;
                GitUser myUser = new GitUser();
                if (consumer.CheckUserExists(Model.search))
                {                   
                    List<GitRepos> listGitRepos = consumer.GetRepos(Model.search);
                    @ViewBag.User = Model.search;
                    @ViewBag.PageCount = listGitRepos.Count;
                    return PartialView("_PartialGridRepos", listGitRepos);
                }
            }
            return PartialView("_PartialGridRepos", null);
        }

        [HttpPost]
        public ActionResult collaborators(string reponame, string username, string authoName, string authoPassword)
        {
            List<GitUser> listusers = new List<GitUser>();
            string reqStauts = "";
            ViewBag.Status = "";
            listusers = consumer.GetCollabrator(reponame, username, authoName, authoPassword,out reqStauts);
            
            if (reqStauts != "")
            {
                ViewBag.Status = reqStauts;
            }
            return View(listusers);
        }
    }
}
