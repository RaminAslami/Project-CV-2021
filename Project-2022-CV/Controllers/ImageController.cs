using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using Project_2022_CV.Models;

namespace Project_2022_CV.Controllers
{
    public class ImageController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public ImageController()
        {


        }
        // GET: Image
        [HttpGet]
        public ActionResult _ProfileAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult _ProfileAdd(HttpPostedFileBase ImageFile)
        {
            var id = User.Identity.GetUserId();
            var applicationuser = _context.Users.SingleOrDefault(x => x.Id == id);
            if (ImageFile != null)
            {
                applicationuser.ProfileImage = new byte[ImageFile.ContentLength];
                ImageFile.InputStream.Read(applicationuser.ProfileImage, 0, ImageFile.ContentLength);
            }
            //Måste få id från användare.

            _context.Users.AddOrUpdate(applicationuser);

            _context.SaveChanges();
            return RedirectToAction("ProfileSettings", "Profile");


        }
        [HttpPost]
        public ActionResult _ProjectAdd(HttpPostedFileBase ImageFile, int id)
        {
            var project = _context.Projects.FirstOrDefault(x => x.Id == id);
            if (ImageFile != null)
            {
                project.ProjectImage = new byte[ImageFile.ContentLength];
                ImageFile.InputStream.Read(project.ProjectImage, 0, ImageFile.ContentLength);
            }
            //Måste få id från användare.

            _context.Projects.AddOrUpdate(project);

            _context.SaveChanges();
            return RedirectToAction("EditProject", "Project", new { Id = id });


        }



    }
}