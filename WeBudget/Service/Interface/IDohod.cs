using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeBudget.Models;

namespace WeBudget.Service.Interface
{
    interface IDohod
    {
        void Delete(int id);

        void Edit(Dohod dohod);

        void Create(Dohod dohod);

        Dohod findDohodById(int? id);

        List<Dohod> getList();

        void Dispose();
    }
}
