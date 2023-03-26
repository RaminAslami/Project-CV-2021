using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Project_2022_CV.Models;

namespace Project_2022_CV.Controllers.Api
{
    public class ProjectController : ApiController
    {
        public ApplicationDbContext db = new ApplicationDbContext();
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut]
        [Authorize]
        public IHttpActionResult Put(int id,  string UserID)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var project = db.Projects.FirstOrDefault(x => x.Id == id);
            var user = db.Users.FirstOrDefault(x => x.Id == UserID);
            foreach (var projectInvolvedUser in project.InvolvedUsers)
            {
                if (projectInvolvedUser == user)
                {
                    return BadRequest("User already in project");
                }
            }
            project.InvolvedUsers.Add(user);
            db.SaveChanges();

            return Ok("Succesfull");
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}