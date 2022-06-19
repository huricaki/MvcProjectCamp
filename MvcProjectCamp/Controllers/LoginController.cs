﻿using BusinessLayer.Concreate;
using DataAccsesLayer.ConCreate;
using DataAccsesLayer.EntityFramework;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
namespace MvcProjectCamp.Controllers
{
    [AllowAnonymous]

    public class LoginController : Controller
    {
        WriterLoginManager wm = new WriterLoginManager(new EFWriterDal());
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            Context c = new Context();
            var adminUserinfo = c.Admins.FirstOrDefault(x => x.AdminName == p.AdminName &&
              x.AdminPassword == p.AdminPassword);

            if (adminUserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminUserinfo.AdminName, false);
                Session["AdminName"] = adminUserinfo.AdminName;

                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }

            return View();

        }
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {
            //Context c = new Context();
            //var WriterUserInfo = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail &&
            //  x.WriterPassword == p.WriterPassword);
            var WriterUserInfo = wm.GetWriter(p.WriterMail, p.WriterPassword);
            if (WriterUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(WriterUserInfo.WriterMail, false);
                Session["WriterMail"] = WriterUserInfo.WriterMail;

                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }
    }
}