﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
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
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            adm.AdminAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult EditAdmin(int id)
        {
            List<SelectListItem> valuerole = (from x in adm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.AdminRole,
                                                      Value = x.AdminId.ToString()
                                                  }).ToList();
            ViewBag.vlr = valuerole;
            var value = adm.GetById(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult EditAdmin(Admin p)
        {
            adm.AdminUpdate(p);
            return RedirectToAction("Index");
        }
    }
}