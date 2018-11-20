using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeBudget.Models;

namespace WeBudget.Service
{
    public class UserService
    {
        BudgetContext db = new BudgetContext();

        public void Create(User User) {
            db.Users.Add(User);
            db.SaveChanges();
        }

        public List<User> getList()
        {
            return db.Users.ToList();

        }

        public void Dispose()
        {
            db.Dispose();
        }

    }
}