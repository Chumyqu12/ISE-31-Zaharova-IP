using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WeBudget.Models;
using WeBudget.Service.Abstract;

namespace WeBudget.Service
{
	public class DohodService : IBudget
	{
		BudgetContext db = new BudgetContext();
		public  void Delete(int id) {
            Dohod b = db.Dohods.Find(id);
            if (b != null)
            {
                db.Dohods.Remove(b);
                db.SaveChanges();
            }
        }

        public void Edit(BaseEntity baseEntity) {
            db.Entry((Dohod)baseEntity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public  void Create(BaseEntity baseEntity) {
            db.Dohods.Add((Dohod)baseEntity);
            db.SaveChanges();
        }

        public BaseEntity findById(int? id)
        {
            Dohod dohod = db.Dohods.Find(id);
            return dohod;
        }

        public  List<BaseEntity> getList()
        {
            List < BaseEntity > baseentity = new List <BaseEntity>();
            List<Dohod> dohod = db.Dohods.ToList();
            for (int i = 0; i < dohod.Count; i++) {
                baseentity.Add(dohod[i]);
            }
            return baseentity;
        }

    }
}