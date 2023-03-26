using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_2022_CV.Models
{
    public class User_WorkExperience
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string WorkPlace { get; set; }
        public DateTime StartYear { get; set; }
        public DateTime? EndYear { get; set; }
        public string WorkDescription { get; set; }

    }
}