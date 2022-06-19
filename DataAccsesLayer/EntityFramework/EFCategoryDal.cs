using DataAccsesLayer.Abstract;
using DataAccsesLayer.ConCreate.Repositories;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsesLayer.EntityFramework
{
   public class EFCategoryDal:GenericRepository<Category>, ICategoryDal
    {

    }
}
