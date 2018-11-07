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
    public class DohodController : Controller
    {
        DohodService dohodservice = new DohodService();

        [HttpGet]
        public ActionResult EditDohod(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
           
            if (dohodservice.findDohodById(id) != null)
            {
                return View(dohodservice.findDohodById(id));
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditDohod(Dohod dohod)
        {
            dohodservice.Edit(dohod);
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
            dohodservice.Create(dohod);
            return RedirectToAction("Dohods");
        }

        public ActionResult DeleteDohod(int id)
        {
            dohodservice.Delete(id);
            return RedirectToAction("Dohods");
        }

        public ActionResult Dohods()

        {
            return View(dohodservice.getList());
        }
        protected override void Dispose(bool disposing)
        {
            dohodservice.Dispose();
            base.Dispose(disposing);
        }
    }
}