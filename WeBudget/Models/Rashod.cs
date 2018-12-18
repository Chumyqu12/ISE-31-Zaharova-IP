using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WeBudget.Service.Abstract;

namespace WeBudget.Models
{
    [Serializable]
    public class Rashod : BaseEntity
    {

        [Required(ErrorMessage = "Введите день 01-31")]
        [RegularExpression(@"^(0[1-9]|[12][0-9]|3[01])$",
          ErrorMessage = "Введите день 01-31")]
        public int Day { get; set; }

        [Required(ErrorMessage = "Введите месяц 01-12")]
        [RegularExpression(@"^(0[1-9]|1[012])$",
         ErrorMessage = "Введите месяц 01-12")]
        public int Month { get; set; }

        [Required(ErrorMessage = "Введите сумму")]
        [RegularExpression(@"^\d{1,10}",
           ErrorMessage = "Неверно введена сумма")]
        public double Sum { get; set; }

        [Required(ErrorMessage = "Введите комментарий")]
        [RegularExpression(@"^.{1,30}$", ErrorMessage = "Введите от 1 до 30 символов")]
        public string Comment { get; set; }

        public int UserId { get; set; }


        // public  User User { get; set; }


    }
}