using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class DraftController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();

        public ActionResult Index()
        {
            string mail = (string)Session["AdminUserName"];
            var values = mm.GetListDrafts(mail);
            return View(values);
        }

        public ActionResult AddDraft()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDraft(Message p)
        {
            p.IsDraft = true;
            p.IsDeleted = false;
            p.MessageDate = DateTime.Now;
            p.SenderMail = (string)Session["AdminUserName"];
            mm.MessageAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult UpdateDraft(int id)
        {
            var value = mm.GetById(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateDraft(Message p)
        {
            var results = messageValidator.Validate(p);
            if (results.IsValid)
            {
                p.IsDraft = true;
                p.IsDeleted = false;
                p.MessageDate = DateTime.Now;
                mm.MessageUpdate(p);
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

        [HttpPost]
        public ActionResult SendDraft(Message p)
        {
            var results = messageValidator.Validate(p);
            if (results.IsValid)
            {
                p.IsDraft = false;
                p.IsDeleted = false;
                p.MessageDate = DateTime.Now;
                p.SenderMail = (string)Session["AdminUserName"];
                mm.MessageUpdate(p);
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
    }
}