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
    public class RashodController : Controller
    {
        String store = ConfigurationManager.AppSettings.Get("Store");
        IBudget rashodservice;


        public RashodController()
        {
            if (store == "db")
            {
                rashodservice = new RashodService();
            }

            if (store == "file")
            {
                rashodservice = new RashodFileService();
            }
        }
      

        [HttpGet]
        public ActionResult EditRashod(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            
            if (rashodservice.findById(id) != null)
            {
                return View(rashodservice.findById(id));
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
             return View(rashodservice.getList());
           
        }
       
    }
}