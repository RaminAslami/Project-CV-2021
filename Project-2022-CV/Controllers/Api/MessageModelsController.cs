using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.AspNet.Identity;
using Project_2022_CV.Models;

namespace Project_2022_CV.Controllers.Api
{
    [RoutePrefix("api/MessageModels")]
    public class MessageModelsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public static List<int> lista = new List<int>();

        // GET: api/MessageModels
        public IQueryable<MessageModel> GetMessages()
        {
            return db.Messages;
        }

        // GET: api/MessageModels/5
        [ResponseType(typeof(MessageModel))]

        public IHttpActionResult GetMessageModel(int id)
        {
            MessageModel messageModel = db.Messages.FirstOrDefault(x => x.Id == id);

            if (messageModel == null)
            {
                return NotFound();
            }

            return Ok(messageModel);
        }

        // PUT: api/MessageModels/5
        //[ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult PutMessageModel(/*MessageModel messageModel,*/ int id)
        {

            Debug.WriteLine("dawgshit!");

            MessageModel messageModel = db.Messages.FirstOrDefault(x => x.Id == id);

            //return BadRequest(ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != messageModel.Id)
            {
                return BadRequest();
            }
            if (messageModel.ReadMessage != true)
            {

                messageModel.ReadMessage = true;

            }
            else
            {
                messageModel.ReadMessage = false;
            }


            db.Entry(messageModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!MessageModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/MessageModels
        [HttpPost]
        public IHttpActionResult PostMessageModel(MessageModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string idet = db.Users
           .Where(m => m.Email == model.Email)
           .Select(m => m.Id)
           .FirstOrDefault();


            string username = User.Identity.GetUserName();

            string author = db.Users
                .Where(m => m.Email == username)
                .Select(m => m.Name)
                .FirstOrDefault();


            if (idet == null)
            {
                return BadRequest(ModelState);
            }


            if (model.Email == User.Identity.GetUserName())
            {
                return BadRequest(ModelState);
            }

            model.ReceiverId = idet;
            if (User.Identity.IsAuthenticated)
            {
                model.Author = author;
            }

            model.SenderId = User.Identity.GetUserId();

            model.AuthorEmail = User.Identity.GetUserName();

            db.Messages.Add(model);
            db.SaveChanges();


            return Ok(model);
        }




        // DELETE: api/MessageModels/5
        [ResponseType(typeof(MessageModel))]
        public IHttpActionResult DeleteMessageModel(int id)
        {
            MessageModel messageModel = db.Messages.Find(id);
            if (messageModel == null)
            {
                return NotFound();
            }

            db.Messages.Remove(messageModel);
            db.SaveChanges();

            return Ok(messageModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MessageModelExists(int id)
        {
            return db.Messages.Count(e => e.Id == id) > 0;
        }
    }
}