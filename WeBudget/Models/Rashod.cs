using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeBudget.Service.Abstract;

namespace WeBudget.Models
{
    [Serializable]
    public class Rashod : BaseEntity
    {

        public int Day { get; set; }

        public int Month { get; set; }

        public double Sum { get; set; }

        public string Comment { get; set; }

        public int UserId { get; set; }

        // public  User User { get; set; }


    }
}