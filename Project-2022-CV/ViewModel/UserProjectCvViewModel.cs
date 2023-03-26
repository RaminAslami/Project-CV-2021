using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project_2022_CV.Models;

namespace Project_2022_CV.ViewModel
{
    public class UserProjectCvViewModel
    {
        public List<Project> projects { get; set; }
        public List<ApplicationUser> Users { get; set; }
        public Project latestProject { get; set; }

    }
}