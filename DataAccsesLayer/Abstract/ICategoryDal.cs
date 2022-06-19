using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsesLayer.Abstract
{
   public interface ICategoryDal: IRepository<Category>
    {
        //CRUD
        //type name();
        List<Category> List();

        void Insert(Category p);

        void Update(Category p);

        void Delete(Category p);

        

    }
}
