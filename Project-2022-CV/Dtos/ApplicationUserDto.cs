using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Project_2022_CV.Models;

namespace Project_2022_CV.Dtos
{

    [KnownType(typeof(Skill))]
    [KnownType(typeof(CvDto))]

    [KnownType(typeof(DateTime))]
    [KnownType(typeof(List<Skill>))]
    [KnownType(typeof(List<User_Education>))]
    [KnownType(typeof(List<User_WorkExperience>))]


    [KnownType(typeof(User_WorkExperience))]
    [KnownType(typeof(User_Education))]
    [KnownType(typeof(ApplicationUser))]
    [DataContract]
    public class ApplicationUserDto
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]

        public string webPage { get; set; }
        [DataMember]

        public CvDto Cv { get; set; }
        [DataMember]

        public bool Private { get; set; }
        [DataMember]

        public string Adress { get; set; }
        [DataMember]

        public bool Active { get; set; }
        [DataMember]
        public string GitUserName { get; set; }
        [DataMember]

        public List<ProjectDto> CreatedProjects;
        public ApplicationUserDto()
        {
            Cv = new CvDto();
        }
    }

}