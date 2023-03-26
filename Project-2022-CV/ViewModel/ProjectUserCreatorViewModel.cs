using Project_2022_CV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_2022_CV.ViewModel
{
    public class ProjectUserCreatorViewModel
    {
        public  Project project { get; set; }
        public ApplicationUser creator { get; set; }
        public ApplicationUser Currentuser { get; set; }

    }
}