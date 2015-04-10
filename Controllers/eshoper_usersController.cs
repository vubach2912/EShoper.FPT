using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EShoper.FPT.Models;

namespace EShoper.FPT.Controllers
{
    public class eshoper_usersController : Controller
    {
        private Model db = new Model();

        // GET: eshoper_users
        public ActionResult Index()
        {
            return View(db.eshoper_users.ToList());
        }

        // GET: eshoper_users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eshoper_users eshoper_users = db.eshoper_users.Find(id);
            if (eshoper_users == null)
            {
                return HttpNotFound();
            }
            return View(eshoper_users);
        }

        // GET: eshoper_users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: eshoper_users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userId,userName,userPwd,email,user_phone,user_Add1,user_Add2,user_City")] eshoper_users eshoper_users)
        {
            if (ModelState.IsValid)
            {
                db.eshoper_users.Add(eshoper_users);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eshoper_users);
        }

        // GET: eshoper_users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eshoper_users eshoper_users = db.eshoper_users.Find(id);
            if (eshoper_users == null)
            {
                return HttpNotFound();
            }
            return View(eshoper_users);
        }

        // POST: eshoper_users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userId,userName,userPwd,email,user_phone,user_Add1,user_Add2,user_City")] eshoper_users eshoper_users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eshoper_users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eshoper_users);
        }

        // GET: eshoper_users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eshoper_users eshoper_users = db.eshoper_users.Find(id);
            if (eshoper_users == null)
            {
                return HttpNotFound();
            }
            return View(eshoper_users);
        }

        // POST: eshoper_users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            eshoper_users eshoper_users = db.eshoper_users.Find(id);
            db.eshoper_users.Remove(eshoper_users);
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
