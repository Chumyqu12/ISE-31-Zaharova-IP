using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WeBudget.Models;

namespace WeBudget.Service
{
	public class RashodService
	{
        BudgetContext db = new BudgetContext();
        public void Delete(int id)
        {
            Rashod b = db.Rashods.Find(id);
            if (b != null)
            {
                db.Rashods.Remove(b);
                db.SaveChanges();
            }
        }

        public void Edit(Rashod rashod)
        {
            db.Entry(rashod).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Create(Rashod rashod)
        {
            db.Rashods.Add(rashod);
            db.SaveChanges();
        }

        public Rashod findRashodById(int? id)
        {
            Rashod rashod = db.Rashods.Find(id);
            return rashod;
        }

       /* public List<Rashod> getList()
        {
            return db.Rashods.ToList();
 
        }*/

        public void Dispose()
        {
            db.Dispose();
        }

    }
}
