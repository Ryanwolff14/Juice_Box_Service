using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BoxService.Models;
using Microsoft.AspNet.Identity;

namespace BoxService.Controllers
{
    public class SurveysController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Surveys
        public ActionResult Index()
        {
            return View(db.Surveys.ToList());
        }

        // GET: Surveys/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey survey = db.Surveys.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
            return View(survey);
        }

        // GET: Surveys/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Surveys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SurveyID,Question1,Question2")] Survey survey)
        {
            if (ModelState.IsValid)
            {
                db.Surveys.Add(survey);
                db.SaveChanges();

                if((int)survey.Question1 == 0 && (int)survey.Question2 == 0)
                {
                    Box box1 = new Box();
                    box1.Name = "Max VG Fruity";
                    box1.Description = "Box filled with fruity max VG juices";
                    box1.Price = 20.00;
                    db.Boxes.Add(box1);
                    db.SaveChanges();
                    var ID = User.Identity.GetUserId();
                    var user = db.Users.Find(ID);
                    user.BoxId = box1.BoxID;
                    user.BoxName = box1.Name;
                    user.BoxPrice = box1.Price;
                    db.SaveChanges();
                    return RedirectToAction("Details", "Boxes", new { id = box1.BoxID });
                }
                else if((int)survey.Question1 == 1 && (int)survey.Question2 == 0)
                {
                    Box box2 = new Box();
                    box2.Name = "Max PG Fruity";
                    box2.Description = "Box filled with fruity Max PG juices";
                    box2.Price = 20.00;
                    db.Boxes.Add(box2);
                    db.SaveChanges();
                    var ID = User.Identity.GetUserId();
                    var user = db.Users.Find(ID);
                    user.BoxId = box2.BoxID;
                    user.BoxName = box2.Name;
                    user.BoxPrice = box2.Price;
                    return RedirectToAction("Details(box2.BoxID)", "Boxes");
                }
                else if((int)survey.Question1 == 0 && (int)survey.Question2 == 1)
                {
                    Box box3 = new Box();
                    box3.Name = "Max VG Dessert";
                    box3.Description = "Box filled with desserts using Max VG juices";
                    box3.Price = 20.00;
                    db.Boxes.Add(box3);
                    db.SaveChanges();
                    var ID = User.Identity.GetUserId();
                    var user = db.Users.Find(ID);
                    user.BoxId = box3.BoxID;
                    user.BoxName = box3.Name;
                    user.BoxPrice = box3.Price;
                    return RedirectToAction("Details(box3.BoxID)", "Boxes");
                }
                else
                {
                    Box box4 = new Box();
                    box4.Name = "Max PG Dessert";
                    box4.Description = "Box filled with desserts using Max PG juices";
                    box4.Price = 20.00;
                    db.Boxes.Add(box4);
                    db.SaveChanges();
                    var ID = User.Identity.GetUserId();
                    var user = db.Users.Find(ID);
                    user.BoxId = box4.BoxID;
                    user.BoxName = box4.Name;
                    user.BoxPrice = box4.Price;
                    return RedirectToAction("Details(box4.BoxID)", "Boxes");
                }
               
            }

            return View(survey);
        }

        // GET: Surveys/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey survey = db.Surveys.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
            return View(survey);
        }

        // POST: Surveys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SurveyID,Question1,Question2")] Survey survey)
        {
            if (ModelState.IsValid)
            {
                db.Entry(survey).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(survey);
        }

        // GET: Surveys/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survey survey = db.Surveys.Find(id);
            if (survey == null)
            {
                return HttpNotFound();
            }
            return View(survey);
        }

        // POST: Surveys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Survey survey = db.Surveys.Find(id);
            db.Surveys.Remove(survey);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
