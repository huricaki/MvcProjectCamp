using BusinessLayer.Concreate;
using BusinessLayer.WalidationRules;
using DataAccsesLayer.EntityFramework;
using EntityLayer.Concreate;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class AdminCategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());
        // GET: AdminCategory
        public ActionResult Index()
        {
            var categoryValues = categoryManager.GetList();
            return View(categoryValues);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
         [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            CategoryValidatior categoryvalidator = new CategoryValidatior();
            ValidationResult results = categoryvalidator.Validate(p);
            if (results.IsValid)
            {
                categoryManager.CategoryAdd(p);
               return RedirectToAction("Index","AdminCategory");
            }
            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }
            return View();

        }

        public ActionResult DeleteCategory(int id)
        {
            var category = categoryManager.GetByID(id);
            categoryManager.CategoryDelete(category);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var categoryvalue = categoryManager.GetByID(id);
            return View(categoryvalue);
        }
        [HttpPost]
        public ActionResult EditCategory(Category p)
        {
            categoryManager.CategoryUpdate(p);
            return RedirectToAction("Index");
            
        }
    }
}