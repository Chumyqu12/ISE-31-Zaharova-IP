using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeBudget.Models;

namespace WeBudget.Service.Interface
{
   public interface IRashod
    {
        void Delete(int id);

        void Edit(Rashod rashod);

        void Create(Rashod rashod);

        Rashod findRashodById(int? id);

        List<Rashod> getList();

        void Dispose();

    }
}
