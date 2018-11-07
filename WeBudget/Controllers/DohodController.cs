using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeBudget.Models;

namespace WeBudget.Controllers
{
    public class DohodController : Controller
    {
        BudgetContext db = new BudgetContext();

        [HttpGet]
        public ActionResult EditDohod(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Dohod dohod = db.Dohods.Find(id);
            if (dohod != null)
            {
                return View(dohod);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditDohod(Dohod dohod)
        {
            db.Entry(dohod).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Dohods");
        }

        [HttpGet]
        public ActionResult CreateDohod()

        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateDohod(Dohod dohod)
        {
            db.Dohods.Add(dohod);
            db.SaveChanges();
            return RedirectToAction("Dohods");
        }

        public ActionResult DeleteDohod(int id)
        {
            Dohod b = db.Dohods.Find(id);
            if (b != null)
            {
                db.Dohods.Remove(b);
                db.SaveChanges();
            }
            return RedirectToAction("Dohods");
        }

        public ActionResult Dohods()

        {
            return View(db.Dohods);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}