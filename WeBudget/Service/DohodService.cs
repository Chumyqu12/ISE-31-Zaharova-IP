using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WeBudget.Models;

namespace WeBudget.Service
{
	public class DohodService
	{
		BudgetContext db = new BudgetContext();
		public void Delete(int id) {
            Dohod b = db.Dohods.Find(id);
            if (b != null)
            {
                db.Dohods.Remove(b);
                db.SaveChanges();
            }
        }

        public void Edit(Dohod dohod) {
            db.Entry(dohod).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Create(Dohod dohod) {
            db.Dohods.Add(dohod);
            db.SaveChanges();
        }

        public Dohod findDohodById(int? id)
        {
            Dohod dohod = db.Dohods.Find(id);
            return dohod;
        }

        public List<Dohod> getList()
        {
            return db.Dohods.ToList();
        }

        public void Dispose() {
            db.Dispose();
        }


    }
}