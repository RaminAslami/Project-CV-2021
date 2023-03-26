using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Project_2022_CV.Dtos;
namespace Project_2022_CV.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string webPage { get; set; }
        public virtual Cv Cv { get; set; }
        public bool Private { get; set; }
        public string Adress { get; set; }
        public bool Active { get; set; }
        public byte[] ProfileImage { get; set; }
        public string GitUserName { get; set; }

        public virtual ICollection<Project> CreatedProjects { get; set; }
        public ApplicationUser()
        {
            CreatedProjects = new List<Project>();
        }

        public string GetProfileImage()
        {
            try
            {

                var base64 = Convert.ToBase64String(ProfileImage);
                var imgsrc = string.Format("data:image/;base64,{0}", base64);
                return imgsrc;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "Finns ingen profilbild";
            }

        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Cv> cv { get; set; }
        public DbSet<MessageModel> Messages { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<User_WorkExperience> User_WorkExperience { get; set; }
        public DbSet<User_Education> UserEducations { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}