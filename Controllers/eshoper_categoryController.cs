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
    public class eshoper_categoryController : Controller
    {
        private Model db = new Model();

        // GET: eshoper_category
        public ActionResult Index()
        {
            return View(db.eshoper_category.ToList());
        }

        // GET: eshoper_category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eshoper_category eshoper_category = db.eshoper_category.Find(id);
            if (eshoper_category == null)
            {
                return HttpNotFound();
            }
            return View(eshoper_category);
        }

        // GET: eshoper_category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: eshoper_category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "categoryID,categoryImgID,categoryName")] eshoper_category eshoper_category)
        {
            if (ModelState.IsValid)
            {
                db.eshoper_category.Add(eshoper_category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eshoper_category);
        }

        // GET: eshoper_category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eshoper_category eshoper_category = db.eshoper_category.Find(id);
            if (eshoper_category == null)
            {
                return HttpNotFound();
            }
            return View(eshoper_category);
        }

        // POST: eshoper_category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "categoryID,categoryImgID,categoryName")] eshoper_category eshoper_category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eshoper_category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eshoper_category);
        }

        // GET: eshoper_category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eshoper_category eshoper_category = db.eshoper_category.Find(id);
            if (eshoper_category == null)
            {
                return HttpNotFound();
            }
            return View(eshoper_category);
        }

        // POST: eshoper_category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            eshoper_category eshoper_category = db.eshoper_category.Find(id);
            db.eshoper_category.Remove(eshoper_category);
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
