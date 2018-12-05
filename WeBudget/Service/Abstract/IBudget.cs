using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeBudget.Service.Abstract
{
     public interface IBudget
    {
        void Delete(int id);
        void Edit(BaseEntity baseEntity);
        void Create(BaseEntity baseEntity);
        BaseEntity findById(int? id);
        List<BaseEntity> getList();
    }
}
