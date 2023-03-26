using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Project_2022_CV.Models
{
    public class Cv
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public int Clicks { get; set; }
        public bool Deactivated { get; set; }
        public virtual List<Skill> SkillList { get; set; }
        public virtual List<User_Education> Educations { get; set; }
        public virtual List<User_WorkExperience> WorkExperiences { get; set; }


        public Cv()
        {
        WorkExperiences = new List<User_WorkExperience>();
        Educations = new List<User_Education>();
        SkillList = new List<Skill>();
        }


    }
}