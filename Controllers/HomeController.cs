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
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Model db = new Model();
            ViewData["Product"] = db.eshoper_product.Include(e => e.eshoper_category).ToList();
            ViewData["Category"] = db.eshoper_category.ToList();
            return View();
        }
    }
}