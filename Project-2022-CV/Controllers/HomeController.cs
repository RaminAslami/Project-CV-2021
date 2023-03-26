using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualBasic.ApplicationServices;
using Project_2022_CV.Models;
using Project_2022_CV.ViewModel;

namespace Project_2022_CV.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Users
        public ActionResult Index()
        {
            var Projects = db.Projects.ToList();
            var latestProject = db.Projects.OrderByDescending(x => x.Created).FirstOrDefault();
            //var Cvs = db.cv.Where(x => x.Deactivated == false).OrderByDescending(x => x.Clicks).Take(3).ToList();
            var Users = db.Users.Include(x => x.Cv).Where(x => x.Cv.Deactivated == false).Where(z => z.Private == false).OrderByDescending(x => x.Cv.Clicks).Take(3).Distinct()
                .ToList();

            var ViewModel = new UserProjectCvViewModel
            {
                latestProject = latestProject,
                Users = Users,
                //Cvs = Cvs,
                projects = Projects,
            };
            return View(ViewModel);
        }


        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //    // POST: Users/Edit/5
        //    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Password,adress,Name,email,webPage,phonenumber,Private,Active")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }


    }
}