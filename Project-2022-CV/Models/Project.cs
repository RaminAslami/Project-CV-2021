    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace Project_2022_CV.Models
{
    public class Project
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
        public DateTime Created { get; set; }
        public string UserCreatorId { get; set; }

        public byte[] ProjectImage { get; set; }
        public virtual ICollection<ApplicationUser> InvolvedUsers { get; set; }


        public Project()
        {
            InvolvedUsers = new List<ApplicationUser>();
        }
        public string GetProjectImage()
        {
            try
            {

                var base64 = Convert.ToBase64String(ProjectImage);
                var imgsrc = string.Format("data:image/;base64,{0}", base64);
                return imgsrc;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "Finns ingen profilbild";
            }

        }




    }
}