using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Project_2022_CV.Models;
using Project_2022_CV.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Project_2022_CV.Controllers
{

    public class MessageController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Message

        public MessageController()
        {
            db = new ApplicationDbContext();
        }


        [Authorize]
        public ActionResult MessagesIndexPage()
        {
            List<MessageModel> messages = db.Messages.ToList();
            return View(messages);
        }

        [Authorize]
        public ActionResult ReadMessages()
        {
            List<MessageModel> messages = db.Messages.ToList();
            return View(messages);
        }

        [Authorize]
        public ActionResult UnreadMessages()
        {
            List<MessageModel> messages = db.Messages.ToList();
            return View(messages);
        }

        [Authorize]
        public ActionResult SentMessages()
        {
            List<MessageModel> messages = db.Messages.ToList();
            return View(messages);
        }


        //[HttpPost]
        [AllowAnonymous]
        public ActionResult WriteMessageUser(int id)
        {
            MessageModel model = new MessageModel();
            var message = db.Users.Where(x => x.Cv.id == id).FirstOrDefault();
            var viewmodel = new MessageViewModel() { applicationUser = message, messageModel = model };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult WriteMessageUser()
        {
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public ActionResult WriteMessage()
        {
            MessageModel model = new MessageModel();
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult WriteMessage(MessageModel model)
        {
            ModelState.Remove("Author");
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            MessageModel message = new MessageModel();

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
                ModelState.AddModelError("email", "No user found with the corresponding email");
                return View();
            }


            if (model.Email == User.Identity.GetUserName())
            {
                ModelState.AddModelError("email", "You can't send email to yourself");
                return View();
            }

            return RedirectToAction("MessagesIndexPage");
        }

        public ActionResult ReadMessage(int id)
        {

            List<MessageModel> messages = db.Messages.ToList();

            var item = messages.Where(x => x.Id == id).FirstOrDefault();

            if (item.ReadMessage == false)
            {
                item.ReadMessage = true;

                UpdateModel(item);
                db.SaveChanges();

            }
            return View(item);
        }

        public ActionResult create()
        {
            return View();
        }

        [Authorize]
        public ActionResult GetMessages()
        {
            var wow = User.Identity.GetUserId();
            var count = db.Messages.Count(p => p.ReceiverId == wow && p.ReadMessage == false);

            return PartialView(count);

        }
    }

}


