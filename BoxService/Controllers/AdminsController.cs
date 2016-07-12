using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BoxService.Models;

namespace BoxService.Controllers
{
    public class AdminsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult ViewStats()
        {
            Admin admin = new Admin();
            admin.MonthlyTotal = (from User in db.Users select User.BoxPrice).Sum();
            admin.NumberOfAccounts = db.Users.Count();
            admin.PercentFruityVG = ((from user in db.Users where user.BoxName.Equals("Max VG Fruity") select user).Count() / admin.NumberOfAccounts)*10;
            admin.PercentFruityPG = ((from user in db.Users where user.BoxName.Equals("Max PG Fruity") select user).Count() / admin.NumberOfAccounts) * 10;
            admin.PercentDessertVG = ((from user in db.Users where user.BoxName.Equals("Max VG Dessert") select user).Count() / admin.NumberOfAccounts) * 10;
            admin.PercentDessertPG = ((from user in db.Users where user.BoxName.Equals("Max PG Dessert") select user).Count() / admin.NumberOfAccounts) * 10;
            //admin.PercentMentholPG = ((from user in db.Users where user.BoxName.Equals("Max VG Menthol") select user).Count() / admin.NumberOfAccounts) * 10;
            //admin.PercentMentholVG = ((from user in db.Users where user.BoxName.Equals("Max PG Menthol") select user).Count() / admin.NumberOfAccounts) * 10;
            //admin.PercentTabbacoPG = ((from user in db.Users where user.BoxName.Equals("Max VG Tabbaco") select user).Count() / admin.NumberOfAccounts) * 10;
            //admin.PercentTabbacoVG = ((from user in db.Users where user.BoxName.Equals("Max PG Tabbaco") select user).Count() / admin.NumberOfAccounts) * 10;
            return View(admin);
        }

        // GET: Admins
        public ActionResult Index()
        {
            return View(db.Admins.ToList());
        }

        // GET: Admins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // GET: Admins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,#OfAccounts,MonthlyTotal,MaxVGFruity,MaxPGFruity,MaxVGDessert,MaxPGDessert")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Admins.Add(admin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(admin);
        }

        // GET: Admins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // POST: Admins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,#OfAccounts,MonthlyTotal,MaxVGFruity,MaxPGFruity,MaxVGDessert,MaxPGDessert")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(admin);
        }

        // GET: Admins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // POST: Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Admin admin = db.Admins.Find(id);
            db.Admins.Remove(admin);
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
