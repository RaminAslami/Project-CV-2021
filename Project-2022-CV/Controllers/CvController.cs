using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Project_2022_CV.Dtos;
using Project_2022_CV.Models;
using Project_2022_CV.ViewModel;

namespace Project_2022_CV.Controllers
{
    public class CvController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cvs


        public ActionResult CV_Matching(int id)

        {


            var cv = db.cv.FirstOrDefault(x => x.id == id);



            var matchingCv = new Cv();
            foreach (var x in db.cv.ToList())
            {
                if (x.Deactivated == false && x.id != cv.id)
                {


                    int i = 0;

                    i += matchSkill(x, cv);
                    i += matchEducation(x, cv);
                    i += matchWorkExperience(x, cv);
                    i += matchClicks(x, cv);


                    if (i >= 4)
                    {
                        matchingCv = x;
                        break;
                    }

                }

            }

            if (matchingCv.id == 0)
            {
                matchingCv = db.cv.OrderByDescending(x => x.Clicks).Take(1).Single();
            }


            var showCv = false;
            var LoggedIn = User.Identity.GetUserId();
            matchingCv.Clicks += 1;
            db.SaveChanges();
            var user = db.Users.FirstOrDefault(x => x.Cv.id == matchingCv.id);
            var projects = db.Projects.Where(x => x.InvolvedUsers.Any(y => y.Id == user.Id)).ToList();
            if (LoggedIn == user.Id)
            {
                showCv = true;
            }

            if (user.Active && user.Private == false)
            {




                var ViewModel = new CvUserViewModel()
                {
                    Cv = matchingCv,
                    User = user,
                    UserProjects = projects,
                    showClicks = showCv


                };
                return View(ViewModel);

            }



            else if (LoggedIn != null && user.Active)
            {

                var ViewModel = new CvUserViewModel()
                {
                    Cv = matchingCv,
                    User = user,
                    UserProjects = projects,
                    showClicks = showCv

                };
                return View(ViewModel);



            }





            return Content("Du har ej behörighet att se detta CV");
        }

        public ActionResult CV_Single(int id)

        {
            //fixa detta
            var showCv = false;
            var LoggedIn = User.Identity.GetUserId();
            var Cv = db.cv.Include(x => x.WorkExperiences).Include(z => z.Educations).FirstOrDefault(x => x.id == id);
            Cv.Clicks += 1;
            db.SaveChanges();
            var user = db.Users.FirstOrDefault(x => x.Cv.id == Cv.id);
            var projects = db.Projects.Where(x => x.InvolvedUsers.Any(y => y.Id == user.Id)).ToList();
            if (LoggedIn == user.Id)
            {
                showCv = true;
            }

            if (user.Active && user.Private == false)
            {

                var ViewModel = new CvUserViewModel()
                {
                    Cv = Cv,
                    User = user,
                    UserProjects = projects,
                    showClicks = showCv


                };
                return View(ViewModel);

            }



            else if (LoggedIn != null && user.Active)
            {

                var ViewModel = new CvUserViewModel()
                {
                    Cv = Cv,
                    User = user,
                    UserProjects = projects,
                    showClicks = showCv

                };
                return View(ViewModel);



            }
            else




                return Content("Du har ej behörighet att se detta CV");
        }


        [Authorize]
        public ActionResult EditCv()
        {


            var userID = User.Identity.GetUserId();
            var user = db.Users.SingleOrDefault(x => x.Id == userID);
            if (user.Cv == null)
            {
                var cv = new Cv()
                {
                    Title = "",
                    Description = "",
                    Deactivated = false,
                    Date = DateTime.UtcNow,
                    Clicks = 0


                };
                user.Cv = cv;
                db.SaveChanges();
            }


            var viewModel = new UserIDViewModel()
            {
                id = user.Id,
                CvId = user.Cv.id
            };
            return View(viewModel);
        }

        public int matchClicks(Cv matchingCv, Cv originalCv)
        {
            var Clickedifference = matchingCv.Clicks - originalCv.Clicks;
            var ClickedDiff = originalCv.Clicks - matchingCv.Clicks;
            int i = 0;
            if (ClickedDiff > 1 && ClickedDiff < 50)
            {
                i++;
            }

            if (Clickedifference > 1 && Clickedifference < 50)
            {
                i++;
            }

            return i;
        }

        public int matchSkill(Cv matchingCv, Cv originalCv)
        {
            int i = 0;
            if (matchingCv.SkillList.Count == originalCv.SkillList.Count)
            {
                i++;
            }

            foreach (var cvSkill in originalCv.SkillList.ToList())
            {
                foreach (var skill in matchingCv.SkillList.ToList())
                {
                    if (skill.SkillName.Contains(cvSkill.SkillName))
                    {
                        i++;

                    }

                }

            }
            return i;
        }
        public int matchEducation(Cv matchingCv, Cv originalCv)
        {
            int i = 0;
            if (matchingCv.Educations.Count == originalCv.Educations.Count)
            {
                i++;
            }

            foreach (var eduCv in originalCv.Educations)
            {
                foreach (var edu in matchingCv.Educations)
                {
                    if (edu.WorkPlace.Contains(eduCv.WorkPlace))
                    {
                        i++;

                    }

                }

            }

            foreach (var originalCvEducation in originalCv.Educations)
            {
                foreach (var matchingCvEducation in matchingCv.Educations)
                {

                    if (originalCvEducation.StartYear.Year == matchingCvEducation.StartYear.Year)
                    {
                        i++;
                    }

                    if (originalCvEducation.EndYear.Value.Year == matchingCvEducation.EndYear.Value.Year)
                    {
                        i++;
                    }
                }
            }
            return i;
        }
        public int matchWorkExperience(Cv matchingCv, Cv originalCv)
        {
            int i = 0;
            if (matchingCv.WorkExperiences.Count == originalCv.WorkExperiences.Count)
            {
                i++;
            }

            foreach (var workExCv in originalCv.WorkExperiences)
            {
                foreach (var workex in matchingCv.WorkExperiences)
                {
                    if (workex.WorkPlace.Contains(workExCv.WorkPlace))
                    {
                        i++;


                    }

                }

            }
            return i;
        }

        public ActionResult SaveUser(int id)
        {
            var user = db.Users.Include(x => x.CreatedProjects).Include(x => x.Cv).FirstOrDefault(x => x.Cv.id == id);
            var dto = new ApplicationUserDto();

            dto.Name = user.Name;
            dto.GitUserName = user.GitUserName;
            dto.webPage = user.webPage;
            dto.Private = user.Private;
            dto.Adress = user.Adress;

            dto.Cv.id = user.Cv.id;
            dto.Cv.SkillList = user.Cv.SkillList;
            dto.Cv.Title = user.Cv.Title;
            dto.Cv.Description = user.Cv.Description;
            dto.Cv.Date = user.Cv.Date;
            dto.CreatedProjects = new List<ProjectDto>();


            if (user.CreatedProjects.ToList() is null)
            {

            }
            else
            {

                foreach (var project in user.CreatedProjects.ToList())
                {
                    var projectDto = new ProjectDto();
                    projectDto.Created = project.Created;
                    projectDto.Description = project.Description;
                    projectDto.Id = project.Id;
                    projectDto.Title = project.Title;
                    dto.CreatedProjects.Add(projectDto);
                }
            }

            var homepath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            using (var stream = new FileStream((homepath + "\\Downloads\\" + user.Name + ".xml"), FileMode.Create))

            {
                var XML = new DataContractSerializer(typeof(ApplicationUserDto));
                XML.WriteObject(stream, dto);
            }

            return RedirectToAction("DownloadUser", "Success");
        }
    }
}
