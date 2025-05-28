using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AuthorizationController : Controller
    {
        AdminManager adm = new AdminManager(new EfAdminDal());

        public ActionResult Index()
        {
            var values = adm.GetList();
            return View(values);
        }
        public ActionResult AddAdmin()
        {
            List<SelectListItem> valueadmin = new List<SelectListItem>
                                                  {
                new SelectListItem { Text = "A", Value = "A" },
                new SelectListItem { Text= "B", Value = "B" },
                                                  }.ToList();

            ViewBag.vlr = valueadmin;
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            LoginValidator adminValidator = new LoginValidator();
            ValidationResult results = adminValidator.Validate(p);

            List<SelectListItem> valueadmin = new List<SelectListItem>
                                                  {
                new SelectListItem { Text = "A", Value = "A" },
                new SelectListItem { Text= "B", Value = "B" },
                                                  }.ToList();

            ViewBag.vlr = valueadmin;

            if (results.IsValid)
            {
                adm.AdminAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult EditAdmin(int id)
        {
            ViewBag.vlr = new SelectList(
                new List<SelectListItem>
                {
            new SelectListItem { Text = "A", Value = "A" },
            new SelectListItem { Text = "B", Value = "B" },
                }, "Value", "Text");

            var value = adm.GetById(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult EditAdmin(Admin p)
        {
            LoginValidator adminValidator = new LoginValidator();
            ValidationResult results = adminValidator.Validate(p);

            ViewBag.vlr = new SelectList(
                new List<SelectListItem>
                {
            new SelectListItem { Text = "A", Value = "A" },
            new SelectListItem { Text = "B", Value = "B" },
                }, "Value", "Text");

            if (results.IsValid)
            {
                adm.AdminUpdate(p);
                return RedirectToAction("Index");
            }
            foreach (var item in results.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View();
        }

        public ActionResult AdminRoleA(int id)
        {
            var admin = adm.GetById(id);
            admin.AdminRole = "A";
            adm.AdminUpdate(admin);
            return RedirectToAction("Index");
        }

        public ActionResult AdminRoleB(int id)
        {
            var admin = adm.GetById(id);
            admin.AdminRole = "B";
            adm.AdminUpdate(admin);
            return RedirectToAction("Index");
        }
    }
}