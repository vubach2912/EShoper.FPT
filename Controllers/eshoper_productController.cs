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
    public class eshoper_productController : Controller
    {
        private Model db = new Model();

        // GET: eshoper_product
        public ActionResult Index()
        {
            var eshoper_product = db.eshoper_product.Include(e => e.eshoper_category);
            return View(eshoper_product.ToList());
        }

        // GET: eshoper_product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eshoper_product eshoper_product = db.eshoper_product.Find(id);
            if (eshoper_product == null)
            {
                return HttpNotFound();
            }
            return View(eshoper_product);
        }

        // GET: eshoper_product/Create
        public ActionResult Create()
        {
            ViewBag.categoryID = new SelectList(db.eshoper_category, "categoryID", "categoryName");
            return View();
        }

        // POST: eshoper_product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,imgID,description,categoryID,quantities,manufactory,condition,price,rate")] eshoper_product eshoper_product)
        {
            if (ModelState.IsValid)
            {
                db.eshoper_product.Add(eshoper_product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categoryID = new SelectList(db.eshoper_category, "categoryID", "categoryName", eshoper_product.categoryID);
            return View(eshoper_product);
        }

        // GET: eshoper_product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eshoper_product eshoper_product = db.eshoper_product.Find(id);
            if (eshoper_product == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoryID = new SelectList(db.eshoper_category, "categoryID", "categoryName", eshoper_product.categoryID);
            return View(eshoper_product);
        }

        // POST: eshoper_product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,imgID,description,categoryID,quantities,manufactory,condition,price,rate")] eshoper_product eshoper_product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eshoper_product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoryID = new SelectList(db.eshoper_category, "categoryID", "categoryName", eshoper_product.categoryID);
            return View(eshoper_product);
        }

        // GET: eshoper_product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eshoper_product eshoper_product = db.eshoper_product.Find(id);
            if (eshoper_product == null)
            {
                return HttpNotFound();
            }
            return View(eshoper_product);
        }

        // POST: eshoper_product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            eshoper_product eshoper_product = db.eshoper_product.Find(id);
            db.eshoper_product.Remove(eshoper_product);
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
