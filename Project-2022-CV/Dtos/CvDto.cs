using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Project_2022_CV.Models;

namespace Project_2022_CV.Dtos
{
    [DataContract]  
    public class CvDto
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public List<Skill> SkillList { get; set; }
    }
}