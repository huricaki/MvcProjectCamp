using BusinessLayer.Concreate;
using DataAccsesLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class GaleriController : Controller
    {
        // GET: Galeri
        ImageFileManager im = new ImageFileManager(new EFImageFileDal());
        public ActionResult Index()
        {
            var files = im.GetList();
            return View(files);
        }
    }
}