using GitHubViewerApp.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace GitHubViewerApp
{
    public class RestConsumer
    {
      
        // RestConsumer/

    

        public List<GitRepos> GetRepos(string Name)
        {
            RestClient restClient = new RestClient("https://api.github.com/users/" + Name + "/repos");
            List<GitRepos> Repo = new List<GitRepos>();
            var request = new RestRequest("", Method.GET) { RequestFormat = DataFormat.Json };
            var response = restClient.Execute(request);
            //var newResponse = restClient.Get(request);           
            Repo = (List<GitRepos>)Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content, typeof(List<GitRepos>));
            return Repo;

        }
        public List<GitUser> GetCollabrator(string reponame,string username,string authoName,string authoPassword,out string status)
        {

            List<GitUser> listusers = new List<GitUser>();
            try
            {
                string url = "https://api.github.com/repos/" + username + "/" + reponame + "/collaborators";
                RestClient restClient = new RestClient(url);
                string key = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(authoName + ":" + authoPassword));
                restClient.AddDefaultHeader("Authorization", key);

                status = "";
                var request = new RestRequest("", Method.GET) { RequestFormat = DataFormat.Json };
                var response = restClient.Execute(request);
                //var newResponse = restClient.Get(request);  
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                listusers = (List<GitUser>)Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content, typeof(List<GitUser>));
                  status = "";
                }
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    status = "Unauthorized";
                }
                
              return listusers;
               
            }
            catch (Exception e)
            {
                status = "";
                return listusers;
            }

        }

        public bool CheckUserExists(string search)
        {
            try
            {
                RestClient restClient = new RestClient("https://api.github.com/users/" + search);
                var request = new RestRequest("", Method.GET) { RequestFormat = DataFormat.Json };
                var response = restClient.Execute(request);
                //var newResponse = restClient.Get(request);           
                GitUser myDeserializedObjList = (GitUser)Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content, typeof(GitUser));
                if (response.StatusCode == System.Net.HttpStatusCode.OK )
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception e)
            {
                return false;
            }
        }

    }
}
