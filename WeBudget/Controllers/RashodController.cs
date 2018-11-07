using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeBudget.Models;
using WeBudget.Service;

namespace WeBudget.Controllers
{
    public class RashodController : Controller
    {
        RashodService rashodservice = new RashodService();

        [HttpGet]
        public ActionResult EditRashod(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            
            if (rashodservice.findRashodById(id) != null)
            {
                return View(rashodservice.findRashodById(id));
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditRashod(Rashod rashod)

        {
            rashodservice.Edit(rashod);
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
            rashodservice.Create(rashod);
            return RedirectToAction("Rashods");
        }


        public ActionResult DeleteRashod(int id)
        {
            rashodservice.Delete(id);
            return RedirectToAction("Rashods");
        }


        public ActionResult Rashods()
        {
            BudgetContext db = new BudgetContext();
            // return View(rashodservice.getList());
            return View(db.Rashods);
        }
        protected override void Dispose(bool disposing)
        {
            rashodservice.Dispose();
            base.Dispose(disposing);
        }
    }
}