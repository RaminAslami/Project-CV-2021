using System;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using System.Data.Entity;
using Project_2022_CV.ViewModel;
using Project_2022_CV.Models;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System.Security.Policy;

namespace Project_2022_CV.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project

        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Project()
        {
            var Projects = db.Projects.ToList();

            var viewModel = new ListOfProjectsViewModel()
            {
                projects = Projects
            };

            return View(viewModel);
        }



        public ActionResult ProjectPage(int id)
        {
            if (User.Identity.IsAuthenticated)
            {


                var currentUserId = User.Identity.GetUserId();
                var currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);
                var project = db.Projects.Include(x => x.InvolvedUsers).FirstOrDefault(x => x.Id == id);
                var creator = db.Users.Include(x => x.Cv).Single(x => x.Id == project.UserCreatorId);





                var viewModel = new ProjectUserCreatorViewModel()
                {
                    project = project,
                    creator = creator,
                    Currentuser = currentUser
                };

                return View(viewModel);
            }
            else
            {
                var project = db.Projects.Include(x => x.InvolvedUsers).FirstOrDefault(x => x.Id == id);
                var creator = db.Users.Include(x => x.Cv).Single(x => x.Id == project.UserCreatorId);
                var currentUser = new ApplicationUser()
                {
                    Id = "0",
                    Name = ""
                };
              
                var viewModel = new ProjectUserCreatorViewModel()
                {
                    project = project,
                    creator = creator,
                    Currentuser = currentUser
                };

                return View(viewModel);
            }
        }









        [Authorize]
        public ActionResult CreateProject()
        {
            return View();
        }




        [HttpPost]

        public ActionResult Create(Project project, HttpPostedFileBase ImageFile)
        {

            var LoggedIn = User.Identity.GetUserId();
            project.UserCreatorId = LoggedIn;

            if (!ModelState.IsValid)
            {
                var viewModel = new ProjectUserCreatorViewModel
                {
                    project = project
                };
                return View("CreateProject", viewModel);
            }
            if (ImageFile != null)
            {
                project.ProjectImage = new byte[ImageFile.ContentLength];
                ImageFile.InputStream.Read(project.ProjectImage, 0, ImageFile.ContentLength);
            }

            project.Created = DateTime.Now;


            db.Projects.Add(project);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }





        public ActionResult EditProject(int Id)
        {

            var Project = db.Projects.FirstOrDefault(x => x.Id == Id);

            var viewModel = new ProjectViewModel()
            {
                Project = Project
            };

            return View(viewModel);
        }





        public ActionResult Save(Project project)
        {

            var projectInDb = db.Projects.Single(p => p.Id == project.Id);

            projectInDb.Title = project.Title;
            projectInDb.Description = project.Description;

            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}























