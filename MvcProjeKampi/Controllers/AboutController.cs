using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager(new EfAboutDal());

        public ActionResult Index()
        {
            var values = abm.GetList();
            return View(values);
        }

        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(About p)
        {
            abm.AboutAdd(p);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }

        public ActionResult UpdateAbout(int id)
        {
            var value = abm.GetById(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateAbout(About p)
        {
            abm.AboutUpdate(p);
            return RedirectToAction("Index");
        }

        public ActionResult StatusAbout(int id)
        {
            var value = abm.GetById(id);
            if (value.AboutStatus == true)
            {
                value.AboutStatus = false;
                abm.AboutUpdate(value);
            }

            else
            {
                value.AboutStatus = true;
                abm.AboutUpdate(value);
            }
            return RedirectToAction("Index");
        }
    }
}