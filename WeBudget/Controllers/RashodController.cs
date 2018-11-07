using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeBudget.Models;

namespace WeBudget.Controllers
{
    public class RashodController : Controller
    {
        BudgetContext db = new BudgetContext();

        [HttpGet]
        public ActionResult EditRashod(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Rashod rashod = db.Rashods.Find(id);
            if (rashod != null)
            {
                return View(rashod);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditRashod(Rashod rashod)

        {
            db.Entry(rashod).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Rashods");
        }

        [HttpGet]
        public ActionResult CreateRashod()

        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateRashod(Rashod rashod)
        {
            db.Rashods.Add(rashod);
            db.SaveChanges();
            return RedirectToAction("Rashods");
        }


        public ActionResult DeleteRashod(int id)
        {
            Rashod b = db.Rashods.Find(id);
            if (b != null)
            {
                db.Rashods.Remove(b);
                db.SaveChanges();
            }
            return RedirectToAction("Rashods");
        }



        public ActionResult Rashods()
        {
            return View(db.Rashods);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}