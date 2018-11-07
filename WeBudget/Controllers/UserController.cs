using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeBudget.Models;
using WeBudget.Service;

namespace WeBudget.Controllers
{
    public class UserController : Controller

    {
        UserService userservice = new UserService();

        public ActionResult Users()

        {
            return View(userservice.getList());
        }

        [HttpGet]
        public ActionResult CreateUser()

        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(User User)
        {
            userservice.Create(User);
            return RedirectToAction("Users");
        }


        protected override void Dispose(bool disposing)
        {
            userservice.Dispose();
            base.Dispose(disposing);
        }
    }
}