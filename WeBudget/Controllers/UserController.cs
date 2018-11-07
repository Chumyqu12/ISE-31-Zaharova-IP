using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeBudget.Models;

namespace WeBudget.Controllers
{
    public class UserController : Controller

    {
        BudgetContext db = new BudgetContext();

        public ActionResult Users()

        {
            return View(db.Users);
        }

        [HttpGet]
        public ActionResult CreateUser()

        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(User User)
        {
            db.Users.Add(User);
            db.SaveChanges();
            return RedirectToAction("Users");
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}