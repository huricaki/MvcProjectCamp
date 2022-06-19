using BusinessLayer.Concreate;
using DataAccsesLayer.ConCreate;
using DataAccsesLayer.EntityFramework;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent
        ContentManager cm = new ContentManager(new EFContentDal());
        Context c = new Context();
        public ActionResult MyContent(string p)
        {
            
            int id=2;
            p = (string)Session["WriterMail"];
            var WriterIdinfo = c.Writers.Where(x => x.WriterMail == p).Select(y =>
                  y.WriterID).FirstOrDefault();
            //ViewBag.d = p;
            var contentvalues = cm.GetListByWriter(WriterIdinfo);

            return View(contentvalues);
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content p) 
        {
           string mail = (string)Session["WriterMail"];
            var WriterIdinfo = c.Writers.Where(x => x.WriterMail == mail).Select(y =>
                  y.WriterID).FirstOrDefault();
            p.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterID = WriterIdinfo;
            p.ContentStatus = true;
            cm.ContentAdd(p);

            return RedirectToAction("MyContent");
        }
        public ActionResult ToDoList()
        {
            return View();
        }
    }
}