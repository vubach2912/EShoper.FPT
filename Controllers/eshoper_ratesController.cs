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
    public class eshoper_ratesController : Controller
    {
        private Model db = new Model();

        // GET: eshoper_rates
        public ActionResult Index()
        {
            var eshoper_rates = db.eshoper_rates.Include(e => e.eshoper_product).Include(e => e.eshoper_users);
            return View(eshoper_rates.ToList());
        }

        // GET: eshoper_rates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eshoper_rates eshoper_rates = db.eshoper_rates.Find(id);
            if (eshoper_rates == null)
            {
                return HttpNotFound();
            }
            return View(eshoper_rates);
        }

        // GET: eshoper_rates/Create
        public ActionResult Create()
        {
            ViewBag.rate_productID = new SelectList(db.eshoper_product, "id", "name");
            ViewBag.rate_userID = new SelectList(db.eshoper_users, "userId", "userName");
            return View();
        }

        // POST: eshoper_rates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "rate_id,rate_productID,rate_number,rate_userID")] eshoper_rates eshoper_rates)
        {
            if (ModelState.IsValid)
            {
                db.eshoper_rates.Add(eshoper_rates);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.rate_productID = new SelectList(db.eshoper_product, "id", "name", eshoper_rates.rate_productID);
            ViewBag.rate_userID = new SelectList(db.eshoper_users, "userId", "userName", eshoper_rates.rate_userID);
            return View(eshoper_rates);
        }

        // GET: eshoper_rates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eshoper_rates eshoper_rates = db.eshoper_rates.Find(id);
            if (eshoper_rates == null)
            {
                return HttpNotFound();
            }
            ViewBag.rate_productID = new SelectList(db.eshoper_product, "id", "name", eshoper_rates.rate_productID);
            ViewBag.rate_userID = new SelectList(db.eshoper_users, "userId", "userName", eshoper_rates.rate_userID);
            return View(eshoper_rates);
        }

        // POST: eshoper_rates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "rate_id,rate_productID,rate_number,rate_userID")] eshoper_rates eshoper_rates)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eshoper_rates).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.rate_productID = new SelectList(db.eshoper_product, "id", "name", eshoper_rates.rate_productID);
            ViewBag.rate_userID = new SelectList(db.eshoper_users, "userId", "userName", eshoper_rates.rate_userID);
            return View(eshoper_rates);
        }

        // GET: eshoper_rates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eshoper_rates eshoper_rates = db.eshoper_rates.Find(id);
            if (eshoper_rates == null)
            {
                return HttpNotFound();
            }
            return View(eshoper_rates);
        }

        // POST: eshoper_rates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            eshoper_rates eshoper_rates = db.eshoper_rates.Find(id);
            db.eshoper_rates.Remove(eshoper_rates);
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
