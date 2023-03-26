using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Project_2022_CV.Models;

namespace Project_2022_CV.Controllers.Api
{
    public class CvController : ApiController
    {
        private ApplicationDbContext _context;

        public CvController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpGet]
        [Authorize]
        public Cv GetCV(int id)
        {


            return _context.cv.FirstOrDefault(x => x.id == id);

        }
        [HttpPost]
        public Cv ModifyCv(Cv cvUser, string userId)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var user = _context.Users.SingleOrDefault(x => x.Id == userId);
            var modifycv = _context.cv.Include(x => x.Educations).Include(z => z.WorkExperiences).Include(y => y.SkillList)
                .FirstOrDefault(x => x.id == cvUser.id);
            modifycv.Description = cvUser.Description;
            modifycv.Title = cvUser.Title;
            modifycv.Educations = cvUser.Educations;
            modifycv.SkillList = cvUser.SkillList;
            modifycv.WorkExperiences = cvUser.WorkExperiences;

            

            _context.SaveChanges();

            return cvUser;
        }

      
    }
}
