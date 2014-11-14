using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace GitHubViewerApp.Models
{
    public class GitRepos
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int watchers { get; set; }
    }
}