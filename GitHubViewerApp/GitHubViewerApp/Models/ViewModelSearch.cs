using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GitHubViewerApp.Models
{
    public class ViewModelSearch
    {   
        [Required]
        public string search { get; set; }
    }
}