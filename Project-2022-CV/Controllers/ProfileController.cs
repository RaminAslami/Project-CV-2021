using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project_2022_CV.Models;
using Project_2022_CV.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace Project_2022_CV.Controllers

{
    [Authorize]
    public class ProfileController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ProfileController()
        {
        }

        public ProfileController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }
        public ActionResult ProfileSettings()
        {
            var CurrentUserId = User.Identity.GetUserId();
            var currentUser = db.Users.SingleOrDefault(x => x.Id == CurrentUserId);
            return View(currentUser);


        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ProfileSettings(ApplicationUser model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

                user.UserName = model.Email;
                user.Name = model.Name;
                user.PhoneNumber = model.PhoneNumber;
                user.Email = model.Email;
                user.Adress = model.Adress;

                if (string.IsNullOrEmpty(model.GitUserName))
                {
                    user.GitUserName = null;
                }

                else
                {
                    user.GitUserName = model.GitUserName;
                }


                var result = await UserManager.UpdateAsync(user);

                if (result.Succeeded && user.UserName == model.UserName)
                {
                    await UserManager.UpdateAsync(user);

                    return Content("<script language='javascript' type='text/javascript'>alert('Thanks for Feedback!');</script>");

                }

                AddErrors(result);

            }
            return View(model);
        }



        public ActionResult AccountSettings()
        {
            var CurrentUserId = User.Identity.GetUserId();
            var currentUser = db.Users.SingleOrDefault(x => x.Id == CurrentUserId);
            return View(currentUser);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AccountSettings(ApplicationUser model, string settings)
        {
            if (ModelState.IsValid)
            {
                if (settings == "Update")
                {
                    var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

                    user.Private = model.Private;
                    user.Active = model.Active;
                    if (model.Active)
                    {
                        user.Cv.Deactivated = false;
                    }
                    else
                    {

                        user.Cv.Deactivated = true;
                    }

                    var result = await UserManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        await UserManager.UpdateAsync(user);


                    }


                    AddErrors(result);
                }
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult AccountSettingsActive(string active)
        {
            if (active == "Deactivate")
            {
                var user = UserManager.FindById(User.Identity.GetUserId());

                user.Active = false;
                user.Cv.Deactivated = true;
                db.SaveChanges();

                //UserManager.Update(user);


                return RedirectToAction("AccountSettings");
            }
            return RedirectToAction("AccountSettings");
        }

        [HttpPost]
        public ActionResult AccountSettingsDeactivate(string deactive)
        {

            if (deactive == "Activate")
            {
                var user = UserManager.FindById(User.Identity.GetUserId());

                user.Active = true;
                var result = UserManager.Update(user);

                UserManager.Update(user);



            }
            return RedirectToAction("AccountSettings");
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Active(ApplicationUser model)
        {

            var user = UserManager.FindById(User.Identity.GetUserId());

            user.Active = true;
            var result = UserManager.Update(user);


            UserManager.Update(user);


            return View(model);
        }


        public ActionResult Active()
        {
            var CurrentUserId = User.Identity.GetUserId();
            var currentUser = db.Users.SingleOrDefault(x => x.Id == CurrentUserId);
            return View(currentUser);
        }






        public ActionResult Security()
        {
            return View();
        }




        private void AddErrors(Microsoft.AspNet.Identity.IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }















    }










}
