using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WeBudget.Models;
using WeBudget.Service.Abstract;

namespace WeBudget.Service
{
	public class RashodService : IBudget
	{
        BudgetContext db = new BudgetContext();
        public  void Delete(int id)
        {
            Rashod b = db.Rashods.Find(id);
            if (b != null)
            {
                db.Rashods.Remove(b);
                db.SaveChanges();
            }
        }

        public  void Edit (BaseEntity baseEntity)
        {
            db.Entry((Rashod)baseEntity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public  void Create(BaseEntity baseEntity)
        {
            db.Rashods.Add((Rashod)baseEntity);
            db.SaveChanges();
        }

        public  BaseEntity findById(int? id)
        {
            Rashod rashod = db.Rashods.Find(id);
            return rashod;
        }

        public  List<BaseEntity> getList()
        {
            List<BaseEntity> baseentity = new List<BaseEntity>();
            List<Rashod> rashod = db.Rashods.ToList();
            for (int i = 0; i < rashod.Count; i++)
            {
                baseentity.Add(rashod[i]);
            }
            return baseentity;

        }

       
    }
}
