using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project_2022_CV.Models;

namespace Project_2022_CV.ViewModel
{
    public class CvUserViewModel
    {
        public Cv Cv { get; set; }
        public ApplicationUser User { get; set; }
        public List<Project> UserProjects { get; set; }
        public bool showClicks { get; set; }

    }
}