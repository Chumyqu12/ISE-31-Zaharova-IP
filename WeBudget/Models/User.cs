using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeBudget.Models
{
    public class User
    {
        public int Id { get; set; }

        public string FIO { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }
    }
}