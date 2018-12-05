using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeBudget.Models;
using WeBudget.Service;
using WeBudget.Service.Abstract;
using WeBudget.Service.FileService;

namespace WeBudget.Controllers
{
    public class DohodController : Controller
    {
       String store = ConfigurationManager.AppSettings.Get("Store");
       IBudget dohodservice;
      

        public DohodController() {
            if (store == "db")
            {
              dohodservice = new DohodService();
            }

            if (store == "file")
            {
              dohodservice = new DohodFileService();
            }
        }

        [HttpGet]
        public ActionResult EditDohod(int? id)
        {

            if (dohodservice.findById(id) != null)
            {
                return View(dohodservice.findById(id));
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
    }
}