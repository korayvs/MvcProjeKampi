using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDal());
        MessageManager mm = new MessageManager(new EfMessageDal());
        ContactValidator cv = new ContactValidator();

        public ActionResult Index()
        {
            var values = cm.GetList();
            return View(values);
        }

        public ActionResult GetContactDetails(int id)
        {
            var values = cm.GetById(id);
            return View(values);
        }

        public PartialViewResult ContactPartial()
        {
            string mail = (string)Session["AdminUserName"];
            ViewBag.ccount = cm.ContactCountx();
            ViewBag.smc = mm.SendMessageCountx(mail);
            ViewBag.rmc = mm.ReceivedMessageCountx(mail);
            ViewBag.dcount = mm.DraftsCountx(mail);
            ViewBag.delcount = mm.DeletedCountx(mail);
            return PartialView();
        }
    }
}