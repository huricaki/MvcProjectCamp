using BusinessLayer.Concreate;
using DataAccsesLayer.ConCreate;
using DataAccsesLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        ContentManager cm = new ContentManager(new EFContentDal());
  
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult GetAllContent(string p)
        {
            var values = cm.GetList(p);
           // var values = c.Contents.ToList();
            return View(values);
        }
        public ActionResult ContentByHeading(int id)
        {
            var contentvalues = cm.GetListByID(id);

            return View(contentvalues);
        }
    }
}